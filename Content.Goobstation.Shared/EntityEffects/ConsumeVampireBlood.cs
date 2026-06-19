// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Goobstation.Shared.Vampires;
using Content.Shared.EntityEffects;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

[UsedImplicitly]
public sealed partial class ConsumeVampireBlood : EntityEffect
{
    [DataField]
    public int Amount = 1;

    protected override string? ReagentEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => null;

    public override void Effect(EntityEffectBaseArgs args)
    {
        var vampireSystem = args.EntityManager.System<SharedVampireSystem>();
        vampireSystem.SubtractUsableBlood((args.TargetEntity, null), Amount);
    }
}
