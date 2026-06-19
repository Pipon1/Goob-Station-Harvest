// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Goobstation.Shared.Vampires.Dantalion;
using Content.Shared.EntityEffects;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

[UsedImplicitly]
public sealed partial class AdjustVampireThralls : EntityEffect
{
    [DataField]
    public int Amount = 1;

    protected override string? ReagentEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => null;

    public override void Effect(EntityEffectBaseArgs args)
    {
        if (!args.EntityManager.TryGetComponent<VampireThrallsComponent>(args.TargetEntity, out var thralls))
            return;

        thralls.ThrallCap += Amount;
        args.EntityManager.Dirty(args.TargetEntity, thralls);
    }
}
