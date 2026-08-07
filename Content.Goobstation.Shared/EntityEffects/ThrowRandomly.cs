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
public sealed partial class ThrowRandomly : EntityEffectBase<ThrowRandomly>
{
    [DataField]
    public float Speed = 10f;

    public override string? EntityEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => null;
}

public sealed partial class ThrowRandomlySystem : EntityEffectSystem<TransformComponent, ThrowRandomly>
{
    [Dependency] private readonly ThrowingSystem _throwing = default!;
    [Dependency] private readonly IRobustRandom _random = default!;

    protected override void Effect(Entity<TransformComponent> entity, ref EntityEffectEvent<ThrowRandomly> args)
    {
        var angle = _random.NextFloat() * MathF.PI * 2;
        var direction = new Vector2(MathF.Cos(angle), MathF.Sin(angle));
        _throwing.TryThrow(entity.Owner, direction, args.Effect.Speed);
    }
}
