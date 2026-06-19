// SPDX-FileCopyrightText: 2025 GoobBot <uristmchands@proton.me>
// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.EntityEffects;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects.EffectConditions;

public sealed partial class OnGridCondition : EntityEffectCondition
{
    public override bool Condition(EntityEffectBaseArgs args)
    {
        var xform = args.EntityManager.GetComponent<TransformComponent>(args.TargetEntity);
        return xform.GridUid is { } gridUid && gridUid.IsValid();
    }

    public override string GuidebookExplanation(IPrototypeManager prototype)
    {
        return "TODO";
    }
}
