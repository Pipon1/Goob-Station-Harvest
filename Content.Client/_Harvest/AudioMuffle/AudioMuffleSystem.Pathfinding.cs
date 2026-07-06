using Content.Shared._Harvest.AudioMuffle;

namespace Content.Client._Harvest.AudioMuffle;

public sealed partial class AudioMuffleSystem
{
    /// <summary>
    /// Data for a single grid tile in the pathfinding graph.
    /// </summary>
    public sealed class MuffleTileData
    {
        public MuffleTileData? Previous;
        public float TotalCost;
    }

    /// <summary>
    /// Expands the pathfinding graph outward from a new player tile.
    /// </summary>
    private void Expand(Vector2i playerTile)
    {
        if (!_pathfindingEnabled)
            return;

        if (PlayerGrid == null)
            return;

        TileDataDict.Clear();

        var start = new MuffleTileData { TotalCost = 0f };
        TileDataDict[playerTile] = start;

        var queue = new Queue<Vector2i>();
        queue.Enqueue(playerTile);

        var grid = PlayerGrid.Value;

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            var currentData = TileDataDict[current];

            if (currentData.TotalCost >= AudioRange)
                continue;

            foreach (var neighbor in GetNeighbors(current))
            {
                if (TileDataDict.ContainsKey(neighbor))
                    continue;

                if (_map.GetTileRef(grid, neighbor).Tile.IsEmpty)
                    continue;

                var addedCost = GetTotalTileCost(neighbor);
                var newCost = currentData.TotalCost + 1f + addedCost;

                var data = new MuffleTileData
                {
                    Previous = currentData,
                    TotalCost = newCost,
                };
                TileDataDict[neighbor] = data;

                queue.Enqueue(neighbor);
            }
        }
    }

    /// <summary>
    /// Rebuilds the pathfinding graph when the player moves from one tile to another.
    /// </summary>
    private void RebuildAndExpand(Vector2i newTile, Vector2i oldTile)
    {
        if (!_pathfindingEnabled)
            return;

        if (PlayerGrid == null)
            return;

        TileDataDict.Clear();

        var start = new MuffleTileData { TotalCost = 0f };
        TileDataDict[newTile] = start;

        var queue = new Queue<Vector2i>();
        queue.Enqueue(newTile);

        var grid = PlayerGrid.Value;

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            var currentData = TileDataDict[current];

            if (currentData.TotalCost >= AudioRange)
                continue;

            foreach (var neighbor in GetNeighbors(current))
            {
                if (TileDataDict.ContainsKey(neighbor))
                    continue;

                if (_map.GetTileRef(grid, neighbor).Tile.IsEmpty)
                    continue;

                var addedCost = GetTotalTileCost(neighbor);
                var newCost = currentData.TotalCost + 1f + addedCost;

                var data = new MuffleTileData
                {
                    Previous = currentData,
                    TotalCost = newCost,
                };
                TileDataDict[neighbor] = data;

                queue.Enqueue(neighbor);
            }
        }

        _ = oldTile;
    }

    private void AddOrRemoveBlocker(
        Entity<SoundBlockerComponent> blocker,
        Vector2i tile,
        bool add,
        bool updateCost)
    {
        if (add)
        {
            blocker.Comp.Indices = tile;

            if (!_reverseBlockerIndicesDict.TryGetValue(tile, out var set))
            {
                set = new HashSet<Entity<SoundBlockerComponent>>();
                _reverseBlockerIndicesDict[tile] = set;
            }

            set.Add(blocker);

            if (updateCost && TileDataDict.TryGetValue(tile, out var data))
            {
                var cost = GetBlockerCost(blocker.Comp);
                ModifyBlockerAmount(data, cost);
            }
        }
        else
        {
            if (_reverseBlockerIndicesDict.TryGetValue(tile, out var set))
            {
                set.Remove(blocker);
                if (set.Count == 0)
                    _reverseBlockerIndicesDict.Remove(tile);
            }

            if (updateCost && TileDataDict.TryGetValue(tile, out var data))
            {
                var cost = GetBlockerCost(blocker.Comp);
                ModifyBlockerAmount(data, -cost);
            }

            blocker.Comp.Indices = null;
        }
    }

    private void ModifyBlockerAmount(MuffleTileData data, float delta)
    {
        var current = data;
        while (current != null)
        {
            current.TotalCost += delta;
            current = current.Previous;
        }
    }

    private static IEnumerable<Vector2i> GetNeighbors(Vector2i tile)
    {
        yield return tile + new Vector2i(1, 0);
        yield return tile + new Vector2i(-1, 0);
        yield return tile + new Vector2i(0, 1);
        yield return tile + new Vector2i(0, -1);
    }

    private static int ManhattanDistance(Vector2i a, Vector2i b)
    {
        return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
    }
}
