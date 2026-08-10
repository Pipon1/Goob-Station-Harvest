// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.EntityEffects;
using Content.Goobstation.Shared.Vampires;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

/// <summary>
/// Effect that adjusts vampire blood.
/// </summary>
[UsedImplicitly]
public sealed partial class AdjustVampireBlood : EntityEffectBase<AdjustVampireBlood>
{
    /// <summary>
    /// The amount of blood to add (positive) or remove (negative).
    /// </summary>
    [DataField(required: true)]
    public int Amount;

    public override string? EntityEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys) => null;
}

public sealed partial class AdjustVampireBloodSystem : EntityEffectSystem<VampireComponent, AdjustVampireBlood>
{
    [Dependency] private readonly SharedVampireSystem _vampire = default!;

    protected override void Effect(Entity<VampireComponent> entity, ref EntityEffectEvent<AdjustVampireBlood> args)
    {
        _vampire.AdjustBlood(entity.AsNullable(), args.Effect.Amount);
    }
}
