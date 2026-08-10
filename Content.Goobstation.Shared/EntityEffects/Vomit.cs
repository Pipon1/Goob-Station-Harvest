// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.EntityEffects;
using Content.Shared.Medical;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

/// <summary>
/// Vampire-specific vomit effect. Preserves the old Goobstation behavior of calling Vomit with default values.
/// </summary>
[UsedImplicitly]
public sealed partial class VampireVomit : EntityEffectBase<VampireVomit>
{
    public override string? EntityEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => null;
}

public sealed partial class VampireVomitSystem : EntityEffectSystem<MetaDataComponent, VampireVomit>
{
    [Dependency] private readonly VomitSystem _vomit = default!;

    protected override void Effect(Entity<MetaDataComponent> entity, ref EntityEffectEvent<VampireVomit> args)
    {
        _vomit.Vomit(entity.Owner);
    }
}
