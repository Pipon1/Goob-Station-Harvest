// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.EntityEffects;
using Content.Shared.Light.Components;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

[UsedImplicitly]
public sealed partial class SetUnpoweredFlashlight : EntityEffect
{
    [DataField]
    public bool LightOn = false;

    protected override string? ReagentEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => null;

    public override void Effect(EntityEffectBaseArgs args)
    {
        if (!args.EntityManager.TryGetComponent<UnpoweredFlashlightComponent>(args.TargetEntity, out var light))
            return;

        light.LightOn = LightOn;
        args.EntityManager.Dirty(args.TargetEntity, light);
    }
}
