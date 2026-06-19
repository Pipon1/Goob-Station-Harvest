// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.Actions;
using Content.Shared.EntityEffects;
using Robust.Shared.Map;
using Robust.Shared.Prototypes;
using Robust.Shared.Timing;

namespace Content.Goobstation.Shared.Vampires.Umbrae;

public abstract partial class SharedActionShadowAnchorSystem : EntitySystem
{
    [Dependency] private IGameTiming _timing = default!;
    [Dependency] private SharedEntityEffectSystem _effects = default!;
    [Dependency] private SharedActionsSystem _action = default!;
    [Dependency] private SharedTransformSystem _transform = default!;

    private static readonly EntProtoId ShadowAnchor = "ShadowAnchor";

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<ShadowAnchorActionEvent>(OnShadowAnchor);
    }

    public override void Update(float frameTime)
    {
        base.Update(frameTime);

        var now = _timing.CurTime;
        var eqe = EntityQueryEnumerator<ActiveActionShadowAnchorComponent, ActionShadowAnchorComponent>();
        while (eqe.MoveNext(out var uid, out var active, out var anchor))
        {
            if (now < active.FakeRecallUpdate)
                continue;

            var anchorEnt = anchor.Anchor;
            if (anchorEnt is { } anchorEntity)
            {
                // Spawn clones on top of the anchor and fake a recall
                if (_action.GetAction(uid) is { } action && action.Comp.AttachedEntity is { } attachedEnt)
                {
                    foreach (var effect in anchor.EffectsOnFakeRecall)
                        _effects.Effect(effect, new EntityEffectBaseArgs(attachedEnt, EntityManager));
                    SpawnShadowClone(attachedEnt, _transform.GetMapCoordinates(anchorEntity));
                }
            }

            if (Exists(anchorEnt))
                PredictedQueueDel(anchorEnt);

            anchor.Anchor = null;
            anchor.Casted = false;
            Dirty(uid, anchor);

            RemCompDeferred(uid, active);
        }
    }

    private void OnShadowAnchor(ShadowAnchorActionEvent args)
    {
        if (!TryComp(args.Action, out ActionShadowAnchorComponent? anchor))
        {
            Log.Warning($"ShadowAnchorActionEvent raised on entity {args.Action.Owner} but it has no ActionShadowAnchorComponent");
            args.Handled = true;
            return;
        }

        var actionEnt = args.Action.Owner;
        var user = args.Performer;
        var xform = Transform(user);

        // If the action has already been cast, then just teleport us at the anchor.
        if (anchor.Casted && anchor.Anchor is { } anchorEnt)
        {
            // Use SharedTransformSystem for teleportation instead of TeleportSystem
            _transform.SetCoordinates(user, Transform(anchorEnt).Coordinates);
            anchor.Casted = false;

            // Remove anything related to the anchor, since we used our recast.
            PredictedQueueDel(anchorEnt);
            RemCompDeferred<ActiveActionShadowAnchorComponent>(actionEnt);

            anchor.Anchor = null;

            Dirty(actionEnt, anchor);

            // We only handle the action on recall, not when making the anchor.
            args.Handled = true;
            return;
        }

        var newAnchor = PredictedSpawnAtPosition(ShadowAnchor, xform.Coordinates);
        anchor.Anchor = newAnchor;
        anchor.Casted = !anchor.Casted;
        Dirty(actionEnt, anchor);

        var comp = new ActiveActionShadowAnchorComponent();
        comp.FakeRecallUpdate = _timing.CurTime + anchor.FakeRecallDuration;
        AddComp(actionEnt, comp);

        args.Handled = true;
    }

    protected virtual void SpawnShadowClone(EntityUid uid, MapCoordinates coordinates) { }
}
