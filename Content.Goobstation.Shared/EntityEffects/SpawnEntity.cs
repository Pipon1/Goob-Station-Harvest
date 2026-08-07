// SPDX-FileCopyrightText: 2025 GoobBot <uristmchands@proton.me>
// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.EntityEffects;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

[UsedImplicitly]
public sealed partial class SpawnEntity : EntityEffectBase<SpawnEntity>
{
    [DataField("entity", required: true)]
    public EntProtoId Entity = default!;

    [DataField]
    public bool Predicted = true;

    public override string? EntityEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => null;
}

public sealed partial class SpawnEntitySystem : EntityEffectSystem<TransformComponent, SpawnEntity>
{
    protected override void Effect(Entity<TransformComponent> entity, ref EntityEffectEvent<SpawnEntity> args)
    {
        EntityManager.SpawnAttachedTo(args.Effect.Entity, entity.Comp.Coordinates);
    }
}
