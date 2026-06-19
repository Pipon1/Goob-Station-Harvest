// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.EntityEffects;
using Content.Shared.Light.Components;
using JetBrains.Annotations;
using Robust.Shared.GameObjects;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

/// <summary>
/// Raised on an entity to request that its light bulb be broken (handled server-side).
/// </summary>
[ByRefEvent]
public readonly record struct BreakLightBulbEvent(EntityUid Target);

[UsedImplicitly]
public sealed partial class DestroyLightBulb : EntityEffect
{
    protected override string? ReagentEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => null;

    public override void Effect(EntityEffectBaseArgs args)
    {
        var entMan = args.EntityManager;
        var target = args.TargetEntity;

        // Skip entities immune to extinguishing (e.g. Eternal Darkness light)
        if (entMan.HasComponent<ExtinguishImmuneComponent>(target))
            return;

        // If the entity is a light bulb itself, break it
        if (entMan.TryGetComponent<LightBulbComponent>(target, out var bulb))
        {
            bulb.State = LightBulbState.Broken;
            entMan.Dirty(target, bulb);
            return;
        }

        // If it's a powered light fixture, raise an event so the server can break the bulb
        var ev = new BreakLightBulbEvent(target);
        entMan.EventBus.RaiseLocalEvent(target, ref ev);

        // Otherwise just disable the point light if present
        var pointLightSystem = entMan.System<SharedPointLightSystem>();
        pointLightSystem.SetEnabled(target, false);
    }
}
