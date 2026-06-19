// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.EntityEffects;
using Content.Shared.Mobs.Systems;
using Content.Shared.Throwing;
using Content.Goobstation.Shared.Arena;
using Robust.Shared.Network;
using Robust.Shared.Timing;

namespace Content.Goobstation.Shared.Vampires.Gargantua;

public sealed partial class DesecratedDuelSystem : EntitySystem
{
    [Dependency] private ThrowingSystem _throw = default!;
    [Dependency] private IGameTiming _timing = default!;
    [Dependency] private INetManager _net = default!;
    [Dependency] private ArenaCreationSystem _arena = default!;
    [Dependency] private MobStateSystem _mob = default!;
    [Dependency] private SharedEntityEffectSystem _effects = default!;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<ArenaTargetActionEvent>(OnPerform);
    }

    public override void Update(float frameTime)
    {
        base.Update(frameTime);

        var now = _timing.CurTime;

        var activeQuery = EntityQueryEnumerator<ActiveActionDesecratedDuelComponent, ActionDesecratedDuelComponent>();
        while (activeQuery.MoveNext(out var uid, out var active, out var duel))
        {
            // This time check ensures the arena gets deleted after a certain amount of time.
            if (active.DuelCheck < now)
            {
                ExitArena((uid, duel));
                RemCompDeferred(uid, active);
                continue;
            }

            // This time check ensures the arena gets deleted if either of the fighters has died.
            if (active.NextFighterCheck < now)
            {
                CheckDuelist((uid, duel), duel.Target);

                active.NextFighterCheck += duel.FighterCheck;
                Dirty(uid, active);
            }
        }
    }

    private void OnPerform(ArenaTargetActionEvent args)
    {
        var actionUid = args.Action.Owner;
        if (!TryComp<ActionDesecratedDuelComponent>(actionUid, out var comp))
            return;

        var performer = args.Performer;
        var target = args.Target;

        // First, we leap towards our target
        _throw.TryThrow(performer, Transform(target).Coordinates, 30f, performer);

        comp.Duelist = performer;
        comp.Target = target;
        Dirty(actionUid, comp);

        // Set the active timers
        var now = _timing.CurTime;
        var active = new ActiveActionDesecratedDuelComponent();
        active.DuelCheck = now + comp.DuelDuration;
        active.NextFighterCheck = now + comp.FighterCheck;
        AddComp(actionUid, active, true);

        args.Handled = true;
    }

    #region Helpers

    /// <summary>
    /// Clears the arena and anything related to it.
    /// </summary>
    private void ExitArena(Entity<ActionDesecratedDuelComponent> action)
    {
        // Remove status effects
        if (action.Comp.EndEffects is { } endEffects)
        {
            foreach (var effect in endEffects)
                _effects.Effect(effect, new EntityEffectBaseArgs(action.Comp.Duelist, EntityManager));
        }

        // mispredicts happening here sadly
        if (_net.IsClient)
            return;

        _arena.DestroyArena(action.Owner);
    }

    /// <summary>
    /// Check on the duelist to see if they are alive or deleted.
    /// Exits the arena if duelist is dead or deleted.
    /// </summary>
    private void CheckDuelist(Entity<ActionDesecratedDuelComponent> action, EntityUid target)
    {
        if (_mob.IsAlive(target) && !TerminatingOrDeleted(target))
            return;

        ExitArena(action);
        RemCompDeferred(action.Owner, action.Comp);
    }
    #endregion
}
