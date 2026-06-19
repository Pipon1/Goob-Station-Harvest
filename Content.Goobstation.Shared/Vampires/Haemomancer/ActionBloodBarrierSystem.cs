// SPDX-License-Identifier: AGPL-3.0-or-later

using Robust.Shared.Map;
using Robust.Shared.Map.Components;
using Robust.Shared.Prototypes;
using Robust.Shared.Utility;
using System.Numerics;

namespace Content.Goobstation.Shared.Vampires.Haemomancer;

public sealed partial class ActionBloodBarrierSystem : EntitySystem
{
    [Dependency] private SharedTransformSystem _transform = default!;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<BloodBarrierActionEvent>(OnAction);
    }

    private void OnAction(BloodBarrierActionEvent args)
    {
        if (!TryComp<ActionBloodBarrierComponent>(args.Action, out var comp))
            return;

        // If the target is a point, clear the hashset.
        if (args.Entity is { } targetedEntity && comp.Points.Contains(targetedEntity))
        {
            PredictedQueueDel(targetedEntity);
            comp.Points.Clear();
            Dirty(args.Action, comp);
            return;
        }

        // Target must be a tile
        if (args.Entity is not null)
            return;

        var coords = args.Target;

        // We have one point, test if we are in distance to put another one
        if (comp.Points.Count == 1)
        {
            var pointACoords = Transform(comp.Points[0]).Coordinates;
            if (Vector2.Distance(pointACoords.Position, coords.Position) > comp.Distance)
                return;
        }

        var point = PredictedSpawnAtPosition(comp.PointProto, coords);
        comp.Points.Add(point);
        Dirty(args.Action, comp);

        // We have gathered 2 points, start the barrier
        if (comp.Points.Count == 2)
        {
            var pointA = comp.Points[0];
            var pointB = comp.Points[1];
            SpawnBarrier(Transform(pointA), Transform(pointB), comp.BarrierProto);

            // Clear both points
            foreach (var pointToDelete in comp.Points)
            {
                PredictedQueueDel(pointToDelete);
            }
            comp.Points.Clear();
            Dirty(args.Action, comp);

            args.Handled = true;
        }
    }

    /// <summary>
    /// Spawns the barrier prototype between two points.
    /// </summary>
    private void SpawnBarrier(TransformComponent pointA, TransformComponent pointB, EntProtoId barrierProto)
    {
        var a = _transform.GetMapCoordinates(pointA);
        var b = _transform.GetMapCoordinates(pointB);
        if (a == b)
            return;

        if (!pointA.GridUid.HasValue)
            return;

        var gridUid = pointA.GridUid.Value;
        if (!TryComp<MapGridComponent>(gridUid, out var grid))
            return;
        var mapSystem = EntitySystem.Get<SharedMapSystem>();
        var tileA = mapSystem.WorldToTile(gridUid, grid, a.Position);
        var tileB = mapSystem.WorldToTile(gridUid, grid, b.Position);

        var line = new GridLineEnumerator(tileA, tileB);
        while (line.MoveNext())
        {
            var tileCoords = mapSystem.GridTileToLocal(gridUid, grid, line.Current);
            PredictedSpawnAtPosition(barrierProto, tileCoords);
        }
    }
}
