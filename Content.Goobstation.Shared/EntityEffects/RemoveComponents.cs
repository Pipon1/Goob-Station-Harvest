// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.EntityEffects;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

[UsedImplicitly]
public sealed partial class RemoveComponents : EntityEffectBase<RemoveComponents>
{
    [DataField(required: true)]
    public ComponentRegistry Components = new();

    public override string? EntityEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => null;
}

public sealed partial class RemoveComponentsSystem : EntityEffectSystem<MetaDataComponent, RemoveComponents>
{
    protected override void Effect(Entity<MetaDataComponent> entity, ref EntityEffectEvent<RemoveComponents> args)
    {
        EntityManager.RemoveComponents(entity.Owner, args.Effect.Components);
    }
}
