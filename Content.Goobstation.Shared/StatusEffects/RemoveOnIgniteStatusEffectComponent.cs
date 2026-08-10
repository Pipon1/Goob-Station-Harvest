// SPDX-License-Identifier: AGPL-3.0-or-later

using Robust.Shared.GameStates;

namespace Content.Goobstation.Shared.StatusEffects;

/// <summary>
/// Removes the status effect when the entity is ignited.
/// </summary>
[RegisterComponent, NetworkedComponent]
public sealed partial class RemoveOnIgniteStatusEffectComponent : Component
{
}
