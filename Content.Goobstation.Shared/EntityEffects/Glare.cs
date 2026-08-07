// SPDX-License-Identifier: AGPL-3.0-or-later

using System;
using Content.Shared.EntityEffects;
using Content.Shared.Flash;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

[UsedImplicitly]
public sealed partial class Glare : EntityEffectBase<Glare>
{
    [DataField]
    public float SlowTo = 0.5f;

    [DataField]
    public float MaxRange = 10f;

    [DataField]
    public float Duration = 4f;

    public override string? EntityEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => null;
}

public sealed partial class GlareSystem : EntityEffectSystem<MetaDataComponent, Glare>
{
    [Dependency] private readonly SharedFlashSystem _flash = default!;

    protected override void Effect(Entity<MetaDataComponent> entity, ref EntityEffectEvent<Glare> args)
    {
        _flash.Flash(
            entity.Owner,
            user: null,
            used: null,
            flashDuration: TimeSpan.FromSeconds(args.Effect.Duration),
            slowTo: args.Effect.SlowTo);
    }
}
