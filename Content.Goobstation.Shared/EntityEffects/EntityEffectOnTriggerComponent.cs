// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.EntityEffects;
using Robust.Shared.GameStates;

namespace Content.Goobstation.Shared.EntityEffects;

/// <summary>
/// Applies entity effects when triggered (e.g., on collision, activation, etc.)
/// </summary>
[RegisterComponent, NetworkedComponent]
public sealed partial class EntityEffectOnTriggerComponent : Component
{
    [DataField]
    public List<EntityEffect> Effects = new();
}
