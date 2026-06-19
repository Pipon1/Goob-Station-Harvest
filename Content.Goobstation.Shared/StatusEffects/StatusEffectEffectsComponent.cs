// SPDX-License-Identifier: AGPL-3.0-or-later

using System;
using Content.Shared.EntityEffects;
using Robust.Shared.GameStates;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom;

namespace Content.Goobstation.Shared.StatusEffects;

/// <summary>
/// Applies effects periodically while a status effect is active.
/// </summary>
[RegisterComponent, NetworkedComponent]
public sealed partial class StatusEffectEffectsComponent : Component
{
    /// <summary>
    /// Delay between effect updates in seconds.
    /// </summary>
    [DataField]
    public float UpdateDelay = 1f;

    /// <summary>
    /// Effects to apply each update.
    /// </summary>
    [DataField]
    public EntityEffect[] Effects = Array.Empty<EntityEffect>();

    /// <summary>
    /// Next time to update effects.
    /// </summary>
    [DataField(customTypeSerializer: typeof(TimeOffsetSerializer))]
    public TimeSpan NextUpdate;
}
