// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.EntityEffects;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

[UsedImplicitly]
public sealed partial class NestedEffect : EntityEffect
{
    [DataField("proto", required: true)]
    public ProtoId<EntityEffectPrototype> Proto = default!;

    protected override string? ReagentEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => null;

    public override void Effect(EntityEffectBaseArgs args)
    {
        var protoManager = IoCManager.Resolve<IPrototypeManager>();
        if (!protoManager.TryIndex(Proto, out var effectProto))
            return;

        foreach (var effect in effectProto.Effects)
        {
            effect.Effect(args);
        }
    }
}
