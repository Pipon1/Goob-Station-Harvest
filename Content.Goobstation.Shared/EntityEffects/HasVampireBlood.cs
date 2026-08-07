// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Goobstation.Shared.Vampires;
using Content.Shared.EntityConditions;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

[UsedImplicitly]
public sealed partial class HasVampireBlood : EntityConditionBase<HasVampireBlood>
{
    [DataField]
    public int Amount = 1;

    public override string EntityConditionGuidebookText(IPrototypeManager prototype)
    {
        return Loc.GetString("reagent-effect-condition-guidebook-has-vampire-blood", ("amount", Amount));
    }
}

public sealed partial class HasVampireBloodSystem : EntityConditionSystem<VampireComponent, HasVampireBlood>
{
    [Dependency] private readonly SharedVampireSystem _vampire = default!;

    protected override void Condition(Entity<VampireComponent> entity, ref EntityConditionEvent<HasVampireBlood> args)
    {
        args.Result = _vampire.HasUsableBlood(entity.AsNullable(), args.Condition.Amount);
    }
}
