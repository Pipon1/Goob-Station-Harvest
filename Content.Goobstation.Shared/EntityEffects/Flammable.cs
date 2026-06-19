// SPDX-License-Identifier: AGPL-3.0-or-later

using System;
using Content.Shared.Atmos.Components;
using Content.Shared.EntityEffects;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

[UsedImplicitly]
public sealed partial class Flammable : EntityEffect
{
    [DataField]
    public float Multiplier = 1f;

    protected override string? ReagentEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => null;

    public override void Effect(EntityEffectBaseArgs args)
    {
        if (!args.EntityManager.TryGetComponent<FlammableComponent>(args.TargetEntity, out var flammable))
            return;

        flammable.FireStacks += Multiplier;
        flammable.FireStacks = Math.Clamp(flammable.FireStacks, flammable.MinimumFireStacks, flammable.MaximumFireStacks);

        if (flammable.FireStacks > 0)
            flammable.OnFire = true;

        args.EntityManager.Dirty(args.TargetEntity, flammable);
    }
}
