// SPDX-License-Identifier: AGPL-3.0-or-later

using Robust.Shared.GameObjects;
using Robust.Shared.GameStates;

namespace Content.Goobstation.Shared.Vampires;

/// <summary>
/// Tracks nullification level for vampires.
/// When nullification reaches 120, vampire abilities are restricted.
/// </summary>
[RegisterComponent, NetworkedComponent]
[AutoGenerateComponentState]
public sealed partial class NullificationComponent : Component
{
    /// <summary>
    /// Current nullification level.
    /// </summary>
    [DataField, AutoNetworkedField]
    public int Amount;

    /// <summary>
    /// Threshold at which abilities are restricted.
    /// </summary>
    [DataField]
    public int RestrictionThreshold = 120;
}
