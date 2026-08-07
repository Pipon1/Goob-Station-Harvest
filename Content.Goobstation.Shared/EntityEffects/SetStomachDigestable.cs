// SPDX-FileCopyrightText: 2025 GoobBot <uristmchands@proton.me>
// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.Body.Components;
using Content.Shared.Body.Systems;
using Content.Shared.EntityEffects;
using Content.Shared.Whitelist;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

[UsedImplicitly]
public sealed partial class SetStomachDigestable : EntityEffectBase<SetStomachDigestable>
{
    [DataField]
    public EntityWhitelist? SpecialDigestible;

    public override string? EntityEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => null;
}

public sealed partial class SetStomachDigestableSystem : EntityEffectSystem<StomachComponent, SetStomachDigestable>
{
    [Dependency] private readonly StomachSystem _stomach = default!;

    protected override void Effect(Entity<StomachComponent> entity, ref EntityEffectEvent<SetStomachDigestable> args)
    {
        _stomach.SetSpecialDigestible(entity.Owner, args.Effect.SpecialDigestible);
    }
}
