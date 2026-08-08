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

    // Beams are currently stretched single sprites; tiling them would improve visual quality.
    private void BeamVisualizerMessage(BeamVisualizerEvent args)
    {
        var beam = GetEntity(args.Beam);

        if (TryComp<SpriteComponent>(beam, out var sprites))
        {
            // Beams whose rotation is already in the transform state only need a relative sprite rotation.
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