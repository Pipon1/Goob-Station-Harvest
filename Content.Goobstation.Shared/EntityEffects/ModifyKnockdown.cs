// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.EntityEffects;
using Content.Shared.Stunnable;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

public enum KnockdownEffectType
{
    Add,
    Remove
}

[UsedImplicitly]
public sealed partial class ModifyKnockdown : EntityEffect
{
    [DataField]
    public float? Time;

    [DataField]
    public KnockdownEffectType Type = KnockdownEffectType.Add;

    protected override string? ReagentEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => null;

    public override void Effect(EntityEffectBaseArgs args)
    {
        var stunSystem = args.EntityManager.System<SharedStunSystem>();

        if (Type == KnockdownEffectType.Remove)
        {
            args.EntityManager.RemoveComponent<KnockedDownComponent>(args.TargetEntity);
            return;
        }

        if (Time.HasValue)
            stunSystem.TryKnockdown(args.TargetEntity, TimeSpan.FromSeconds(Time.Value), force: true);
    }
}
