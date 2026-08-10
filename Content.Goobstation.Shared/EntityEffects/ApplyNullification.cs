// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Goobstation.Shared.Vampires;
using Content.Shared.EntityEffects;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

[UsedImplicitly]
public sealed partial class ApplyNullification : EntityEffectBase<ApplyNullification>
{
    [DataField]
    public int Amount = 1;

    public override string? EntityEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => null;
}

public sealed partial class ApplyNullificationSystem : EntityEffectSystem<NullificationComponent, ApplyNullification>
{
    protected override void Effect(Entity<NullificationComponent> entity, ref EntityEffectEvent<ApplyNullification> args)
    {
        entity.Comp.Amount += args.Effect.Amount;
        Dirty(entity);
    }
}
