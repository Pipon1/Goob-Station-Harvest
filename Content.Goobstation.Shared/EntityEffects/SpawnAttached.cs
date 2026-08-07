// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.EntityEffects;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

[UsedImplicitly]
public sealed partial class SpawnAttached : EntityEffectBase<SpawnAttached>
{
    [DataField("entity", required: true)]
    public EntProtoId Entity = default!;

    public override string? EntityEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => null;
}

public sealed partial class SpawnAttachedSystem : EntityEffectSystem<TransformComponent, SpawnAttached>
{
    protected override void Effect(Entity<TransformComponent> entity, ref EntityEffectEvent<SpawnAttached> args)
    {
        var spawned = EntityManager.SpawnAttachedTo(args.Effect.Entity, entity.Comp.Coordinates);
        EntityManager.GetComponent<TransformComponent>(spawned).AttachParent(entity.Owner);
    }
}
