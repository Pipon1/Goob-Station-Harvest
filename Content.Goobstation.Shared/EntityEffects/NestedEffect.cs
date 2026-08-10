// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.EntityEffects;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

[UsedImplicitly]
public sealed partial class NestedEffect : EntityEffectBase<NestedEffect>
{
    [DataField("proto", required: true)]
    public ProtoId<EntityEffectPrototype> Proto = default!;

    public override string? EntityEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => null;
}

public sealed partial class NestedEffectSystem : EntityEffectSystem<MetaDataComponent, NestedEffect>
{
    [Dependency] private readonly IPrototypeManager _proto = default!;
    [Dependency] private readonly SharedEntityEffectsSystem _entityEffects = default!;

    protected override void Effect(Entity<MetaDataComponent> entity, ref EntityEffectEvent<NestedEffect> args)
    {
        if (!_proto.TryIndex(args.Effect.Proto, out var effectProto))
            return;

        _entityEffects.ApplyEffects(entity.Owner, effectProto.Effects, args.Scale, args.User);
    }
}
