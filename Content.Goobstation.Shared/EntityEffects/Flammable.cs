// SPDX-License-Identifier: AGPL-3.0-or-later

using System;
using Content.Shared.Atmos.Components;
using Content.Shared.EntityEffects;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

[UsedImplicitly]
public sealed partial class Flammable : EntityEffectBase<Flammable>
{
    [DataField]
    public float Multiplier = 1f;

    public override string? EntityEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => null;
}

public sealed partial class FlammableSystem : EntityEffectSystem<FlammableComponent, Flammable>
{
    protected override void Effect(Entity<FlammableComponent> entity, ref EntityEffectEvent<Flammable> args)
    {
        var flammable = entity.Comp;

        flammable.FireStacks += args.Effect.Multiplier;
        flammable.FireStacks = Math.Clamp(flammable.FireStacks, flammable.MinimumFireStacks, flammable.MaximumFireStacks);

        if (flammable.FireStacks > 0)
            flammable.OnFire = true;

        Dirty(entity);
    }
}
