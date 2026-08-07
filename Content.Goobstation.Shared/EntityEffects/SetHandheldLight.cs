// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.EntityEffects;
using Content.Shared.Light;
using Content.Shared.Light.Components;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

[UsedImplicitly]
public sealed partial class SetHandheldLight : EntityEffectBase<SetHandheldLight>
{
    [DataField]
    public bool Activated = false;

    public override string? EntityEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => null;
}

public sealed partial class SetHandheldLightSystem : EntityEffectSystem<HandheldLightComponent, SetHandheldLight>
{
    [Dependency] private readonly SharedHandheldLightSystem _handheld = default!;

    protected override void Effect(Entity<HandheldLightComponent> entity, ref EntityEffectEvent<SetHandheldLight> args)
    {
        _handheld.SetActivated(entity.Owner, args.Effect.Activated, entity.Comp);
    }
}
