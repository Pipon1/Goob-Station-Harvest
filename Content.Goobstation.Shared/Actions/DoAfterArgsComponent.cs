// SPDX-License-Identifier: AGPL-3.0-or-later

using Robust.Shared.GameStates;

namespace Content.Goobstation.Shared.Actions;

/// <summary>
/// DoAfter configuration for actions.
/// </summary>
[RegisterComponent, NetworkedComponent]
public sealed partial class DoAfterArgsComponent : Component
{
    /// <summary>
    /// Delay in seconds.
    /// </summary>
    [DataField]
    public float Delay = 1.0f;

    /// <summary>
    /// Whether the action breaks on movement.
    /// </summary>
    [DataField]
    public bool BreakOnMove = true;
}
