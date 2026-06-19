// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.Administration.Logs;
using Content.Shared.Database;
using Robust.Shared.Map;
using Robust.Shared.Network;
using Robust.Shared.Prototypes;
using Robust.Shared.Timing;
using System.Numerics;

namespace Content.Goobstation.Shared.Arena;

public sealed partial class ArenaCreationSystem : EntitySystem
{
    [Dependency] private IGameTiming _timing = default!;
    [Dependency] private INetManager _net = default!;
    [Dependency] private ISharedAdminLogManager _admin = default!;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<ArenaTargetActionEvent>(OnPerformed);
    }

    public override void Update(float frameTime)
    {
        base.Update(frameTime);

        var now = _timing.CurTime;

        var activeQuery = EntityQueryEnumerator<ActiveActionArenaComponent, ActionArenaComponent>();
        while (activeQuery.MoveNext(out var uid, out var active, out var arena))
        {
            if (active.NextCheck > now)
                continue;

            var walls = CreateArena(arena.Target, arena.ArenaSize, arena.WallProto, arena.Predicted);
            StoreWalls((uid, arena), walls);

            RemCompDeferred(uid, active);
        }
    }

    private void OnPerformed(ArenaTargetActionEvent args)
    {
        var actionUid = args.Action.Owner;
        if (!TryComp<ActionArenaComponent>(actionUid, out var comp))
            return;

        if (comp.Delay is { } delay)
        {
            comp.Target = args.Target;
            Dirty(actionUid, comp);

            var active = new ActiveActionArenaComponent();
            active.NextCheck = _timing.CurTime + delay;
            AddComp(actionUid, active, true);
            Dirty(actionUid, active);
            return;
        }

        // There's no delay so just spawn the arena and store the walls
        var wallList = CreateArena(args.Target, comp.ArenaSize, comp.WallProto, comp.Predicted);
        StoreWalls((actionUid, comp), wallList);

        // Clear the target so it doesn't mess with future action uses.
        comp.Target = null;
        Dirty(actionUid, comp);
    }

    #region Public Api
    /// <summary>
    /// Spawns an area at the <see cref="EntityCoordinates"/> of an entity.
    /// </summary>
    public List<EntityUid>? CreateArena(EntityUid? target, int arenaSize, EntProtoId wallProto, bool predicted)
    {
        if (target is not { } spawnAt)
            return null;

        var coords = Transform(spawnAt).Coordinates;
        return CreateArena(coords, arenaSize, wallProto, predicted);
    }

    /// <summary>
    /// Spawns an area at the <see cref="EntityCoordinates"/> of an entity.
    /// </summary>
    public List<EntityUid>? CreateArena(EntityCoordinates coords, int arenaSize, EntProtoId wallProto, bool predicted)
    {
        _admin.Add(LogType.EntitySpawn, LogImpact.Medium, $"An arena of size {arenaSize} has been created at {coords}");

        // We only spawn the walls in the edges of the area.
        var walls = new List<EntityUid>();

        var rsq = arenaSize * (arenaSize + 0.5f);
        var innerSq = rsq - arenaSize;
        for (int x = -arenaSize; x <= arenaSize; x++)
        {
            for (int y = -arenaSize; y <= arenaSize; y++)
            {
                float distSq = (x * x) + (y * y);
                if (distSq > innerSq && distSq <= rsq)
                {
                    var spawnCoords = coords.Offset(new Vector2(x, y));
                    if (predicted)
                    {
                        var wall = PredictedSpawnAtPosition(wallProto, spawnCoords);
                        walls.Add(wall);
                        continue;
                    }

                    // Non-predicted spawning
                    if (_net.IsServer)
                    {
                        var wall = SpawnAtPosition(wallProto, spawnCoords);
                        walls.Add(wall);
                    }
                }
            }
        }

        return walls;
    }

    /// <summary>
    /// Clears an arena manually (used only for the action component).
    /// </summary>
    public void DestroyArena(Entity<ActionArenaComponent?> ent)
    {
        if (!Resolve(ent.Owner, ref ent.Comp, false))
            return;

        var toDelete = new List<EntityUid>();
        foreach (var arena in ent.Comp.Walls)
        {
            toDelete.Add(arena);
        }
        ent.Comp.Walls.Clear();

        foreach (var arena in toDelete)
        {
            PredictedQueueDel(arena);
        }
    }
    #endregion

    #region Helper
    /// <summary>
    /// Helper to store wall entities into the action component.
    /// </summary>
    private void StoreWalls(Entity<ActionArenaComponent> ent, List<EntityUid>? wallList)
    {
        if (wallList is not { } walls || walls.Count == 0)
            return;

        foreach (var wall in walls)
        {
            ent.Comp.Walls.Add(wall);
        }

        Dirty(ent);
    }
    #endregion
}
