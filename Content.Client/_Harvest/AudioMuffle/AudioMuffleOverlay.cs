using System.Numerics;
using Content.Shared._Harvest.AudioMuffle;
using Robust.Client.GameObjects;
using Robust.Client.Graphics;
using Robust.Shared.Enums;

namespace Content.Client._Harvest.AudioMuffle;

public sealed class AudioMuffleOverlay : Overlay
{
    [Dependency] private readonly IEntityManager _entMan = null!;

    private readonly SharedTransformSystem _xform;
    private readonly AudioMuffleSystem _muffle;
    private readonly MapSystem _map;

    public override OverlaySpace Space => OverlaySpace.WorldSpace;

    public AudioMuffleOverlay()
    {
        IoCManager.InjectDependencies(this);
        _xform = _entMan.System<SharedTransformSystem>();
        _muffle = _entMan.System<AudioMuffleSystem>();
        _map = _entMan.System<MapSystem>();
    }

    protected override void Draw(in OverlayDrawArgs args)
    {
        if (_muffle.ResolvePlayer() is not { } player)
            return;

        var handle = args.WorldHandle;

        var playerPos = _xform.GetMapCoordinates(player, _entMan.GetComponent<TransformComponent>(player));

        if (playerPos.MapId != args.MapId)
            return;

        if (_muffle.PlayerGrid is { } grid)
        {
            foreach (var (tile, data) in _muffle.TileDataDict)
            {
                var worldPos = _xform.ToMapCoordinates(_map.ToCenterCoordinates(grid, tile)).Position;
                var color = data.TotalCost switch
                {
                    <= 0f => Color.Green.WithAlpha(0.3f),
                    < 4f => Color.Yellow.WithAlpha(0.3f),
                    < 8f => Color.Orange.WithAlpha(0.3f),
                    _ => Color.Red.WithAlpha(0.3f),
                };
                handle.DrawRect(
                    new Box2(worldPos - new Vector2(0.45f, 0.45f), worldPos + new Vector2(0.45f, 0.45f)),
                    color);
            }
        }

        var blockerQuery = _entMan.EntityQueryEnumerator<SoundBlockerComponent, TransformComponent>();
        while (blockerQuery.MoveNext(out var uid, out var blocker, out var blockerXform))
        {
            var blockerPos = _xform.GetMapCoordinates(uid, blockerXform);
            if (blockerPos.MapId != args.MapId)
                continue;

            var color = blocker.Active
                ? Color.Red.WithAlpha(0.4f)
                : Color.Green.WithAlpha(0.4f);

            handle.DrawCircle(blockerPos.Position, 0.25f, color);
        }
    }
}
