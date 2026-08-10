// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Goobstation.Shared.Vampires;
using Content.Shared.EntityEffects;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

/// <summary>
/// Entity effect that grants vampire blood to entities with <see cref="VampireComponent"/>.
/// Used as a metabolism effect when vampires ingest blood reagents.
/// </summary>
[UsedImplicitly]
public sealed partial class VampireGainBlood : EntityEffectBase<VampireGainBlood>
{
    /// <summary>
    /// How much vampire blood is gained per metabolism tick.
    /// </summary>
    [DataField]
    public int Amount = 5;

    public override string? EntityEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => null;
}

public sealed partial class VampireGainBloodSystem : EntityEffectSystem<VampireComponent, VampireGainBlood>
{
    [Dependency] private readonly SharedVampireSystem _vampire = default!;

    protected override void Effect(Entity<VampireComponent> entity, ref EntityEffectEvent<VampireGainBlood> args)
    {
        _vampire.AdjustBlood(entity.Owner, args.Effect.Amount);
    }
}
