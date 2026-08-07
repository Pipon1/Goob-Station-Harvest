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
public sealed partial class ModifyKnockdown : EntityEffectBase<ModifyKnockdown>
{
    [DataField]
    public float? Time;

    [DataField]
    public KnockdownEffectType Type = KnockdownEffectType.Add;

    public override string? EntityEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => null;
}

public sealed partial class ModifyKnockdownSystem : EntityEffectSystem<MetaDataComponent, ModifyKnockdown>
{
    [Dependency] private readonly SharedStunSystem _stun = default!;

    protected override void Effect(Entity<MetaDataComponent> entity, ref EntityEffectEvent<ModifyKnockdown> args)
    {
        if (args.Effect.Type == KnockdownEffectType.Remove)
        {
            RemComp<KnockedDownComponent>(entity.Owner);
            return;
        }

        if (args.Effect.Time.HasValue)
            _stun.TryKnockdown(entity.Owner, TimeSpan.FromSeconds(args.Effect.Time.Value), force: true);
    }
}
