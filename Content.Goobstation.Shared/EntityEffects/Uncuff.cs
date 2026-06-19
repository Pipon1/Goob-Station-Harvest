// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.Cuffs;
using Content.Shared.Cuffs.Components;
using Content.Shared.EntityEffects;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

[UsedImplicitly]
public sealed partial class Uncuff : EntityEffect
{
    protected override string? ReagentEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => null;

    public override void Effect(EntityEffectBaseArgs args)
    {
        if (!args.EntityManager.TryGetComponent<CuffableComponent>(args.TargetEntity, out var cuffable))
            return;

        if (cuffable.Container.ContainedEntities.Count == 0)
            return;

        var cuffableSystem = args.EntityManager.System<SharedCuffableSystem>();
        cuffableSystem.Uncuff(args.TargetEntity, args.TargetEntity, cuffable.LastAddedCuffs, cuffable);
    }
}
