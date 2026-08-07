// SPDX-License-Identifier: AGPL-3.0-or-later

using System.Linq;
using Content.Shared.Actions;
using Content.Shared.Actions.Components;
using Content.Shared.EntityEffects;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

[UsedImplicitly]
public sealed partial class RemoveActions : EntityEffectBase<RemoveActions>
{
    [DataField(required: true)]
    public List<EntProtoId> Actions = new();

    public override string? EntityEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => null;
}

public sealed partial class RemoveActionsSystem : EntityEffectSystem<ActionsComponent, RemoveActions>
{
    [Dependency] private readonly SharedActionsSystem _actions = default!;

    protected override void Effect(Entity<ActionsComponent> entity, ref EntityEffectEvent<RemoveActions> args)
    {
        foreach (var actionEnt in entity.Comp.Actions.ToList())
        {
            if (!TryComp<ActionComponent>(actionEnt, out var actionComponent))
                continue;

            var meta = EntityManager.GetComponent<MetaDataComponent>(actionEnt);
            if (meta.EntityPrototype == null)
                continue;

            foreach (var actionProto in args.Effect.Actions)
            {
                if (actionProto != meta.EntityPrototype.ID)
                    continue;

                _actions.RemoveAction((actionEnt, actionComponent));
                break;
            }
        }
    }
}
