// SPDX-License-Identifier: AGPL-3.0-or-later

using Robust.Shared.GameStates;

namespace Content.Goobstation.Shared.Projectiles;

/// <summary>
/// Modifies status effects on the target when projectile hits.
/// </summary>
[RegisterComponent, NetworkedComponent]
public sealed partial class ProjectileModifyStatusEffectComponent : Component
{
    /// <summary>
    /// The status effect to modify.
    /// </summary>
    [DataField(required: true)]
    public string EffectProto = string.Empty;

    /// <summary>
    /// Time to add to the status effect. If null, removes the effect.
    /// </summary>
    [DataField]
    public float? Time;

    /// <summary>
    /// Whether to add or remove the effect.
    /// </summary>
    [DataField]
    public string Type = "Add";
}
