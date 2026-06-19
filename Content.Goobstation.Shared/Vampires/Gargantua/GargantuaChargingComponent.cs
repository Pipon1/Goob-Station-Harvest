// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Goobstation.Shared.EntityEffects;
using Robust.Shared.GameStates;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.Vampires.Gargantua;

/// <summary>
/// Component applied to a Gargantua Vampire during a charge action.
/// Applies entity effects on collision with other entities, and gets removed during a landing event.
/// </summary>
[RegisterComponent, NetworkedComponent]
[AutoGenerateComponentState]
public sealed partial class GargantuaChargingComponent : Component
{
    /// <summary>
    /// The effect to run on targets we collided with
    /// </summary>
    [DataField(required: true), AutoNetworkedField]
    public ProtoId<EntityEffectPrototype> Effect = default!;
}
