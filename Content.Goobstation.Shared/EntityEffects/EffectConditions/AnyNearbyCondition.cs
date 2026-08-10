// SPDX-FileCopyrightText: 2025 GoobBot <uristmchands@proton.me>
// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.EntityConditions;
using Robust.Shared.GameObjects;
using Robust.Shared.Map;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects.EffectConditions;

public sealed partial class AnyNearbyCondition : EntityConditionBase<AnyNearbyCondition>
{
    [DataField]
    public string CompName = string.Empty;

    [DataField]
    public float Range = 1f;

    public override string EntityConditionGuidebookText(IPrototypeManager prototype) => String.Empty;
}

public sealed partial class AnyNearbyConditionSystem : EntityConditionSystem<MetaDataComponent, AnyNearbyCondition>
{
    [Dependency] private readonly IComponentFactory _componentFactory = default!;
    [Dependency] private readonly EntityLookupSystem _lookup = default!;

    protected override void Condition(Entity<MetaDataComponent> entity, ref EntityConditionEvent<AnyNearbyCondition> args)
    {
        var condition = args.Condition;

        if (string.IsNullOrEmpty(condition.CompName))
        {
            args.Result = false;
            return;
        }

        if (!_componentFactory.TryGetRegistration(condition.CompName, out var reg))
        {
            args.Result = false;
            return;
        }

        if (!TryComp<TransformComponent>(entity.Owner, out var xform))
        {
            args.Result = false;
            return;
        }

        var mapPos = xform.MapPosition;

        if (mapPos.MapId == MapId.Nullspace)
        {
            args.Result = false;
            return;
        }

        var nearby = _lookup.GetEntitiesInRange(mapPos, condition.Range);
        foreach (var ent in nearby)
        {
            if (HasComp(ent, reg.Type))
            {
                args.Result = true;
                return;
            }
        }

        args.Result = false;
    }
}
