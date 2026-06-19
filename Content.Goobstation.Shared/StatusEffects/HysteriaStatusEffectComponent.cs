// SPDX-License-Identifier: AGPL-3.0-or-later

using Robust.Shared.GameStates;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.StatusEffects;

/// <summary>
/// Status effect that makes you see everyone as objects.
/// </summary>
[RegisterComponent, NetworkedComponent]
public sealed partial class HysteriaStatusEffectComponent : Component
{
    /// <summary>
    /// The list of objects to choose from.
    /// </summary>
    [DataField]
    public List<EntProtoId> Disguises = new();
};
