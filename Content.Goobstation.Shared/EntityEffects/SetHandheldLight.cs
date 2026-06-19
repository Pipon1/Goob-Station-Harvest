// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.EntityEffects;
using Content.Shared.Light;
using Content.Shared.Light.Components;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

[UsedImplicitly]
public sealed partial class SetHandheldLight : EntityEffect
{
    [DataField]
    public bool Activated = false;

    protected override string? ReagentEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => null;

    public override void Effect(EntityEffectBaseArgs args)
    {
        if (!args.EntityManager.TryGetComponent<HandheldLightComponent>(args.TargetEntity, out var handheld))
            return;

        var handheldSystem = args.EntityManager.System<SharedHandheldLightSystem>();
        handheldSystem.SetActivated(args.TargetEntity, Activated, handheld);
    }
}
