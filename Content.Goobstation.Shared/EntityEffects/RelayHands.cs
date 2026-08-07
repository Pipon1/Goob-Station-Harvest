// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.EntityEffects;
using Content.Shared.Hands.Components;
using Content.Shared.Hands.EntitySystems;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

/// <summary>
/// For hands, applies an effect to the entities that the user is holding.
/// </summary>
[UsedImplicitly]
public sealed partial class RelayHands : EntityEffectBase<RelayHands>
{
    /// <summary>
    /// The effect to apply
    /// </summary>
    [DataField("effect", required: true)]
    public EntityEffect TargetEffect = default!;

    public override string? EntityEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys) => null;
}

public sealed partial class RelayHandsSystem : EntityEffectSystem<HandsComponent, RelayHands>
{
    [Dependency] private readonly SharedHandsSystem _hands = default!;
    [Dependency] private readonly SharedEntityEffectsSystem _entityEffects = default!;

    protected override void Effect(Entity<HandsComponent> entity, ref EntityEffectEvent<RelayHands> args)
    {
        foreach (var item in _hands.EnumerateHeld(entity.AsNullable()))
        {
            _entityEffects.ApplyEffect(item, args.Effect.TargetEffect, args.Scale, args.User);
        }
    }
}
