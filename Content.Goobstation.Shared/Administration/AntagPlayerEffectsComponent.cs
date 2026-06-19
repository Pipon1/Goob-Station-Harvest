// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.EntityEffects;
using Robust.Shared.GameStates;

namespace Content.Goobstation.Shared.Administration;

/// <summary>
/// Applies effects to players when they become this antag type.
/// </summary>
[RegisterComponent, NetworkedComponent]
public sealed partial class AntagPlayerEffectsComponent : Component
{
    /// <summary>
    /// Effects to apply when the player becomes this antag.
    /// </summary>
    [DataField]
    public List<EntityEffect> Effects = new();
}
