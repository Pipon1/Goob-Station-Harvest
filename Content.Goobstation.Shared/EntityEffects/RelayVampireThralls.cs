// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Goobstation.Shared.Vampires.Dantalion;
using Content.Shared.EntityEffects;
using JetBrains.Annotations;
using Robust.Shared.Physics;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

[UsedImplicitly]
public sealed partial class RelayVampireThralls : EntityEffectBase<RelayVampireThralls>
{
    [DataField]
    public float Range = 8f;

    [DataField("effect", required: true)]
    public EntityEffect RelayEffect = default!;

    public override string? EntityEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => null;
}

public sealed partial class RelayVampireThrallsSystem : EntityEffectSystem<TransformComponent, RelayVampireThralls>
{
    [Dependency] private readonly EntityLookupSystem _lookup = default!;
    [Dependency] private readonly SharedEntityEffectsSystem _entityEffects = default!;

    protected override void Effect(Entity<TransformComponent> entity, ref EntityEffectEvent<RelayVampireThralls> args)
    {
        foreach (var ent in _lookup.GetEntitiesInRange(entity.Comp.Coordinates, args.Effect.Range))
        {
            if (ent == entity.Owner)
                continue;

            if (!HasComp<VampireThrallComponent>(ent))
                continue;

            _entityEffects.ApplyEffect(ent, args.Effect.RelayEffect, args.Scale, args.User);
        }
    }
}
