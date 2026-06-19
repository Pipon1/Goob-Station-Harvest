// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.EntityEffects;
using Content.Shared.Examine;
using Content.Shared.Mobs.Systems;
using Robust.Shared.Analyzers;
using Robust.Shared.Timing;

namespace Content.Goobstation.Shared.Vampires.Umbrae;

[Virtual]
public partial class ActionShadowBoxingSystem : EntitySystem
{
    [Dependency] private IGameTiming _timing = default!;
    [Dependency] private ExamineSystemShared _examine = default!;
    [Dependency] private SharedEntityEffectSystem _effects = default!;
    [Dependency] private MobStateSystem _mob = default!;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<ShadowBoxingActionEvent>(OnShadowBox);
    }

    public override void Update(float frameTime)
    {
        base.Update(frameTime);

        var now = _timing.CurTime;

        var eqe = EntityQueryEnumerator<ActiveActionShadowBoxingComponent, ActionShadowBoxingComponent>();
        while (eqe.MoveNext(out var uid, out var active, out var comp))
        {
            if (now < active.NextUpdate)
                continue;

            active.NextUpdate = now + comp.Update;
            Dirty(uid, active);

            var target = active.Target;

            // Clone expires after 10 seconds regardless of distance
            if (now >= active.CloneExpireTime)
            {
                if (active.Clone != default && Exists(active.Clone))
                    PredictedQueueDel(active.Clone);

                RemCompDeferred(uid, active);
                continue;
            }

            // Effects apply as long as the target is alive (clone is doing the work)
            if (_mob.IsAlive(target))
            {
                foreach (var effect in comp.TargetEffects)
                    _effects.Effect(effect, new EntityEffectBaseArgs(target, EntityManager));
            }
        }
    }

    private void OnShadowBox(ShadowBoxingActionEvent args)
    {
        if (!TryComp(args.Action, out ActionShadowBoxingComponent? boxing))
            return;

        var actionEnt = args.Action.Owner;
        var comp = EnsureComp<ActiveActionShadowBoxingComponent>(actionEnt);

        // Clean up any previous clone before spawning a new one
        if (comp.Clone != default && Exists(comp.Clone))
            PredictedQueueDel(comp.Clone);

        var clone = SpawnShadowClone(args.Performer, args.Target);
        comp.Clone = clone;
        comp.NextUpdate = _timing.CurTime + boxing.Update;
        comp.CloneExpireTime = _timing.CurTime + TimeSpan.FromSeconds(10);
        comp.Target = args.Target;
        comp.User = args.Performer;

        Dirty(actionEnt, comp);
        args.Handled = true;
    }

    protected virtual EntityUid SpawnShadowClone(EntityUid user, EntityUid target)
    {
        return default;
    }
}
