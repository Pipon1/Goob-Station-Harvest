// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Goobstation.Shared.Vampires.Dantalion;
using Content.Shared.EntityEffects;
using JetBrains.Annotations;
using Robust.Shared.Physics;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

[UsedImplicitly]
public sealed partial class RelayVampireThralls : EntityEffect
{
    [DataField]
    public float Range = 8f;

    [DataField("effect", required: true)]
    public EntityEffect RelayEffect = default!;

    protected override string? ReagentEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => null;

    public override void Effect(EntityEffectBaseArgs args)
    {
        var entityLookup = args.EntityManager.System<EntityLookupSystem>();
        var transform = args.EntityManager.GetComponent<TransformComponent>(args.TargetEntity);

        foreach (var ent in entityLookup.GetEntitiesInRange(transform.Coordinates, Range))
        {
            if (ent == args.TargetEntity)
                continue;

            if (!args.EntityManager.HasComponent<VampireThrallComponent>(ent))
                continue;

            RelayEffect.Effect(new EntityEffectBaseArgs(ent, args.EntityManager));
        }
    }
}
