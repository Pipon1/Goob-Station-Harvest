// SPDX-License-Identifier: AGPL-3.0-or-later

using System.Numerics;
using Content.Goobstation.Shared.Actions;
using Robust.Shared.Map;

namespace Content.Goobstation.Shared.Actions;

/// <summary>
/// Handles spawning entities at world target locations for actions with <see cref="ActionWorldTargetSpawnComponent"/>.
/// </summary>
public sealed class ActionWorldTargetSpawnSystem : EntitySystem
{
    [Dependency] private readonly SharedTransformSystem _transform = default!;

    public override void Initialize()
    {
        base.Initialize();
        SubscribeLocalEvent<WorldTargetSpawnActionEvent>(OnWorldTargetSpawn);
    }

    private void OnWorldTargetSpawn(WorldTargetSpawnActionEvent args)
    {
        if (!TryComp<ActionWorldTargetSpawnComponent>(args.Action, out var spawnComp))
            return;

        var targetCoords = args.Target;
        if (!targetCoords.IsValid(EntityManager))
            return;

        // Parse size string (e.g., "2,2" -> width=2, height=2)
        var sizeParts = spawnComp.Size.Split(',');
        if (sizeParts.Length != 2
            || !int.TryParse(sizeParts[0].Trim(), out var sizeX)
            || !int.TryParse(sizeParts[1].Trim(), out var sizeY)
            || sizeX < 1
            || sizeY < 1)
        {
            // Fallback: spawn a single entity at target
            Spawn(spawnComp.SpawnPrototype, targetCoords);
            args.Handled = true;
            return;
        }

        // Centered grid: radius = size - 1 (so size 2,2 = 3x3 grid, size 1,1 = 1x1)
        var radiusX = sizeX - 1;
        var radiusY = sizeY - 1;

        for (var x = -radiusX; x <= radiusX; x++)
        {
            for (var y = -radiusY; y <= radiusY; y++)
            {
                var offset = new Vector2(x, y);
                var spawnPos = targetCoords.Offset(offset);
                Spawn(spawnComp.SpawnPrototype, spawnPos);
            }
        }

        args.Handled = true;
    }
}
