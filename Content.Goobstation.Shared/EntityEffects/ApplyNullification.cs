// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Goobstation.Shared.Vampires;
using Content.Shared.EntityEffects;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

[UsedImplicitly]
public sealed partial class ApplyNullification : EntityEffect
{
    [DataField]
    public int Amount = 1;

    protected override string? ReagentEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => null;

    public override void Effect(EntityEffectBaseArgs args)
    {
        if (!args.EntityManager.TryGetComponent<NullificationComponent>(args.TargetEntity, out var nullification))
            return;

        nullification.Amount += Amount;
        args.EntityManager.Dirty(args.TargetEntity, nullification);
    }
}
