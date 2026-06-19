// SPDX-File-Identifier: AGPL-3.0-or-later

using Content.Goobstation.Shared.EntityEffects;
using Content.Shared.EntityEffects;
using Content.Shared.Trigger;
using Robust.Shared.GameObjects;

namespace Content.Goobstation.Shared.EntityEffects;

/// <summary>
/// Applies <see cref="EntityEffectOnTriggerComponent.Effects"/> when a <see cref="TriggerEvent"/> is raised.
/// </summary>
public sealed class EntityEffectOnTriggerSystem : EntitySystem
{
    [Dependency] private SharedEntityEffectSystem _effects = default!;

    public override void Initialize()
    {
        base.Initialize();
        SubscribeLocalEvent<EntityEffectOnTriggerComponent, TriggerEvent>(OnTrigger);
    }

    private void OnTrigger(Entity<EntityEffectOnTriggerComponent> ent, ref TriggerEvent args)
    {
        var target = args.User ?? ent.Owner;

        foreach (var effect in ent.Comp.Effects)
        {
            _effects.Effect(effect, new EntityEffectBaseArgs(target, EntityManager));
        }

        args.Handled = true;
    }
}
