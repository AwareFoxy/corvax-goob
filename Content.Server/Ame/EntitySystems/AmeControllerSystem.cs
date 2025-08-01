// SPDX-FileCopyrightText: 2023 DrSmugleaf <DrSmugleaf@users.noreply.github.com>
// SPDX-FileCopyrightText: 2023 TemporalOroboros <TemporalOroboros@gmail.com>
// SPDX-FileCopyrightText: 2023 Vasilis <vasilis@pikachu.systems>
// SPDX-FileCopyrightText: 2023 daerSeebaer <61566539+daerSeebaer@users.noreply.github.com>
// SPDX-FileCopyrightText: 2024 12rabbits <53499656+12rabbits@users.noreply.github.com>
// SPDX-FileCopyrightText: 2024 Alzore <140123969+Blackern5000@users.noreply.github.com>
// SPDX-FileCopyrightText: 2024 ArtisticRoomba <145879011+ArtisticRoomba@users.noreply.github.com>
// SPDX-FileCopyrightText: 2024 Brandon Hu <103440971+Brandon-Huu@users.noreply.github.com>
// SPDX-FileCopyrightText: 2024 Chief-Engineer <119664036+Chief-Engineer@users.noreply.github.com>
// SPDX-FileCopyrightText: 2024 Cojoke <83733158+Cojoke-dot@users.noreply.github.com>
// SPDX-FileCopyrightText: 2024 Dimastra <65184747+Dimastra@users.noreply.github.com>
// SPDX-FileCopyrightText: 2024 Dimastra <dimastra@users.noreply.github.com>
// SPDX-FileCopyrightText: 2024 Ed <96445749+TheShuEd@users.noreply.github.com>
// SPDX-FileCopyrightText: 2024 Emisse <99158783+Emisse@users.noreply.github.com>
// SPDX-FileCopyrightText: 2024 Eoin Mcloughlin <helloworld@eoinrul.es>
// SPDX-FileCopyrightText: 2024 IProduceWidgets <107586145+IProduceWidgets@users.noreply.github.com>
// SPDX-FileCopyrightText: 2024 JIPDawg <51352440+JIPDawg@users.noreply.github.com>
// SPDX-FileCopyrightText: 2024 JIPDawg <JIPDawg93@gmail.com>
// SPDX-FileCopyrightText: 2024 LordCarve <27449516+LordCarve@users.noreply.github.com>
// SPDX-FileCopyrightText: 2024 Mervill <mervills.email@gmail.com>
// SPDX-FileCopyrightText: 2024 Moomoobeef <62638182+Moomoobeef@users.noreply.github.com>
// SPDX-FileCopyrightText: 2024 Nemanja <98561806+EmoGarbage404@users.noreply.github.com>
// SPDX-FileCopyrightText: 2024 PJBot <pieterjan.briers+bot@gmail.com>
// SPDX-FileCopyrightText: 2024 Pieter-Jan Briers <pieterjan.briers+git@gmail.com>
// SPDX-FileCopyrightText: 2024 Pieter-Jan Briers <pieterjan.briers@gmail.com>
// SPDX-FileCopyrightText: 2024 Piras314 <p1r4s@proton.me>
// SPDX-FileCopyrightText: 2024 PopGamer46 <yt1popgamer@gmail.com>
// SPDX-FileCopyrightText: 2024 PursuitInAshes <pursuitinashes@gmail.com>
// SPDX-FileCopyrightText: 2024 QueerNB <176353696+QueerNB@users.noreply.github.com>
// SPDX-FileCopyrightText: 2024 Saphire Lattice <lattice@saphi.re>
// SPDX-FileCopyrightText: 2024 Sergey Dikiy <siarhei.dziki@gmail.com>
// SPDX-FileCopyrightText: 2024 ShadowCommander <10494922+ShadowCommander@users.noreply.github.com>
// SPDX-FileCopyrightText: 2024 Simon <63975668+Simyon264@users.noreply.github.com>
// SPDX-FileCopyrightText: 2024 Spessmann <156740760+Spessmann@users.noreply.github.com>
// SPDX-FileCopyrightText: 2024 Thomas <87614336+Aeshus@users.noreply.github.com>
// SPDX-FileCopyrightText: 2024 Winkarst <74284083+Winkarst-cpu@users.noreply.github.com>
// SPDX-FileCopyrightText: 2024 deltanedas <39013340+deltanedas@users.noreply.github.com>
// SPDX-FileCopyrightText: 2024 deltanedas <@deltanedas:kde.org>
// SPDX-FileCopyrightText: 2024 eoineoineoin <github@eoinrul.es>
// SPDX-FileCopyrightText: 2024 github-actions[bot] <41898282+github-actions[bot]@users.noreply.github.com>
// SPDX-FileCopyrightText: 2024 lzk <124214523+lzk228@users.noreply.github.com>
// SPDX-FileCopyrightText: 2024 metalgearsloth <31366439+metalgearsloth@users.noreply.github.com>
// SPDX-FileCopyrightText: 2024 slarticodefast <161409025+slarticodefast@users.noreply.github.com>
// SPDX-FileCopyrightText: 2024 stellar-novas <stellar_novas@riseup.net>
// SPDX-FileCopyrightText: 2024 themias <89101928+themias@users.noreply.github.com>
// SPDX-FileCopyrightText: 2025 Aiden <28298836+Aidenkrz@users.noreply.github.com>
//
// SPDX-License-Identifier: AGPL-3.0-or-later

