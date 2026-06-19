// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.EntityEffects;
using JetBrains.Annotations;
using Robust.Shared.GameObjects;
using Robust.Shared.Physics;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

[UsedImplicitly]
public sealed partial class RelayNearby : EntityEffect
{
    [DataField(required: true)]
    public string CompName = string.Empty;

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
        var compFactory = IoCManager.Resolve<IComponentFactory>();

        if (!compFactory.TryGetRegistration(CompName, out var registration))
            return;

        var compType = registration.Type;

        foreach (var ent in entityLookup.GetEntitiesInRange(transform.Coordinates, Range))
        {
            if (ent == args.TargetEntity)
                continue;

            if (!args.EntityManager.HasComponent(ent, compType))
                continue;

            RelayEffect.Effect(new EntityEffectBaseArgs(ent, args.EntityManager));
        }
    }
}
