// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.Beam;
using Content.Shared.Beam.Components;
using Robust.Client.GameObjects;
using Robust.Shared.GameObjects;

namespace Content.Client.Beam;

public sealed class BeamSystem : SharedBeamSystem
{
    [Dependency] private readonly SpriteSystem _sprite = default!;
    [Dependency] private readonly SharedTransformSystem _transform = default!;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeNetworkEvent<BeamVisualizerEvent>(BeamVisualizerMessage);
    }

    //TODO: Sometime in the future this needs to be replaced with tiled sprites
    private void BeamVisualizerMessage(BeamVisualizerEvent args)
    {
        var beam = GetEntity(args.Beam);

        if (TryComp<SpriteComponent>(beam, out var sprites))
        {
            // Goobstation: account for beams whose rotation is already part of the transform state.
            var worldRot = _transform.GetWorldRotation(beam);
            _sprite.SetRotation((beam, sprites), args.UserAngle - worldRot);

            if (args.BodyState != null)
            {
                _sprite.LayerSetRsiState((beam, sprites), 0, args.BodyState);
                sprites.LayerSetShader(0, args.Shader);
            }
        }
    }
}