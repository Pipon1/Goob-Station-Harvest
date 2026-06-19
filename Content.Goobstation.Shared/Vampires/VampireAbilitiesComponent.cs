// SPDX-License-Identifier: AGPL-3.0-or-later

using Robust.Shared.GameObjects;
using Robust.Shared.GameStates;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.Vampires;

/// <summary>
/// Component that handles unlocking abilities for vampires.
/// </summary>
[RegisterComponent, NetworkedComponent]
[AutoGenerateComponentState]
public sealed partial class VampireAbilitiesComponent : Component
{
    /// <summary>
    /// The list of abilities we currently have unlocked.
    /// </summary>
    [DataField, AutoNetworkedField]
    public List<ProtoId<VampireAbilityPrototype>> UnlockedAbilities = new();
}
