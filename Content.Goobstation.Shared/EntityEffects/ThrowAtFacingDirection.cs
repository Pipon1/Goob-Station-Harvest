// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.EntityEffects;
using Content.Shared.Throwing;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

[UsedImplicitly]
public sealed partial class ThrowAtFacingDirection : EntityEffect
{
    [DataField]
    public float Speed = 10f;

    protected override string? ReagentEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => null;

    public override void Effect(EntityEffectBaseArgs args)
    {
        var throwingSystem = args.EntityManager.System<ThrowingSystem>();
        var transform = args.EntityManager.GetComponent<TransformComponent>(args.TargetEntity);
        var direction = transform.WorldRotation.ToWorldVec();
        throwingSystem.TryThrow(args.TargetEntity, direction, Speed);
    }
}
