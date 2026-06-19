// SPDX-License-Identifier: AGPL-3.0-or-later

using System.Linq;
using Content.Shared.Actions;
using Content.Shared.Actions.Components;
using Content.Shared.EntityEffects;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

[UsedImplicitly]
public sealed partial class RemoveActions : EntityEffect
{
    [DataField(required: true)]
    public List<EntProtoId> Actions = new();

    protected override string? ReagentEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => null;

    public override void Effect(EntityEffectBaseArgs args)
    {
        if (!args.EntityManager.TryGetComponent<ActionsComponent>(args.TargetEntity, out var actionsComp))
            return;

        var actionsSystem = args.EntityManager.System<SharedActionsSystem>();

        foreach (var actionEnt in actionsComp.Actions.ToList())
        {
            if (!args.EntityManager.TryGetComponent<ActionComponent>(actionEnt, out var actionComponent))
                continue;

            var meta = args.EntityManager.GetComponent<MetaDataComponent>(actionEnt);
            if (meta.EntityPrototype == null)
                continue;

            if (Actions.Contains(meta.EntityPrototype.ID))
            {
                actionsSystem.RemoveAction((actionEnt, actionComponent));
            }
        }
    }
}
