// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Goobstation.Shared.LightDetection;
using Content.Goobstation.Shared.LightDetection.Components;
using Content.Goobstation.Shared.LightDetection.Systems;
using Content.Shared.StatusEffectNew;
using Content.Shared.StatusEffectNew.Components;
using Content.Shared.Stealth;
using Content.Shared.Stealth.Components;
using Robust.Shared.Network;

namespace Content.Goobstation.Shared.StatusEffects;

public sealed partial class DarknessStealthStatusEffectSystem : EntitySystem
{
    [Dependency] private StatusEffectsSystem _status = default!;
    [Dependency] private SharedStealthSystem _stealth = default!;
    [Dependency] private INetManager _net = default!;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<StatusEffectContainerComponent, LightLevelUpdated>(_status.RelayEvent);

        SubscribeLocalEvent<DarknessStealthStatusEffectComponent, StatusEffectRelayedEvent<LightLevelUpdated>>(OnLightUpdated);

        SubscribeLocalEvent<DarknessStealthStatusEffectComponent, StatusEffectAppliedEvent>(OnApplied);
        SubscribeLocalEvent<DarknessStealthStatusEffectComponent, StatusEffectRemovedEvent>(OnRemove);
    }

    private void OnLightUpdated(Entity<DarknessStealthStatusEffectComponent> ent, ref StatusEffectRelayedEvent<LightLevelUpdated> args)
    {
        var newLevel = args.Args.NewLightLevel;

        // Get the player entity this status effect is applied to
        if (!TryComp<StatusEffectComponent>(ent.Owner, out var statusComp) || statusComp.AppliedTo is not { } target)
            return;

        // StealthComponent is only added on the server; bail if missing
        if (!TryComp<StealthComponent>(target, out var stealth))
            return;

        // We are in darkness here
        if (newLevel < ent.Comp.TriggerAt)
        {
            _stealth.SetVisibility(target, ent.Comp.Visibility, stealth);
            return;
        }

        _stealth.SetVisibility(target, 1f, stealth);
    }

    private void OnApplied(Entity<DarknessStealthStatusEffectComponent> ent, ref StatusEffectAppliedEvent args)
    {
        if (!_net.IsServer)
            return;

        var target = args.Target;
        EnsureComp<LightDetectionComponent>(target);
        EnsureComp<StealthComponent>(target);

        // Check current light level immediately so we don't start invisible in light
        if (TryComp<LightDetectionComponent>(target, out var light))
        {
            if (light.CurrentLightLevel < ent.Comp.TriggerAt)
                _stealth.SetVisibility(target, ent.Comp.Visibility);
            else
                _stealth.SetVisibility(target, 1f);
        }
    }

    private void OnRemove(Entity<DarknessStealthStatusEffectComponent> ent, ref StatusEffectRemovedEvent args)
    {
        if (!_net.IsServer)
            return;

        var target = args.Target;
        RemCompDeferred<LightDetectionComponent>(target);
        RemCompDeferred<StealthComponent>(target);
    }
}
