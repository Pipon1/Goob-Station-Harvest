// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Goobstation.Shared.Vampires;
using Content.Shared.EntityEffects;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

[UsedImplicitly]
public sealed partial class ConsumeVampireBlood : EntityEffectBase<ConsumeVampireBlood>
{
    [DataField]
    public int Amount = 1;

    public override string? EntityEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => null;
}

public sealed partial class ConsumeVampireBloodSystem : EntityEffectSystem<VampireComponent, ConsumeVampireBlood>
{
    [Dependency] private readonly SharedVampireSystem _vampire = default!;

    protected override void Effect(Entity<VampireComponent> entity, ref EntityEffectEvent<ConsumeVampireBlood> args)
    {
        _vampire.SubtractUsableBlood(entity.AsNullable(), args.Effect.Amount);
    }
}
