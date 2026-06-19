// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.EntityEffects;
using Robust.Shared.GameStates;

namespace Content.Goobstation.Shared.StatusEffects;

/// <summary>
/// Applies effects when a status effect is applied or removed.
/// </summary>
[RegisterComponent, NetworkedComponent]
public sealed partial class StatusEffectEffectsApplyComponent : Component
{
    /// <summary>
    /// Effects to apply when the status effect is applied.
    /// </summary>
    [DataField]
    public List<EntityEffect> EffectsOnApply = new();

    /// <summary>
    /// Effects to apply when the status effect is removed.
    /// </summary>
    [DataField]
    public List<EntityEffect> EffectsOnRemoval = new();
}
