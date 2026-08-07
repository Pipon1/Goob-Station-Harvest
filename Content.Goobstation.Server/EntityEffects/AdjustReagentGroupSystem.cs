// SPDX-FileCopyrightText: 2025 GoobBot <uristmchands@proton.me>
// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Goobstation.Shared.EntityEffects;
using Content.Shared.Body.Components;
using Content.Shared.Chemistry.EntitySystems;
using Content.Shared.Chemistry.Reagent;
using Content.Shared.EntityEffects;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Server.EntityEffects;

/// <summary>
/// Adjusts the quantity of all reagents in the target's bloodstream chemical solution
/// that belong to the specified <see cref="ReagentPrototype.Group"/>.
/// </summary>
public sealed partial class AdjustReagentGroupSystem : EntityEffectSystem<BloodstreamComponent, AdjustReagentGroup>
{
    [Dependency] private readonly SharedSolutionContainerSystem _solutionContainer = default!;
    [Dependency] private readonly IPrototypeManager _proto = default!;

    protected override void Effect(Entity<BloodstreamComponent> entity, ref EntityEffectEvent<AdjustReagentGroup> args)
    {
        if (!_solutionContainer.ResolveSolution(entity.Owner, entity.Comp.BloodSolutionName, ref entity.Comp.BloodSolution, out var solution) ||
            entity.Comp.BloodSolution is not { } bloodSolution)
            return;

        var quantity = args.Effect.Amount * args.Scale;
        var group = args.Effect.Group;

        foreach (var quant in solution.Contents.ToArray())
        {
            var proto = _proto.Index<ReagentPrototype>(quant.Reagent.Prototype);
            if (proto.Group != group)
                continue;

            if (quantity > 0)
                _solutionContainer.TryAddReagent(bloodSolution, proto.ID, quantity);
            else
                _solutionContainer.RemoveReagent(bloodSolution, proto.ID, -quantity);
        }
    }
}
