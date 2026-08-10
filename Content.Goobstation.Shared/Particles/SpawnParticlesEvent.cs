// SPDX-License-Identifier: AGPL-3.0-or-later

using Robust.Shared.GameObjects;
using Robust.Shared.Prototypes;
using Robust.Shared.Serialization;

namespace Content.Goobstation.Shared.Particles;

/// <summary>
/// Network event to spawn particles on a client.
/// </summary>
[Serializable, NetSerializable]
public sealed class SpawnParticlesEvent : EntityEventArgs
{
    public ProtoId<ParticleEffectPrototype> ParticleProto;
    public NetEntity Target;
    public Color? Color;
    public bool Attached;
    public int Number;
    public float? Radius;

    public SpawnParticlesEvent(ProtoId<ParticleEffectPrototype> proto, NetEntity target, Color? color, bool attached, int number, float? radius)
    {
        ParticleProto = proto;
        Target = target;
        Color = color;
        Attached = attached;
        Number = number;
        Radius = radius;
    }
}
