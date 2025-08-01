// SPDX-FileCopyrightText: 2025 Aiden <28298836+Aidenkrz@users.noreply.github.com>
// SPDX-FileCopyrightText: 2025 GoobBot <uristmchands@proton.me>
// SPDX-FileCopyrightText: 2025 Ilya246 <57039557+Ilya246@users.noreply.github.com>
// SPDX-FileCopyrightText: 2025 Ilya246 <ilyukarno@gmail.com>
// SPDX-FileCopyrightText: 2025 IrisTheAmped <iristheamped@gmail.com>
// SPDX-FileCopyrightText: 2025 Rinary <72972221+Rinary1@users.noreply.github.com>
//
// SPDX-License-Identifier: AGPL-3.0-or-later

using Robust.Shared.GameStates;
using Robust.Shared.Prototypes;

namespace Content.Shared._Starlight.CollectiveMind
{
    [RegisterComponent, NetworkedComponent]
    public sealed partial class CollectiveMindComponent : Component
    {
        [DataField("minds")]
        public Dictionary<string, int> Minds = new();

        [DataField]
        public ProtoId<CollectiveMindPrototype>? DefaultChannel = null;

        [DataField]
        public HashSet<ProtoId<CollectiveMindPrototype>> Channels = new();

        [DataField]
        public bool HearAll = false;

        [DataField]
        public bool SeeAllNames = false;

        [DataField]
        public bool RespectAccents = false;
    }
}
