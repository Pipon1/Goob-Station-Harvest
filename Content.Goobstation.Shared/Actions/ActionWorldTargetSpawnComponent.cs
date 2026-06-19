// SPDX-License-Identifier: AGPL-3.0-or-later

using Robust.Shared.GameStates;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.Actions;

/// <summary>
/// Spawns entities at world target locations.
/// </summary>
[RegisterComponent, NetworkedComponent]
public sealed partial class ActionWorldTargetSpawnComponent : Component
{
    /// <summary>
    /// The prototype to spawn.
    /// </summary>
    [DataField(required: true)]
    public EntProtoId SpawnPrototype = default!;

    /// <summary>
    /// Size of the spawn pattern (e.g., 2,2 for 3x3 grid).
    /// </summary>
    [DataField]
    public string Size = "1,1";
}
