// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Goobstation.Maths.FixedPoint;
using Content.Shared.Chemistry.Components.SolutionManager;
using Content.Shared.Chemistry.EntitySystems;
using Content.Shared.EntityEffects;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects.EffectConditions;

public sealed partial class ReagentsCondition : EntityEffectCondition
{
    [DataField]
    public float Min = 0f;

    public override bool Condition(EntityEffectBaseArgs args)
    {
        if (!args.EntityManager.TryGetComponent(args.TargetEntity, out SolutionContainerManagerComponent? solutions))
            return false;

        var solutionSystem = args.EntityManager.System<SharedSolutionContainerSystem>();
        var totalVolume = FixedPoint2.Zero;

        foreach (var (_, solution) in solutionSystem.EnumerateSolutions((args.TargetEntity, solutions)))
        {
            totalVolume += solution.Comp.Solution.Volume;
        }

        return totalVolume >= Min;
    }

    public override string GuidebookExplanation(IPrototypeManager prototype)
    {
        return Loc.GetString("reagent-effect-condition-guidebook-reagents", ("min", Min));
    }
}
