// SPDX-License-Identifier: AGPL-3.0-or-later

using System;
using System.Numerics;
using Content.Shared.EntityEffects;
using Content.Shared.Throwing;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;
using Robust.Shared.Random;

namespace Content.Goobstation.Shared.EntityEffects;

[UsedImplicitly]
public sealed partial class ThrowRandomly : EntityEffect
{
    [DataField]
    public float Speed = 10f;

    protected override string? ReagentEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => null;

    public override void Effect(EntityEffectBaseArgs args)
    {
        var throwingSystem = args.EntityManager.System<ThrowingSystem>();
        var random = IoCManager.Resolve<IRobustRandom>();
        var angle = random.NextFloat() * MathF.PI * 2;
        var direction = new Vector2(MathF.Cos(angle), MathF.Sin(angle));
        throwingSystem.TryThrow(args.TargetEntity, direction, Speed);
    }
}
