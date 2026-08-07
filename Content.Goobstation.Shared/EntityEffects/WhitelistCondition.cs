// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.EntityConditions;
using Content.Shared.Whitelist;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

[UsedImplicitly]
public sealed partial class WhitelistCondition : EntityConditionBase<WhitelistCondition>
{
    [DataField]
    public EntityWhitelist? Whitelist;

    [DataField]
    public EntityWhitelist? Blacklist;

    public override string EntityConditionGuidebookText(IPrototypeManager prototype)
    {
        return Loc.GetString("reagent-effect-condition-guidebook-whitelist");
    }
}

public sealed partial class WhitelistConditionSystem : EntityConditionSystem<MetaDataComponent, WhitelistCondition>
{
    [Dependency] private readonly EntityWhitelistSystem _whitelist = default!;

    protected override void Condition(Entity<MetaDataComponent> entity, ref EntityConditionEvent<WhitelistCondition> args)
    {
        args.Result = _whitelist.CheckBoth(entity.Owner, args.Condition.Blacklist, args.Condition.Whitelist);
    }
}
