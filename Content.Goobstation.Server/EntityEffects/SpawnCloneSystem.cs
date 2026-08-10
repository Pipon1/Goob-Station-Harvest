// SPDX-FileCopyrightText: 2025 GoobBot <uristmchands@proton.me>
// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Goobstation.Shared.EntityEffects;
using Content.Server.Cloning;
using Content.Shared.Cloning;
using Content.Shared.EntityEffects;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Server.EntityEffects;

/// <summary>
/// Clones the target entity using the configured cloning settings.
/// </summary>
public sealed partial class SpawnCloneSystem : EntityEffectSystem<MetaDataComponent, SpawnClone>
{
    [Dependency] private readonly CloningSystem _cloning = default!;

    protected override void Effect(Entity<MetaDataComponent> entity, ref EntityEffectEvent<SpawnClone> args)
    {
        _cloning.TryCloning(entity.Owner, null, args.Effect.Settings, out _);
    }
}
