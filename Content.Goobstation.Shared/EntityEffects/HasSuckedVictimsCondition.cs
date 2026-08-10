// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Goobstation.Shared.Vampires;
using Content.Shared.EntityConditions;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

[UsedImplicitly]
public sealed partial class HasSuckedVictimsCondition : EntityConditionBase<HasSuckedVictimsCondition>
{
    [DataField]
    public int Amount = 1;

    public override string EntityConditionGuidebookText(IPrototypeManager prototype)
    {
        return Loc.GetString("reagent-effect-condition-guidebook-has-sucked-victims", ("amount", Amount));
    }
}

public sealed partial class HasSuckedVictimsConditionSystem : EntityConditionSystem<VampireBloodsuckingComponent, HasSuckedVictimsCondition>
{
    protected override void Condition(Entity<VampireBloodsuckingComponent> entity, ref EntityConditionEvent<HasSuckedVictimsCondition> args)
    {
        args.Result = entity.Comp.ConsumedVictims.Count >= args.Condition.Amount;
    }
}
