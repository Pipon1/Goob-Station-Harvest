// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.Actions;
using Content.Shared.Actions.Events;
using Content.Shared.EntityEffects;
using Robust.Shared.Timing;

namespace Content.Goobstation.Shared.Actions;

public sealed partial class EffectActionSystem : EntitySystem
{
    [Dependency] private SharedEntityEffectSystem _effects = default!;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<EffectActionComponent, ActionPerformedEvent>(OnActionPerformed);
        SubscribeLocalEvent<EffectInstantActionEvent>(OnInstantAction);
        SubscribeLocalEvent<EffectTargetActionEvent>(OnTargetAction);

        SubscribeLocalEvent<EffectToggleActionEvent>(OnToggle);
    }

    private void OnActionPerformed(Entity<EffectActionComponent> ent, ref ActionPerformedEvent args)
    {
        if (ent.Comp.OnPerformed)
        {
            foreach (var effect in ent.Comp.Effects)
                _effects.Effect(effect, new EntityEffectBaseArgs(args.Performer, EntityManager));
        }
    }

    private void OnInstantAction(EffectInstantActionEvent args)
    {
        if (!TryComp<EffectActionComponent>(args.Action, out var comp))
            return;

        foreach (var effect in comp.Effects)
            _effects.Effect(effect, new EntityEffectBaseArgs(args.Performer, EntityManager));
        args.Handled = true;
    }

    private void OnTargetAction(EffectTargetActionEvent args)
    {
        if (!TryComp<EffectActionComponent>(args.Action, out var comp))
            return;

        foreach (var effect in comp.Effects)
            _effects.Effect(effect, new EntityEffectBaseArgs(args.Target, EntityManager));
        args.Handled = true;
    }

    private void OnToggle(EffectToggleActionEvent args)
    {
        if (!TryComp<ToggleEffectActionComponent>(args.Action, out var comp))
            return;

        bool targetState = !comp.Toggled;
        // TODO: Trauma has EntityConditions system, Goob doesn't - need alternative implementation
        // if (targetState && comp.OnToggleConditions is { } conditions)
        // {
        //     if (!_conditions.TryConditions(args.Performer, conditions))
        //     {
        //         return;
        //     }
        // }

        args.Handled = true;

        // If you modify args.Toggle directly and use it to check the conditions,
        // it will eventually lead to mispredicts (offEffects and onEffects getting applied constantly)
        // Conditions, on the other hand, don't need this.
        // So, storing a boolean on the component itself fixes those mispredicts.
        comp.Toggled = targetState;
        Dirty(args.Action, comp);

        args.Toggle = targetState;

        if (comp.Toggled)
        {
            if (comp.OnToggle is not { } onEffects)
                return;

            foreach (var effect in onEffects)
                _effects.Effect(effect, new EntityEffectBaseArgs(args.Performer, EntityManager));
            return;
        }

        if (comp.OffToggle is not { } offToggleEffects)
            return;

        foreach (var effect in offToggleEffects)
            _effects.Effect(effect, new EntityEffectBaseArgs(args.Performer, EntityManager));
    }
}
