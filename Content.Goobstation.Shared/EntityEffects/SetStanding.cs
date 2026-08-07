// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.EntityEffects;
using Content.Shared.Standing;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

[UsedImplicitly]
public sealed partial class SetStanding : EntityEffectBase<SetStanding>
{
    [DataField]
    public bool Force = false;

    public override string? EntityEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => null;
}

public sealed partial class SetStandingSystem : EntityEffectSystem<StandingStateComponent, SetStanding>
{
    [Dependency] private readonly StandingStateSystem _standing = default!;

    protected override void Effect(Entity<StandingStateComponent> entity, ref EntityEffectEvent<SetStanding> args)
    {
        _standing.Stand(entity.Owner);
    }
}
