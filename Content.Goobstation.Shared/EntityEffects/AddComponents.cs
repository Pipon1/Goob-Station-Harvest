// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.EntityEffects;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

[UsedImplicitly]
public sealed partial class AddComponents : EntityEffectBase<AddComponents>
{
    [DataField(required: true)]
    public ComponentRegistry Components = new();

    public override string? EntityEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => null;
}

public sealed partial class AddComponentsSystem : EntityEffectSystem<MetaDataComponent, AddComponents>
{
    protected override void Effect(Entity<MetaDataComponent> entity, ref EntityEffectEvent<AddComponents> args)
    {
        EntityManager.AddComponents(entity.Owner, args.Effect.Components, removeExisting: false);
    }
}
