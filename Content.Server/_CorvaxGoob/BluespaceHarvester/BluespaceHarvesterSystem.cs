using Content.Server.Power.Components;
using Content.Shared.Audio;
using Content.Shared._CorvaxGoob.BluespaceHarvester;
using Content.Shared.Destructible;
using Content.Shared.Emag.Components;
using Robust.Server.GameObjects;
using Robust.Shared.Random;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Content.Server.Power.EntitySystems;
using Robust.Shared.Audio.Systems;
using Robust.Shared.Map;
using Robust.Shared.Timing;
using Robust.Shared.Utility;

namespace Content.Server._CorvaxGoob.BluespaceHarvester;

public sealed class BluespaceHarvesterSystem : EntitySystem
{
    [Dependency] private readonly IGameTiming _timing = default!;
    [Dependency] private readonly SharedAppearanceSystem _appearance = default!;
    [Dependency] private readonly TransformSystem _transform = default!;
    [Dependency] private readonly EntityLookupSystem _lookup = default!;
    [Dependency] private readonly UserInterfaceSystem _ui = default!;
    [Dependency] private readonly IRobustRandom _random = default!;
    [Dependency] private readonly SharedAudioSystem _audio = default!;
    [Dependency] private readonly SharedAmbientSoundSystem _ambientSound = default!;

    private readonly List<BluespaceHarvesterTap> _taps =
    [
        new() { Level = 0, Visual = BluespaceHarvesterVisuals.Tap0 },
        new() { Level = 1, Visual = BluespaceHarvesterVisuals.Tap1 },
        new() { Level = 5, Visual = BluespaceHarvesterVisuals.Tap2 },
        new() { Level = 10, Visual = BluespaceHarvesterVisuals.Tap3 },
        new() { Level = 15, Visual = BluespaceHarvesterVisuals.Tap4 },
        new() { Level = 20, Visual = BluespaceHarvesterVisuals.Tap5 },
    ];

    private float _updateTimer;
    private const float UpdateTime = 1.0f;

    private EntityQuery<BluespaceHarvesterComponent> _harvesterQuery;

    public override void Initialize()
    {
        base.Initialize();

        _harvesterQuery = GetEntityQuery<BluespaceHarvesterComponent>();

        SubscribeLocalEvent<BluespaceHarvesterComponent, ComponentStartup>(OnStartup);
        SubscribeLocalEvent<BluespaceHarvesterComponent, ComponentRemove>(OnRemove);

        SubscribeLocalEvent<BluespaceHarvesterComponent, PowerConsumerReceivedChanged>(ReceivedChanged);
        SubscribeLocalEvent<BluespaceHarvesterComponent, BluespaceHarvesterTargetLevelMessage>(OnTargetLevel);
        SubscribeLocalEvent<BluespaceHarvesterComponent, BluespaceHarvesterBuyMessage>(OnBuy);
        SubscribeLocalEvent<BluespaceHarvesterComponent, DestructionEventArgs>(OnDestruction);
    }

    private void OnStartup(Entity<BluespaceHarvesterComponent> ent, ref ComponentStartup args)
    {
        UpdateCount();
    }

    private void OnRemove(Entity<BluespaceHarvesterComponent> ent, ref ComponentRemove args)
    {
        UpdateCount();
    }

    private void UpdateCount()
    {
        var dictionary = new Dictionary<MapId, List<EntityUid>>();

        var query = EntityQueryEnumerator<BluespaceHarvesterComponent>();
        while (query.MoveNext(out var entityUid, out _))
        {
            var mapId = Transform(entityUid).MapID;
            var list = dictionary.GetOrNew(mapId);
            list.Add(entityUid);
        }

        query = EntityQueryEnumerator<BluespaceHarvesterComponent>();
        while (query.MoveNext(out var entityUid, out var harvester))
        {
            var mapId = Transform(entityUid).MapID;
            harvester.Harvesters = dictionary[mapId].Count;
        }
    }

    private void ReceivedChanged(Entity<BluespaceHarvesterComponent> ent, ref PowerConsumerReceivedChanged args)
    {
        ent.Comp.ReceivedPower = args.ReceivedPower;
        ent.Comp.DrawRate = args.DrawRate;
    }

