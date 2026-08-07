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
public sealed partial class DestroyLightBulb : EntityEffectBase<DestroyLightBulb>
{
    public override string? EntityEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => null;
}

public sealed partial class DestroyLightBulbSystem : EntityEffectSystem<MetaDataComponent, DestroyLightBulb>
{
    [Dependency] private readonly SharedPointLightSystem _pointLight = default!;

    protected override void Effect(Entity<MetaDataComponent> entity, ref EntityEffectEvent<DestroyLightBulb> args)
    {
        var target = entity.Owner;

        if (HasComp<ExtinguishImmuneComponent>(target))
            return;

        if (TryComp<LightBulbComponent>(target, out var bulb))
        {
            bulb.State = LightBulbState.Broken;
            Dirty(target, bulb);
            return;
        }

        var ev = new BreakLightBulbEvent(target);
        RaiseLocalEvent(target, ref ev);

        _pointLight.SetEnabled(target, false);
    }
}
