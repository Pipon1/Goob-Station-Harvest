// SPDX-FileCopyrightText: 2025 GoobBot <uristmchands@proton.me>
// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.EntityEffects;
using Robust.Shared.GameObjects;
using Robust.Shared.Map;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects.EffectConditions;

public sealed partial class AnyNearbyCondition : EntityEffectCondition
{
    [DataField]
    public string CompName = string.Empty;

    [DataField]
    public float Range = 1f;

    public override bool Condition(EntityEffectBaseArgs args)
    {
        if (string.IsNullOrEmpty(CompName))
            return false;

        var compFactory = args.EntityManager.ComponentFactory;
        if (!compFactory.TryGetRegistration(CompName, out var reg))
            return false;

        var lookup = args.EntityManager.System<EntityLookupSystem>();
        var xform = args.EntityManager.GetComponent<TransformComponent>(args.TargetEntity);
        var mapPos = xform.MapPosition;

        if (mapPos.MapId == MapId.Nullspace)
            return false;

        var nearby = lookup.GetEntitiesInRange(mapPos, Range);
        foreach (var ent in nearby)
        {
            if (args.EntityManager.HasComponent(ent, reg.Type))
                return true;
        }

        return false;
    }

    public override string GuidebookExplanation(IPrototypeManager prototype)
    {
        return "TODO";
    }
}
