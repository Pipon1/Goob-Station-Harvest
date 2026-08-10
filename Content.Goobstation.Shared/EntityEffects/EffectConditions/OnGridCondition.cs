// SPDX-FileCopyrightText: 2025 GoobBot <uristmchands@proton.me>
// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.EntityConditions;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects.EffectConditions;

public sealed partial class OnGridCondition : EntityConditionBase<OnGridCondition>
{
    public override string EntityConditionGuidebookText(IPrototypeManager prototype) => String.Empty;
}

public sealed partial class OnGridConditionSystem : EntityConditionSystem<TransformComponent, OnGridCondition>
{
    protected override void Condition(Entity<TransformComponent> entity, ref EntityConditionEvent<OnGridCondition> args)
    {
        args.Result = entity.Comp.GridUid is { } gridUid && gridUid.IsValid();
    }
}
