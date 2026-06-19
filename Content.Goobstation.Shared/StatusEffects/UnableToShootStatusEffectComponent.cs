// SPDX-License-Identifier: AGPL-3.0-or-later

using Robust.Shared.GameStates;

namespace Content.Goobstation.Shared.StatusEffects;

/// <summary>
/// Status effect that prevents the entity from shooting.
/// </summary>
[RegisterComponent, NetworkedComponent]
public sealed partial class UnableToShootStatusEffectComponent : Component
{
}
