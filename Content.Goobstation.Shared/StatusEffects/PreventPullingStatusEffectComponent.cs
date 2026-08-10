// SPDX-License-Identifier: AGPL-3.0-or-later

using Robust.Shared.GameStates;

namespace Content.Goobstation.Shared.StatusEffects;

/// <summary>
/// Prevents the entity from pulling while this status effect is active.
/// </summary>
[RegisterComponent, NetworkedComponent]
public sealed partial class PreventPullingStatusEffectComponent : Component
{
}
