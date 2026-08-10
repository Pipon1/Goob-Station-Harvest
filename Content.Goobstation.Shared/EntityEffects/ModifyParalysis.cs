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
public sealed partial class ModifyParalysis : EntityEffectBase<ModifyParalysis>
{
    [DataField]
    public float? Time;

    [DataField]
    public ParalysisEffectType Type = ParalysisEffectType.Add;

    public override string? EntityEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => null;
}

public sealed partial class ModifyParalysisSystem : EntityEffectSystem<MetaDataComponent, ModifyParalysis>
{
    [Dependency] private readonly SharedStunSystem _stun = default!;
    [Dependency] private readonly StatusEffectsSystem _status = default!;

    protected override void Effect(Entity<MetaDataComponent> entity, ref EntityEffectEvent<ModifyParalysis> args)
    {
        if (args.Effect.Type == ParalysisEffectType.Remove)
        {
            _status.TryRemoveStatusEffect(entity.Owner, SharedStunSystem.StunId);
            RemComp<StunnedComponent>(entity.Owner);
            return;
        }

        if (args.Effect.Time.HasValue)
            _stun.TryUpdateParalyzeDuration(entity.Owner, TimeSpan.FromSeconds(args.Effect.Time.Value));
    }
}
