// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Goobstation.Shared.Actions;
using Content.Goobstation.Shared.Vampires.Haemomancer;
using Content.Shared.Mind.Components;
using Content.Shared.Mobs.Systems;
using Content.Shared.Damage;
using Content.Shared.Humanoid;
using Content.Shared.IdentityManagement;
using Content.Shared.Mobs.Components;
using Content.Shared.Popups;
using Robust.Shared.Map;
using System.Linq;

namespace Content.Goobstation.Server.Vampires;

public sealed class PredatorSensesSystem : EntitySystem
{
    [Dependency] private SharedTransformSystem _transform = default!;
    [Dependency] private SharedPopupSystem _popup = default!;
    [Dependency] private MobStateSystem _mobState = default!;
    [Dependency] private DamageableSystem _damage = default!;

    public override void Initialize()
    {
        base.Initialize();
        SubscribeLocalEvent<PredatorSensesActionEvent>(OnAction);
    }

    private void OnAction(PredatorSensesActionEvent args)
    {
        var user = args.Performer;

        var userMapPos = _transform.GetMapCoordinates(user);
        var userXform = Transform(user);
        var foundAny = false;
        var messages = new List<string>();

        var query = EntityQueryEnumerator<HumanoidAppearanceComponent, MobStateComponent, MindContainerComponent>();
        while (query.MoveNext(out var uid, out _, out var mobState, out var mind))
        {
            if (uid == user)
                continue;

            if (!mind.HasMind)
                continue;

            if (_mobState.IsDead(uid, mobState) || _mobState.IsIncapacitated(uid, mobState))
                continue;

            var targetXform = Transform(uid);
            if (targetXform.MapID != userXform.MapID)
                continue;

            foundAny = true;
            var targetPos = _transform.GetMapCoordinates(uid);
            var distance = (targetPos.Position - userMapPos.Position).Length();
            var direction = distance > 0.1f ? (targetPos.Position - userMapPos.Position).Normalized() : System.Numerics.Vector2.Zero;

            var name = Identity.Name(uid, EntityManager);
            var dirStr = DirectionString(direction);
            var distStr = distance < 1f ? "right next to you" : $"~{distance:F0}m {dirStr}";

            var woundStr = "";
            if (TryComp<DamageableComponent>(uid, out var damage) && damage.TotalDamage.Float() >= 60f)
                woundStr = " (wounded!)";

            messages.Add($"- {name}: {distStr}{woundStr}");
        }

        if (messages.Count == 0)
        {
            _popup.PopupEntity("You sense no prey nearby.", user, user);
            return;
        }

        // Show results in batches to avoid popup overflow
        _popup.PopupEntity("You sense the following prey:", user, user);
        foreach (var msg in messages.Take(8))
        {
            _popup.PopupEntity(msg, user, user);
        }

        if (messages.Count > 8)
        {
            _popup.PopupEntity($"...and {messages.Count - 8} more.", user, user);
        }
    }

    private static string DirectionString(System.Numerics.Vector2 dir)
    {
        if (dir.Length() < 0.1f)
            return "nearby";

        var angle = dir.ToAngle();
        return angle.Degrees switch
        {
            >= -22.5f and < 22.5f => "to the northwest",
            >= 22.5f and < 67.5f => "to the west",
            >= 67.5f and < 112.5f => "to the southwest",
            >= 112.5f and < 157.5f => "to the south",
            >= 157.5f or < -157.5f => "to the southeast",
            >= -157.5f and < -112.5f => "to the east",
            >= -112.5f and < -67.5f => "to the northeast",
            >= -67.5f and < -22.5f => "to the north",
            _ => "away",
        };
    }
}
