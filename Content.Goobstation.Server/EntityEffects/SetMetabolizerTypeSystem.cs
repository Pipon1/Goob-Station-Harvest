// SPDX-FileCopyrightText: 2025 GoobBot <uristmchands@proton.me>
// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Goobstation.Shared.EntityEffects;
using Content.Server.Body.Components;
using Content.Shared.EntityEffects;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Server.EntityEffects;

/// <summary>
/// Sets the metabolizer types on the target's <see cref="MetabolizerComponent"/>.
/// </summary>
public sealed partial class SetMetabolizerTypeSystem : EntityEffectSystem<MetabolizerComponent, SetMetabolizerType>
{
    protected override void Effect(Entity<MetabolizerComponent> entity, ref EntityEffectEvent<SetMetabolizerType> args)
    {
        entity.Comp.MetabolizerTypes = args.Effect.MetabolizerTypes;
        Dirty(entity);
    }
}
