// SPDX-License-Identifier: AGPL-3.0-or-later

using System;
using Content.Shared.Chemistry.Components;
using Content.Shared.EntityEffects;
using Content.Shared.Movement.Systems;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;
using Robust.Shared.Timing;

namespace Content.Goobstation.Shared.EntityEffects;

[UsedImplicitly]
public sealed partial class MovementSpeedModifier : EntityEffect
{
    [DataField]
    public float WalkSpeedModifier = 1.0f;

    [DataField]
    public float SprintSpeedModifier = 1.0f;

    [DataField]
    public float Duration = 0f;

    protected override string? ReagentEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => null;

    public override void Effect(EntityEffectBaseArgs args)
    {
        var ent = args.TargetEntity;
        var entMan = args.EntityManager;

        var comp = entMan.EnsureComponent<MovespeedModifierMetabolismComponent>(ent);
        comp.WalkSpeedModifier = WalkSpeedModifier;
        comp.SprintSpeedModifier = SprintSpeedModifier;
        comp.ModifierTimer = IoCManager.Resolve<IGameTiming>().CurTime + TimeSpan.FromSeconds(Duration);
        entMan.Dirty(ent, comp);

        entMan.System<MovementSpeedModifierSystem>().RefreshMovementSpeedModifiers(ent);
    }
}
