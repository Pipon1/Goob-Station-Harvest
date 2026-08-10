// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.EntityEffects;
using Content.Shared.Whitelist;
using JetBrains.Annotations;
using Robust.Shared.GameObjects;
using Robust.Shared.Physics;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

[UsedImplicitly]
public sealed partial class RelayNearby : EntityEffectBase<RelayNearby>
{
    [DataField(required: true)]
    public string CompName = string.Empty;

    [DataField]
    public float Range = 8f;

    [DataField("effect", required: true)]
    public EntityEffect RelayEffect = default!;

    /// <summary>
    ///     If true, skips entities that are on the same tile as the source.
    /// </summary>
    [DataField]
    public bool SkipSameTile = false;

    /// <summary>
    ///     Optional whitelist that the target entity must satisfy.
    /// </summary>
    [DataField]
    public EntityWhitelist? Whitelist;

    /// <summary>
    ///     Optional blacklist that the target entity must not satisfy.
    /// </summary>
    [DataField]
    public EntityWhitelist? Blacklist;

    public override string? EntityEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => null;
}

public sealed partial class RelayNearbySystem : EntityEffectSystem<TransformComponent, RelayNearby>
{
    [Dependency] private readonly EntityLookupSystem _lookup = default!;
    [Dependency] private readonly IComponentFactory _componentFactory = default!;
    [Dependency] private readonly SharedEntityEffectsSystem _entityEffects = default!;
    [Dependency] private readonly EntityWhitelistSystem _whitelist = default!;

    protected override void Effect(Entity<TransformComponent> entity, ref EntityEffectEvent<RelayNearby> args)
    {
        if (!_componentFactory.TryGetRegistration(args.Effect.CompName, out var registration))
            return;

        var compType = registration.Type;

        foreach (var ent in _lookup.GetEntitiesInRange(entity.Comp.Coordinates, args.Effect.Range))
        {
            if (ent == entity.Owner)
                continue;

            if (!HasComp(ent, compType))
                continue;

            if (args.Effect.SkipSameTile && Transform(ent).Coordinates == entity.Comp.Coordinates)
                continue;

            if (!_whitelist.CheckBoth(ent, args.Effect.Blacklist, args.Effect.Whitelist))
                continue;

            _entityEffects.ApplyEffect(ent, args.Effect.RelayEffect, args.Scale, args.User);
        }
    }
}
