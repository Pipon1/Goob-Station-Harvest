// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Goobstation.Shared.EntityEffects;
using Robust.Shared.GameStates;

namespace Content.Goobstation.Shared.Actions;

/// <summary>
/// Conditions that must be met for an action to be usable.
/// </summary>
[RegisterComponent, NetworkedComponent]
public sealed partial class ActionConditionsComponent : Component
{
    /// <summary>
    /// Conditions that must pass for the action to be valid.
    /// </summary>
    [DataField]
    public List<string> Conditions = new();
}