    public override void Update(float frameTime)
    {
        base.Update(frameTime);

        _updateTimer += frameTime;

        if (_updateTimer < UpdateTime)
            return;

        _updateTimer -= UpdateTime;

        var query = EntityQueryEnumerator<BluespaceHarvesterComponent, PowerConsumerComponent>();
        while (query.MoveNext(out var uid, out var harvester, out var consumer))
        {
            // We start only after manual switching on.
            if (harvester is { Reset: false, CurrentLevel: 0 })
                harvester.Reset = true;

            // The HV wires cannot transmit a lot of electricity so quickly,
            // which is why it will not start.
            // So this is simply using the amount of free electricity in the network.
            if (harvester.ReceivedPower < GetUsagePower(harvester.CurrentLevel) && harvester.CurrentLevel != 0)
            {
                // If there is insufficient production,
                // it will reset itself (turn off) and you will need to start it again,
                // this will not allow you to set it to maximum and enjoy life
                Reset(uid, harvester);
            }

            if (harvester.Reset)
            {
                if (harvester.CurrentLevel < harvester.TargetLevel)
                    harvester.CurrentLevel++;
            }

            if (harvester.CurrentLevel > harvester.TargetLevel)
                harvester.CurrentLevel--;

            // Increasing the amount of energy regardless of its ability to generate it
            // will make it impossible to set the desired value and go to rest.
            consumer.DrawRate = GetUsagePower(harvester.CurrentLevel);

            var generation = GetPointGeneration(uid, harvester);
            harvester.Points += generation;
            harvester.TotalPoints += generation;

            // the generation of danger points can be negative, so there is this limitation here.
            harvester.Danger += GetDangerPointGeneration(uid, harvester);
            if (harvester.Danger < 0)
                harvester.Danger = 0;

            // If the danger points exceeded the DangerLimit and we were lucky enough to create a portal, then they will be created.
            if (harvester.Danger > harvester.DangerLimit && _random.NextFloat(0.0f, 1.0f) <= GetRiftChance(uid, harvester))
            {
                SpawnRifts(uid, harvester);
            }

            if (TryComp<AmbientSoundComponent>(uid, out var ambient))
                _ambientSound.SetAmbience(uid, harvester.Reset, ambient); // Bzhzh, bzhzh

            UpdateAppearance(uid, harvester);
            UpdateUI(uid, harvester);
        }
    }

    private void OnDestruction(Entity<BluespaceHarvesterComponent> harvester, ref DestructionEventArgs args)
    {
        SpawnRifts(harvester.Owner, harvester.Comp);
    }

    private void OnTargetLevel(Entity<BluespaceHarvesterComponent> harvester, ref BluespaceHarvesterTargetLevelMessage args)
    {
        // If we switch off, we don't need to be switched on.
        if (!harvester.Comp.Reset)
            return;

        harvester.Comp.TargetLevel = args.TargetLevel;
        UpdateUI(harvester.Owner, harvester.Comp);
    }

    private void OnBuy(Entity<BluespaceHarvesterComponent> harvester, ref BluespaceHarvesterBuyMessage args)
    {
        if (!harvester.Comp.Reset)
            return;

        if (!TryGetCategory(harvester.Owner, args.Category, out var info, harvester.Comp))
            return;

        var category = (BluespaceHarvesterCategoryInfo) info;

        if (harvester.Comp.Points < category.Cost)
            return;

        harvester.Comp.Points -= category.Cost; // Damn capitalism.
        SpawnLoot(harvester.Owner, category.PrototypeId, harvester.Comp);
    }

    private void UpdateAppearance(EntityUid uid, BluespaceHarvesterComponent? harvester = null)
    {
        if (!Resolve(uid, ref harvester))
            return;

        var level = harvester.CurrentLevel;
        BluespaceHarvesterTap? max = null;

        foreach (var tap in _taps)
        {
            if (tap.Level > level)
                continue;

            if (max == null || tap.Level > max.Level)
                max = tap;
        }

        // We get the biggest Tap of all, and replace it with a harvester.
        if (max == null)
            return;

        if (Emagged(uid))
            _appearance.SetData(uid, BluespaceHarvesterVisualLayers.Base, (int) harvester.RedspaceTap);
        else
            _appearance.SetData(uid, BluespaceHarvesterVisualLayers.Base, (int) max.Visual);

        _appearance.SetData(uid, BluespaceHarvesterVisualLayers.Effects, level != 0);
    }

    private void UpdateUI(EntityUid uid, BluespaceHarvesterComponent? harvester = null)
    {
        if (!Resolve(uid, ref harvester))
            return;

        _ui.SetUiState(uid,
            BluespaceHarvesterUiKey.Key,
            new BluespaceHarvesterBoundUserInterfaceState(
            harvester.TargetLevel,
            harvester.CurrentLevel,
            harvester.MaxLevel,
            GetUsagePower(harvester.CurrentLevel),
            GetUsageNextPower(harvester.CurrentLevel),
            harvester.Points,
            harvester.TotalPoints,
            GetPointGeneration(uid, harvester),
            harvester.Categories
        ));
    }

    private uint GetUsageNextPower(int level)
    {
        return GetUsagePower(level + 1);
    }

