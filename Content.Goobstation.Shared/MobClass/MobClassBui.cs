// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.Actions;
using Robust.Shared.Prototypes;
using Robust.Shared.Serialization;

namespace Content.Goobstation.Shared.MobClass;

/// <summary>
/// For use with actions, opens the class selector ui.
/// </summary>
public sealed partial class OpenClassSelectorUiEvent : InstantActionEvent;

[Serializable, NetSerializable]
public sealed class MobClassSelectedMessage : BoundUserInterfaceMessage
{
    /// <summary>
    /// The class we selected to specialize in.
    /// </summary>
    public ProtoId<MobClassPrototype> ClassProto;

    public MobClassSelectedMessage(ProtoId<MobClassPrototype> classProto)
    {
        ClassProto = classProto;
    }
}

[Serializable, NetSerializable]
public sealed class MobClassState : BoundUserInterfaceState
{
    /// <summary>
    /// The classes to display to the user.
    /// </summary>
    public ProtoId<MobClassGroupPrototype> Group;

    public MobClassState(ProtoId<MobClassGroupPrototype> groupProto)
    {
        Group = groupProto;
    }
}

[Serializable, NetSerializable]
public enum MobClassUiKey : byte
{
    Key
}
