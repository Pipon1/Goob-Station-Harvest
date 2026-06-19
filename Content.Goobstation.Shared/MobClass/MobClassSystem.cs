// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.Actions;
using Content.Shared.Administration.Logs;
using Content.Shared.Database;
using Content.Shared.EntityEffects;
using Robust.Shared.Network;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.MobClass;

/// <summary>
/// Public Api for mob classes. Also, handles BUI events.
/// TODO: if this gets more complex than a simple specialization, support changing classes
/// </summary>
public sealed partial class MobClassSystem : EntitySystem
{
    [Dependency] private IPrototypeManager _proto = default!;
    [Dependency] private ISharedAdminLogManager _admin = default!;
    [Dependency] private SharedUserInterfaceSystem _ui = default!;
    [Dependency] private SharedEntityEffectSystem _effects = default!;
    [Dependency] private SharedActionsSystem _actions = default!;
    [Dependency] private INetManager _net = default!;
    // NOTE: EntityQuery dependency removed - using EntityManager.TryComp directly to avoid registration issues

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<OpenClassSelectorUiEvent>(OnOpenSelector);

        SubscribeLocalEvent<MobClassComponent, MobClassSelectedMessage>(OnClassSelected);
    }

    private void OnOpenSelector(OpenClassSelectorUiEvent args)
    {
        if (!_net.IsServer)
            return;

        var user = args.Performer;

        if (!TryComp<MobClassComponent>(user, out var mobClass) || !_proto.Resolve(mobClass.BelongsTo, out _))
            return;

        _ui.SetUiState(user, MobClassUiKey.Key, new MobClassState(mobClass.BelongsTo));
        _ui.TryToggleUi(user, MobClassUiKey.Key, user);
    }

    private void OnClassSelected(Entity<MobClassComponent> ent, ref MobClassSelectedMessage args)
    {
        var user = ent.Owner;

        EntityUid? actionEnt = null;
        foreach (var action in _actions.GetActions(user))
        {
            if (HasComp<ActionMobClassComponent>(action))
            {
                actionEnt = action.Owner;
                break;
            }
        }

        if (actionEnt == null)
            return;

        _ui.CloseUi(user, MobClassUiKey.Key);

        SelectClass(user, args.ClassProto);

        if (TryComp<ActionMobClassComponent>(actionEnt.Value, out var actionComp) && actionComp.RemoveOnSelected)
            _actions.RemoveAction(user, actionEnt.Value);
    }

    /// <summary>
    /// Selects a class to specialize in. Runs effect after selecting the class
    /// </summary>
    public void SelectClass(Entity<MobClassComponent?> ent, ProtoId<MobClassPrototype> classProto)
    {
        if (!Resolve(ent.Owner, ref ent.Comp, false) || ent.Comp.CurrentClass == classProto)
            return;

        // The class must match the mob class group we belong to, otherwise we can't specialize in it.
        if (!_proto.Resolve(ent.Comp.BelongsTo, out var mobGroup) || !mobGroup.Classes.Contains(classProto))
            return;

        if (!_proto.Resolve(classProto, out var mobClass))
            return;

        ent.Comp.CurrentClass = classProto;
        Dirty(ent);

        if (mobClass.Effects is { } effects)
        {
            foreach (var effect in effects)
                _effects.Effect(effect, new EntityEffectBaseArgs(ent.Owner, EntityManager));
        }

        var ev = new MobClassSelectedEvent();
        RaiseLocalEvent(ent.Owner, ref ev);

        _admin.Add(LogType.MobClass, LogImpact.High, $"User {ent.Owner} has gained the class {classProto} which belongs to {mobGroup}");
    }

    /// <summary>
    /// Gets the current selected class. Returns null if we don't have any.
    /// </summary>
    public ProtoId<MobClassPrototype>? GetClass(Entity<MobClassComponent?> ent)
    {
        if (!Resolve(ent.Owner, ref ent.Comp, false))
            return null;

        return ent.Comp.CurrentClass;
    }

    /// <summary>
    /// Gets the name of the class the entity currently belongs to.
    /// Returns "None" if no class has been selected.
    /// </summary>
    public string GetClassName(Entity<MobClassComponent?> ent)
    {
        if (!Resolve(ent.Owner, ref ent.Comp, false) || !_proto.Resolve(ent.Comp.CurrentClass, out var proto))
            return "None";

        return proto.Name;
    }
}

/// <summary>
/// Raised on the entity when a mob class has been selected.
/// </summary>
[ByRefEvent]
public record struct MobClassSelectedEvent;
