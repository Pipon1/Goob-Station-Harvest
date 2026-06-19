// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.EntityEffects;
using Content.Shared.Whitelist;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

[UsedImplicitly]
public sealed partial class WhitelistCondition : EntityEffectCondition
{
    [DataField]
    public EntityWhitelist? Whitelist;

    [DataField]
    public EntityWhitelist? Blacklist;

    public override bool Condition(EntityEffectBaseArgs args)
    {
        var whitelistSystem = args.EntityManager.System<EntityWhitelistSystem>();
        return whitelistSystem.CheckBoth(args.TargetEntity, Blacklist, Whitelist);
    }

    public override string GuidebookExplanation(IPrototypeManager prototype)
    {
        return Loc.GetString("reagent-effect-condition-guidebook-whitelist");
    }
}
