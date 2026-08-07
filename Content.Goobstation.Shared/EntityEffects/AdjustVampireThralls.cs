// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Goobstation.Shared.Vampires.Dantalion;
using Content.Shared.EntityEffects;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

[UsedImplicitly]
public sealed partial class AdjustVampireThralls : EntityEffectBase<AdjustVampireThralls>
{
    [DataField]
    public int Amount = 1;

    public override string? EntityEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => null;
}

public sealed partial class AdjustVampireThrallsSystem : EntityEffectSystem<VampireThrallsComponent, AdjustVampireThralls>
{
    protected override void Effect(Entity<VampireThrallsComponent> entity, ref EntityEffectEvent<AdjustVampireThralls> args)
    {
        entity.Comp.ThrallCap += args.Effect.Amount;
        Dirty(entity);
    }
}
