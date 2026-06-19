// SPDX-License-Identifier: AGPL-3.0-or-later

using System;
using System.Collections.Generic;
using Content.Shared.Damage;
using Content.Shared.Damage.Components;
using Content.Shared.EntityEffects;
using Content.Goobstation.Maths.FixedPoint;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

[UsedImplicitly]
public sealed partial class HealthChangeBasedOnDamage : EntityEffect
{
    [DataField]
    public float MaximumDamage = -50f;

    [DataField]
    public Dictionary<string, float> Damage = new();

    protected override string? ReagentEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => null;

    public override void Effect(EntityEffectBaseArgs args)
    {
        if (!args.EntityManager.TryGetComponent<DamageableComponent>(args.TargetEntity, out var damageable))
            return;

        var totalHeal = 0f;
        var dspec = new DamageSpecifier();
        var maxHeal = MathF.Abs(MaximumDamage);

        foreach (var (type, amount) in Damage)
        {
            if (totalHeal >= maxHeal)
                break;

            var existing = damageable.Damage.DamageDict.GetValueOrDefault(type).Float();
            if (existing > 0)
            {
                var desiredHeal = MathF.Abs(amount);
                var remaining = maxHeal - totalHeal;
                var actualHeal = MathF.Min(existing, MathF.Min(desiredHeal, remaining));

                if (actualHeal > 0)
                {
                    dspec.DamageDict[type] = -actualHeal;
                    totalHeal += actualHeal;
                }
            }
        }

        if (dspec.DamageDict.Count > 0)
        {
            args.EntityManager.System<DamageableSystem>().TryChangeDamage(
                args.TargetEntity,
                dspec,
                ignoreResistances: true,
                interruptsDoAfters: false);
        }
    }
}
