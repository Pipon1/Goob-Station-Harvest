// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.Alert;
using Robust.Shared.GameObjects;
using Robust.Shared.GameStates;

namespace Content.Goobstation.Shared.Vampires;

/// <summary>
/// Component that stores usable blood and total blood of a vampire.
/// </summary>
[RegisterComponent, NetworkedComponent]
[AutoGenerateComponentState]
public sealed partial class VampireComponent : Component
{
    /// <summary>
    ///  The blood we can use right now.
    ///
    ///  This is the blood that counts towards abilities that require it.
    /// </summary>
    [DataField, AutoNetworkedField]
    public int UsableBlood;

    /// <summary>
    ///  The total blood we have reached.
    ///  When using an action, we may lose <see cref="UsableBlood"/>, we don't lose our total blood.
    ///  This variable should not ever get decreased.
    ///
    ///  This is the variable that unlocks abilities.
    /// </summary>
    [DataField, AutoNetworkedField]
    public int TotalBlood;

    /// <summary>
    ///     The action entity for selecting vampire class.
    /// </summary>
    [DataField, AutoNetworkedField]
    public EntityUid? ClassSelectActionEntity;
}

/// <summary>
/// An alert event used to display your total and usable blood via a popup.
/// </summary>
public sealed partial class VampireBloodAlertEvent : BaseAlertEvent;
