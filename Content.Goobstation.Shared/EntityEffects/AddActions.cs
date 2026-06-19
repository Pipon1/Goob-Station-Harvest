// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.Actions;
using Content.Shared.EntityEffects;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

[UsedImplicitly]
public sealed partial class AddActions : EntityEffect
{
    [DataField(required: true)]
    public List<EntProtoId> Actions = new();

    protected override string? ReagentEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => null;

    public override void Effect(EntityEffectBaseArgs args)
    {
        var actionsSystem = args.EntityManager.System<SharedActionsSystem>();

        foreach (var actionProto in Actions)
        {
            actionsSystem.AddAction(args.TargetEntity, actionProto);
        }
    }
}
