// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.EntityEffects;
using Content.Shared.StatusEffectNew;
using Content.Shared.Stunnable;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

public enum ParalysisEffectType
{
    Add,
    Remove
}

[UsedImplicitly]
public sealed partial class ModifyParalysis : EntityEffect
{
    [DataField]
    public float? Time;

    [DataField]
    public ParalysisEffectType Type = ParalysisEffectType.Add;

    protected override string? ReagentEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => null;

    public override void Effect(EntityEffectBaseArgs args)
    {
        var stunSystem = args.EntityManager.System<SharedStunSystem>();
        var statusSystem = args.EntityManager.System<StatusEffectsSystem>();

        if (Type == ParalysisEffectType.Remove)
        {
            statusSystem.TryRemoveStatusEffect(args.TargetEntity, SharedStunSystem.StunId);
            args.EntityManager.RemoveComponent<StunnedComponent>(args.TargetEntity);
            return;
        }

        if (Time.HasValue)
            stunSystem.TryUpdateParalyzeDuration(args.TargetEntity, TimeSpan.FromSeconds(Time.Value));
    }
}