    private uint GetUsagePower(int level)
    {
        // Hopefully in the future you will need to put a mathematical formula or function here.
        return level switch
        {
            0 => 500,
            1 => 1_000,
            2 => 5_000,
            3 => 50_000,
            4 => 100_000,
            5 => 500_000,
            6 => 1_000_000,
            7 => 2_000_000,
            8 => 3_000_000,
            9 => 5_000_000,
            10 => 7_000_000,
            11 => 9_000_000,
            12 => 10_000_000,
            13 => 12_000_000,
            14 => 14_000_000,
            15 => 16_000_000,
            16 => 20_000_000,
            17 => 40_000_000,
            18 => 80_000_000,
            19 => 100_000_000,
            20 => 200_000_000,
            _ => 1_000_000_000,
        };
    }

    /// <summary>
    /// Finds a free point in space and creates a prototype there, similar to a bluespace anomaly.
    /// </summary>
    private EntityUid? SpawnLoot(EntityUid uid, string prototype, BluespaceHarvesterComponent? harvester = null)
    {
        if (!Resolve(uid, ref harvester))
            return null;

        var xform = Transform(uid);
        var coords = xform.Coordinates;
        var newCoords = coords.Offset(_random.NextVector2(harvester.SpawnRadius));

        for (var i = 0; i < 20; i++)
        {
            var randVector = _random.NextVector2(harvester.SpawnRadius);
            newCoords = coords.Offset(randVector);

            if (!_lookup.GetEntitiesIntersecting(newCoords.ToMap(EntityManager, _transform), LookupFlags.Static).Any())
                break;
        }

        _audio.PlayPvs(harvester.SpawnSound, uid);
        Spawn(harvester.SpawnEffect, newCoords);

        return Spawn(prototype, newCoords);
    }

    private int GetPointGeneration(EntityUid uid, BluespaceHarvesterComponent? harvester = null)
    {
        if (!Resolve(uid, ref harvester))
            return 0;

        return harvester.CurrentLevel * 4 * (Emagged(uid) ? 2 : 1) * (harvester.ResetTime == TimeSpan.Zero ? 1 : 0);
    }

    private int GetDangerPointGeneration(EntityUid uid, BluespaceHarvesterComponent? harvester = null)
    {
        if (!Resolve(uid, ref harvester))
            return 0;

        var stable = GetStableLevel(uid, harvester);
        if (harvester.CurrentLevel < stable && harvester.CurrentLevel != 0)
            return -1;

        if (harvester.CurrentLevel == stable)
            return 0;

        return (harvester.CurrentLevel - stable) * 4;
    }

    private float GetRiftChance(EntityUid uid, BluespaceHarvesterComponent? harvester = null)
    {
        if (!Resolve(uid, ref harvester))
            return 0;

        return Emagged(uid) ? harvester.EmaggedRiftChance : harvester.RiftChance;
    }

    private int GetStableLevel(EntityUid uid, BluespaceHarvesterComponent? harvester = null)
    {
        if (!Resolve(uid, ref harvester))
            return 0;

        if (harvester.Harvesters > 1)
            return 0;

        return Emagged(uid) ? harvester.EmaggedStableLevel : harvester.StableLevel;
    }

    private bool TryGetCategory(EntityUid uid, BluespaceHarvesterCategory target, [NotNullWhen(true)] out BluespaceHarvesterCategoryInfo? info, BluespaceHarvesterComponent? harvester = null)
    {
        info = null;
        if (!Resolve(uid, ref harvester))
            return false;

        foreach (var category in harvester.Categories)
        {
            if (category.Type != target)
                continue;

            info = category;
            return true;
        }

        return false;
    }

    private void Reset(EntityUid uid, BluespaceHarvesterComponent? harvester = null)
    {
        if (!Resolve(uid, ref harvester))
            return;

        harvester.Danger += harvester.DangerFromReset;
        harvester.Reset = false;
        harvester.TargetLevel = 0;
    }

    private bool Emagged(EntityUid uid)
    {
        return HasComp<EmaggedComponent>(uid);
    }

    private void SpawnRifts(EntityUid uid, BluespaceHarvesterComponent? harvester = null, int? danger = null)
    {
        if (!Resolve(uid, ref harvester))
            return;

        int currentDanger = danger ?? harvester.Danger;

        var count = _random.Next(harvester.RiftCount);
        for (var i = 0; i < count; i++)
        {
            // Haha loot!
            var entity = SpawnLoot(uid, harvester.Rift, harvester);
            if (entity == null)
                continue;

            EnsureComp<BluespaceHarvesterRiftComponent>((EntityUid) entity).Danger = currentDanger / count;
        }

        // We gave all the danger to the rifts.
        harvester.Danger = 0;
    }
}
