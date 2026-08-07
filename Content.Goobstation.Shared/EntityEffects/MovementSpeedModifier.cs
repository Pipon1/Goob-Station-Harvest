// SPDX-License-Identifier: AGPL-3.0-or-later

using System;
using Content.Shared.EntityEffects;
using Content.Shared.Movement.Components;
using Content.Shared.Movement.Systems;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

/// <summary>
/// Applies a temporary movement speed modifier to the target.
/// </summary>
[UsedImplicitly]
public sealed partial class MovementSpeedModifier : EntityEffectBase<MovementSpeedModifier>
{
    [DataField]
    public float WalkSpeedModifier = 1.0f;

    [DataField]
    public float SprintSpeedModifier = 1.0f;

    [DataField]
    public float Duration = 0f;

    public override string? EntityEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => null;
}

public sealed partial class MovementSpeedModifierEntityEffectSystem : EntityEffectSystem<MovementSpeedModifierComponent, MovementSpeedModifier>
{
    [Dependency] private readonly MovementModStatusSystem _movementMod = default!;

    protected override void Effect(Entity<MovementSpeedModifierComponent> entity, ref EntityEffectEvent<MovementSpeedModifier> args)
    {
        _movementMod.TryAddMovementSpeedModDuration(
            entity.Owner,
            MovementModStatusSystem.ReagentSpeed,
            TimeSpan.FromSeconds(args.Effect.Duration * args.Scale),
            args.Effect.WalkSpeedModifier,
            args.Effect.SprintSpeedModifier);
    }
}
