// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.EntityEffects;
using Content.Shared.Light.Components;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

[UsedImplicitly]
public sealed partial class SetUnpoweredFlashlight : EntityEffectBase<SetUnpoweredFlashlight>
{
    [DataField]
    public bool LightOn = false;

    public override string? EntityEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => null;
}

public sealed partial class SetUnpoweredFlashlightSystem : EntityEffectSystem<UnpoweredFlashlightComponent, SetUnpoweredFlashlight>
{
    protected override void Effect(Entity<UnpoweredFlashlightComponent> entity, ref EntityEffectEvent<SetUnpoweredFlashlight> args)
    {
        entity.Comp.LightOn = args.Effect.LightOn;
        Dirty(entity);
    }
}
