// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.EntityEffects;
using Robust.Shared.GameStates;

namespace Content.Goobstation.Shared.Weapons.Melee;

/// <summary>
/// Applies entity effects when this entity hits something with a melee attack.
/// </summary>
[RegisterComponent, NetworkedComponent]
public sealed partial class EffectsOnMeleeHitComponent : Component
{
    /// <summary>
    /// Conditions that must be met on the target for effects to apply.
    /// </summary>
    [DataField]
    public List<EntityEffectCondition> TargetConditions = new();

    /// <summary>
    /// Effects to apply to the user on melee hit.
    /// </summary>
    [DataField]
    public List<EntityEffect> UserEffects = new();

    /// <summary>
    /// Effects to apply to the target on melee hit.
    /// </summary>
    [DataField]
    public List<EntityEffect> TargetEffects = new();
}
