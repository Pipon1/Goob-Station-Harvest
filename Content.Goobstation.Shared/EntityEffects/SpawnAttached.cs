// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.EntityEffects;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

[UsedImplicitly]
public sealed partial class SpawnAttached : EntityEffect
{
    [DataField("entity", required: true)]
    public EntProtoId Entity = default!;

    protected override string? ReagentEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => null;

    public override void Effect(EntityEffectBaseArgs args)
    {
        var transform = args.EntityManager.GetComponent<TransformComponent>(args.TargetEntity);
        var spawned = args.EntityManager.SpawnAttachedTo(Entity, transform.Coordinates);
        args.EntityManager.GetComponent<TransformComponent>(spawned).AttachParent(args.TargetEntity);
    }
}
