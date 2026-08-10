// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.EntityEffects;
using Content.Shared.Throwing;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

[UsedImplicitly]
public sealed partial class ThrowAtFacingDirection : EntityEffectBase<ThrowAtFacingDirection>
{
    [DataField]
    public float Speed = 10f;

    public override string? EntityEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => null;
}

public sealed partial class ThrowAtFacingDirectionSystem : EntityEffectSystem<TransformComponent, ThrowAtFacingDirection>
{
    [Dependency] private readonly ThrowingSystem _throwing = default!;

    protected override void Effect(Entity<TransformComponent> entity, ref EntityEffectEvent<ThrowAtFacingDirection> args)
    {
        var direction = entity.Comp.WorldRotation.ToWorldVec();
        _throwing.TryThrow(entity.Owner, direction, args.Effect.Speed);
    }
}
