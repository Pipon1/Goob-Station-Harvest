// SPDX-License-Identifier: AGPL-3.0-or-later

using Robust.Shared.GameStates;

namespace Content.Goobstation.Shared.StatusEffects;

/// <summary>
/// Modifies stamina values while this status effect is active.
/// </summary>
[RegisterComponent, NetworkedComponent]
public sealed partial class StaminaModifierStatusEffectComponent : Component
{
    /// <summary>
    /// The modifier to apply to stamina.
    /// </summary>
    [DataField]
    public float Modifier = 1.0f;
}
