// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.EntityEffects;
using Content.Shared.Weapons.Melee.Events;
using JetBrains.Annotations;

namespace Content.Goobstation.Shared.Weapons.Melee;

[UsedImplicitly]
public sealed class EffectsOnMeleeHitSystem : EntitySystem
{
    [Dependency] private SharedEntityEffectSystem _effects = default!;

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

            // Check target conditions
            var targetArgs = new EntityEffectBaseArgs(target, EntityManager);
            var conditionsMet = true;
            foreach (var condition in weapon.Comp.TargetConditions)
            {
                if (!condition.Condition(targetArgs))
                {
                    conditionsMet = false;
                    break;
                }
            }

            if (!conditionsMet)
                continue;

            // Apply user effects
            var userArgs = new EntityEffectBaseArgs(args.User, EntityManager);
            foreach (var effect in weapon.Comp.UserEffects)
            {
                _effects.Effect(effect, userArgs);
            }

            // Apply target effects
            foreach (var effect in weapon.Comp.TargetEffects)
            {
                _effects.Effect(effect, targetArgs);
            }
        }
    }
}
