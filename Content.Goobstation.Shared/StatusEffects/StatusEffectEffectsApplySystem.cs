// SPDX-FileCopyrightText: 2025 GoobBot <uristmchands@proton.me>
// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.EntityEffects;
using Content.Shared.StatusEffectNew;
using Robust.Shared.Timing;

namespace Content.Goobstation.Shared.StatusEffects;

/// <summary>
/// Applies one-shot effects when a status effect is applied or removed,
/// as defined on <see cref="StatusEffectEffectsApplyComponent"/>.
/// </summary>
public sealed partial class StatusEffectEffectsApplySystem : EntitySystem
{
    [Dependency] private SharedEntityEffectSystem _effects = default!;
    [Dependency] private IGameTiming _timing = default!;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<StatusEffectEffectsApplyComponent, StatusEffectAppliedEvent>(OnApplied);
        SubscribeLocalEvent<StatusEffectEffectsApplyComponent, StatusEffectRemovedEvent>(OnRemoved);
    }

    private void OnApplied(Entity<StatusEffectEffectsApplyComponent> ent, ref StatusEffectAppliedEvent args)
    {
        if (_timing.ApplyingState)
            return;

        foreach (var effect in ent.Comp.EffectsOnApply)
            _effects.Effect(effect, new EntityEffectBaseArgs(args.Target, EntityManager));
    }

    private void OnRemoved(Entity<StatusEffectEffectsApplyComponent> ent, ref StatusEffectRemovedEvent args)
    {
        if (_timing.ApplyingState)
            return;

        foreach (var effect in ent.Comp.EffectsOnRemoval)
            _effects.Effect(effect, new EntityEffectBaseArgs(args.Target, EntityManager));
    }
}
