// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.Damage;
using Robust.Shared.GameStates;

namespace Content.Goobstation.Shared.StatusEffects;

/// <summary>
/// Modifies incoming damage while this status effect is active.
/// </summary>
[RegisterComponent, NetworkedComponent]
public sealed partial class DamageModifierStatusEffectComponent : Component
{
    /// <summary>
    /// Damage modifiers to apply.
    /// </summary>
    [DataField]
    public DamageModifierSet Modifiers = new();
}