using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Content.Server.Administration.Logs;
using Content.Server.Ame.Components;
using Content.Server.NodeContainer;
using Content.Server.Power.Components;
using Content.Shared.Ame.Components;
using Content.Shared.Containers.ItemSlots;
using Content.Shared.Database;
using Content.Shared.Mind.Components;
using Content.Shared.NodeContainer;
using Content.Shared.Power;
using Robust.Server.GameObjects;
using Robust.Shared.Audio;
using Robust.Shared.Audio.Systems;
using Robust.Shared.Containers;
using Robust.Shared.Timing;

namespace Content.Server.Ame.EntitySystems;

public sealed class AmeControllerSystem : EntitySystem
{
    [Dependency] private readonly IAdminLogManager _adminLogger = default!;
    [Dependency] private readonly IGameTiming _gameTiming = default!;
    [Dependency] private readonly AppearanceSystem _appearanceSystem = default!;
    [Dependency] private readonly SharedAudioSystem _audioSystem = default!;
    [Dependency] private readonly UserInterfaceSystem _userInterfaceSystem = default!;
    [Dependency] private readonly ItemSlotsSystem _itemSlots = default!;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<AmeControllerComponent, ComponentInit>(OnInit);
        SubscribeLocalEvent<AmeControllerComponent, ComponentRemove>(OnRemove);
        SubscribeLocalEvent<AmeControllerComponent, EntInsertedIntoContainerMessage>(OnItemSlotChanged);
        SubscribeLocalEvent<AmeControllerComponent, EntRemovedFromContainerMessage>(OnItemSlotChanged);
        SubscribeLocalEvent<AmeControllerComponent, PowerChangedEvent>(OnPowerChanged);
        SubscribeLocalEvent<AmeControllerComponent, UiButtonPressedMessage>(OnUiButtonPressed);
    }

    private void OnInit(EntityUid uid, AmeControllerComponent component, ComponentInit args)
    {
        _itemSlots.AddItemSlot(uid, SharedAmeControllerComponent.FuelSlotId, component.FuelSlot);

        UpdateUi(uid, component);
    }

    public override void Update(float frameTime)
    {
        var curTime = _gameTiming.CurTime;
        var query = EntityQueryEnumerator<AmeControllerComponent, NodeContainerComponent>();
        while (query.MoveNext(out var uid, out var controller, out var nodes))
        {
            if (controller.NextUpdate <= curTime)
                UpdateController(uid, curTime, controller, nodes);
            else if (controller.NextUIUpdate <= curTime)
                UpdateUi(uid, controller);
        }
    }

    private void OnRemove(EntityUid uid, AmeControllerComponent component, ComponentRemove args)
    {
        _itemSlots.RemoveItemSlot(uid, component.FuelSlot);
    }

    private void OnItemSlotChanged(EntityUid uid, AmeControllerComponent component, ContainerModifiedMessage args)
    {
        if (!component.Initialized)
            return;

        if (args.Container.ID != component.FuelSlot.ID)
            return;

        UpdateUi(uid, component);
    }

    private void UpdateController(EntityUid uid, TimeSpan curTime, AmeControllerComponent? controller = null, NodeContainerComponent? nodes = null)
    {
        if (!Resolve(uid, ref controller))
            return;

        controller.LastUpdate = curTime;
        controller.NextUpdate = curTime + controller.UpdatePeriod;
        // update the UI regardless of other factors to update the power readings
        UpdateUi(uid, controller);

        if (!controller.Injecting)
            return;

        if (!TryGetAMENodeGroup(uid, out var group, nodes))
            return;

        if (TryComp<AmeFuelContainerComponent>(controller.FuelSlot.Item, out var fuelContainer))
        {
            // if the jar is empty shut down the AME
            if (fuelContainer.FuelAmount <= 0)
            {
                SetInjecting(uid, false, null, controller);
            }
            else
            {
                var availableInject = Math.Min(controller.InjectionAmount, fuelContainer.FuelAmount);
                var powerOutput = group.InjectFuel(availableInject, out var overloading);
                if (TryComp<PowerSupplierComponent>(uid, out var powerOutlet))
                    powerOutlet.MaxSupply = powerOutput;
                fuelContainer.FuelAmount -= availableInject;
                // only play audio if we actually had an injection
                if (availableInject > 0)
                    _audioSystem.PlayPvs(controller.InjectSound, uid, AudioParams.Default.WithVolume(overloading ? 10f : 0f));
                UpdateUi(uid, controller);
            }
        }

        controller.Stability = group.GetTotalStability();

        group.UpdateCoreVisuals();
        UpdateDisplay(uid, controller.Stability, controller);

        if (controller.Stability <= 0)
            group.ExplodeCores();
    }

    public void UpdateUi(EntityUid uid, AmeControllerComponent? controller = null)
    {
        if (!Resolve(uid, ref controller))
            return;

        if (!_userInterfaceSystem.HasUi(uid, AmeControllerUiKey.Key))
            return;

        var state = GetUiState(uid, controller);
        _userInterfaceSystem.SetUiState(uid, AmeControllerUiKey.Key, state);

        controller.NextUIUpdate = _gameTiming.CurTime + controller.UpdateUIPeriod;
    }

    private AmeControllerBoundUserInterfaceState GetUiState(EntityUid uid, AmeControllerComponent controller)
    {
        var powered = !TryComp<ApcPowerReceiverComponent>(uid, out var powerSource) || powerSource.Powered;
        var coreCount = 0;
        // how much power can be produced at the current settings, in kW
        // we don't use max. here since this is what is set in the Controller, not what the AME is actually producing
        float targetedPowerSupply = 0;
        if (TryGetAMENodeGroup(uid, out var group))
        {
            coreCount = group.CoreCount;
            targetedPowerSupply = group.CalculatePower(controller.InjectionAmount, group.CoreCount) / 1000;
        }

        // set current power statistics in kW
        float currentPowerSupply = 0;
        if (TryComp<PowerSupplierComponent>(uid, out var powerOutlet) && coreCount > 0)
        {
            currentPowerSupply = powerOutlet.CurrentSupply / 1000;
        }

        var fuelContainerInSlot = controller.FuelSlot.Item;
        var hasFuelContainerInSlot = Exists(fuelContainerInSlot);
        if (!hasFuelContainerInSlot || !TryComp<AmeFuelContainerComponent>(fuelContainerInSlot, out var fuelContainer))
            return new AmeControllerBoundUserInterfaceState(powered,
                                                            IsMasterController(uid),
                                                            false,
                                                            hasFuelContainerInSlot,
                                                            0,
                                                            controller.InjectionAmount,
                                                            coreCount,
                                                            currentPowerSupply,
                                                            targetedPowerSupply);

        return new AmeControllerBoundUserInterfaceState(powered,
                                                        IsMasterController(uid),
                                                        controller.Injecting,
                                                        hasFuelContainerInSlot,
                                                        fuelContainer.FuelAmount,
                                                        controller.InjectionAmount,
                                                        coreCount,
                                                        currentPowerSupply,
                                                        targetedPowerSupply);
    }

    private bool IsMasterController(EntityUid uid)
    {
        return TryGetAMENodeGroup(uid, out var group) && group.MasterController == uid;
    }

    private bool TryGetAMENodeGroup(EntityUid uid, [MaybeNullWhen(false)] out AmeNodeGroup group, NodeContainerComponent? nodes = null)
    {
        if (!Resolve(uid, ref nodes))
        {
            group = null;
            return false;
        }

        group = nodes.Nodes.Values
            .Select(node => node.NodeGroup)
            .OfType<AmeNodeGroup>()
            .FirstOrDefault();

        return group != null;
    }

    public void TryEject(EntityUid uid, EntityUid? user = null, AmeControllerComponent? controller = null)
    {
        if (!Resolve(uid, ref controller))
            return;

        if (controller.Injecting)
            return;

        if (!Exists(controller.FuelSlot.Item))
            return;

        _itemSlots.TryEjectToHands(uid, controller.FuelSlot, user);

        UpdateUi(uid, controller);
    }

    public void SetInjecting(EntityUid uid, bool value, EntityUid? user = null, AmeControllerComponent? controller = null)
    {
        if (!Resolve(uid, ref controller))
            return;

        if (controller.Injecting == value)
            return;

        controller.Injecting = value;
        UpdateDisplay(uid, controller.Stability, controller);
        if (!value && TryComp<PowerSupplierComponent>(uid, out var powerOut))
            powerOut.MaxSupply = 0;

        UpdateUi(uid, controller);

        _itemSlots.SetLock(uid, controller.FuelSlot, value);

        // Logging
        if (!HasComp<MindContainerComponent>(user))
            return;

        var humanReadableState = value ? "Inject" : "Not inject";
        _adminLogger.Add(LogType.Action, LogImpact.Medium, $"{EntityManager.ToPrettyString(user.Value):player} has set the AME to {humanReadableState}");
    }

    public void ToggleInjecting(EntityUid uid, EntityUid? user = null, AmeControllerComponent? controller = null)
    {
        if (!Resolve(uid, ref controller))
            return;
        SetInjecting(uid, !controller.Injecting, user, controller);
    }

    public void SetInjectionAmount(EntityUid uid, int value, EntityUid? user = null, AmeControllerComponent? controller = null)
    {
        if (!Resolve(uid, ref controller))
            return;
        if (controller.InjectionAmount == value)
            return;

        var oldValue = controller.InjectionAmount;
        controller.InjectionAmount = value;

        UpdateUi(uid, controller);

        // Logging
        if (!TryComp<MindContainerComponent>(user, out var mindContainer))
            return;

        var humanReadableState = controller.Injecting ? "Inject" : "Not inject";


        var safeLimit = int.MaxValue;
        if (TryGetAMENodeGroup(uid, out var group))
            safeLimit = group.CoreCount * 4;

        var logImpact = (oldValue <= safeLimit && value > safeLimit) ? LogImpact.Extreme : LogImpact.Medium;

        _adminLogger.Add(LogType.Action, logImpact, $"{EntityManager.ToPrettyString(user.Value):player} has set the AME to inject {controller.InjectionAmount} while set to {humanReadableState}");
    }

    public void AdjustInjectionAmount(EntityUid uid, int delta, EntityUid? user = null, AmeControllerComponent? controller = null)
    {
        if (!Resolve(uid, ref controller))
            return;

        var max = GetMaxInjectionAmount((uid, controller));
        SetInjectionAmount(uid, MathHelper.Clamp(controller.InjectionAmount + delta, 0, max), user, controller);
    }

    public int GetMaxInjectionAmount(Entity<AmeControllerComponent> ent)
    {
        if (!TryGetAMENodeGroup(ent, out var group))
            return 0;
        return  group.CoreCount * 8;
    }

    private void UpdateDisplay(EntityUid uid, int stability, AmeControllerComponent? controller = null, AppearanceComponent? appearance = null)
    {
        if (!Resolve(uid, ref controller, ref appearance))
            return;

        var ameControllerState = stability switch
        {
            < 10 => AmeControllerState.Fuck,
            < 50 => AmeControllerState.Critical,
            < 80 => AmeControllerState.Warning,
            _ => AmeControllerState.On,
        };

        if (!controller.Injecting)
            ameControllerState = AmeControllerState.Off;

        _appearanceSystem.SetData(
            uid,
            AmeControllerVisuals.DisplayState,
            ameControllerState,
            appearance
        );
    }

    private void OnPowerChanged(EntityUid uid, AmeControllerComponent comp, ref PowerChangedEvent args)
    {
        UpdateUi(uid, comp);
    }

    private void OnUiButtonPressed(EntityUid uid, AmeControllerComponent comp, UiButtonPressedMessage msg)
    {
        var user = msg.Actor;
        if (!Exists(user))
            return;

        var needsPower = msg.Button switch
        {
            UiButton.Eject => false,
            _ => true,
        };

        if (!PlayerCanUseController(uid, user, needsPower, comp))
            return;

        _audioSystem.PlayPvs(comp.ClickSound, uid, AudioParams.Default.WithVolume(-2f));
        switch (msg.Button)
        {
            case UiButton.Eject:
                TryEject(uid, user: user, controller: comp);
                break;
            case UiButton.ToggleInjection:
                ToggleInjecting(uid, user: user, controller: comp);
                break;
            case UiButton.IncreaseFuel:
                AdjustInjectionAmount(uid, +2, user: user, controller: comp);
                break;
            case UiButton.DecreaseFuel:
                AdjustInjectionAmount(uid, -2, user: user, controller: comp);
                break;
        }

        if (TryGetAMENodeGroup(uid, out var group))
            group.UpdateCoreVisuals();

        UpdateUi(uid, comp);
    }

    /// <summary>
    /// Checks whether the player entity is able to use the controller.
    /// </summary>
    /// <param name="playerEntity">The player entity.</param>
    /// <returns>Returns true if the entity can use the controller, and false if it cannot.</returns>
    private bool PlayerCanUseController(EntityUid uid, EntityUid playerEntity, bool needsPower = true, AmeControllerComponent? controller = null)
    {
        if (!Resolve(uid, ref controller))
            return false;

        //Need player entity to check if they are still able to use the dispenser
        if (!Exists(playerEntity))
            return false;

        //Check if device is powered
        if (needsPower && TryComp<ApcPowerReceiverComponent>(uid, out var powerSource) && !powerSource.Powered)
            return false;

        return true;
    }
}