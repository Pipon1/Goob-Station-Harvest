// SPDX-FileCopyrightText: 2025 GoobBot <uristmchands@proton.me>
// SPDX-License-Identifier: AGPL-3.0-or-later

using System;
using Content.Shared.EntityEffects;
using Content.Shared.StatusEffectNew;
using Content.Shared.StatusEffectNew.Components;
using Robust.Shared.Network;
using Robust.Shared.Timing;

namespace Content.Goobstation.Shared.StatusEffects;

/// <summary>
/// Periodically applies effects defined on <see cref="StatusEffectEffectsComponent"/>.
/// </summary>
public sealed partial class StatusEffectEffectsSystem : EntitySystem
{
    [Dependency] private IGameTiming _timing = default!;
    [Dependency] private SharedEntityEffectSystem _effects = default!;
    [Dependency] private INetManager _net = default!;

    public override void Update(float frameTime)
    {
        base.Update(frameTime);

        if (!_net.IsServer)
            return;

        var now = _timing.CurTime;
        var query = EntityQueryEnumerator<StatusEffectEffectsComponent, StatusEffectComponent>();
        while (query.MoveNext(out var uid, out var effectsComp, out var statusComp))
        {
            if (now < effectsComp.NextUpdate)
                continue;

            effectsComp.NextUpdate = now + TimeSpan.FromSeconds(effectsComp.UpdateDelay);
            Dirty(uid, effectsComp);

            if (statusComp.AppliedTo is not { } target)
                continue;

            foreach (var effect in effectsComp.Effects)
                _effects.Effect(effect, new EntityEffectBaseArgs(target, EntityManager));
        }
    }

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<StatusEffectEffectsComponent, StatusEffectAppliedEvent>(OnApplied);
    }

    private void OnApplied(Entity<StatusEffectEffectsComponent> ent, ref StatusEffectAppliedEvent args)
    {
        ent.Comp.NextUpdate = _timing.CurTime + TimeSpan.FromSeconds(ent.Comp.UpdateDelay);
        Dirty(ent);
    }
}
