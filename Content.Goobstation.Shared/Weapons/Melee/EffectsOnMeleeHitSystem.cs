// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.EntityConditions;
using Content.Shared.EntityEffects;
using Content.Shared.Weapons.Melee.Events;
using JetBrains.Annotations;

namespace Content.Goobstation.Shared.Weapons.Melee;

[UsedImplicitly]
public sealed class EffectsOnMeleeHitSystem : EntitySystem
{
    [Dependency] private SharedEntityEffectsSystem _effects = default!;
    [Dependency] private SharedEntityConditionsSystem _conditions = default!;

    public override void Initialize()
    {
        base.Initialize();
        SubscribeLocalEvent<EffectsOnMeleeHitComponent, MeleeHitEvent>(OnMeleeHit);
    }

    private void OnMeleeHit(Entity<EffectsOnMeleeHitComponent> weapon, ref MeleeHitEvent args)
    {
        if (!args.IsHit)
            return;

        if (args.HitEntities.Count == 0)
            return;

        foreach (var target in args.HitEntities)
        {
            if (Deleted(target))
                continue;

            if (!_conditions.TryConditions(target, weapon.Comp.TargetConditions.ToArray()))
                continue;

            foreach (var effect in weapon.Comp.UserEffects)
                _effects.ApplyEffect(args.User, effect);

            foreach (var effect in weapon.Comp.TargetEffects)
                _effects.ApplyEffect(target, effect);
        }
    }
}
