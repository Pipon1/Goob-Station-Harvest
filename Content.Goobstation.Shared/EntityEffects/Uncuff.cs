// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.Cuffs;
using Content.Shared.Cuffs.Components;
using Content.Shared.EntityEffects;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

[UsedImplicitly]
public sealed partial class Uncuff : EntityEffectBase<Uncuff>
{
    public override string? EntityEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => null;
}

public sealed partial class UncuffSystem : EntityEffectSystem<CuffableComponent, Uncuff>
{
    [Dependency] private readonly SharedCuffableSystem _cuffable = default!;

    protected override void Effect(Entity<CuffableComponent> entity, ref EntityEffectEvent<Uncuff> args)
    {
        if (entity.Comp.Container.ContainedEntities.Count == 0)
            return;

        _cuffable.TryUncuff(entity.AsNullable(), entity.Owner);
    }
}
