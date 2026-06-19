// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Goobstation.Shared.Particles;
using Robust.Shared.Player;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Server.Particles;

public sealed class SpawnParticlesEffectSystem : SharedSpawnParticlesEffectSystem
{
    protected override void SpawnParticles(ProtoId<ParticleEffectPrototype> particleProto, EntityUid target, Color? color, bool attached, float? radius)
    {
        base.SpawnParticles(particleProto, target, color, attached, radius);

        var ev = new SpawnParticlesEvent(
            particleProto,
            GetNetEntity(target),
            color,
            attached,
            1,
            radius
        );

        RaiseNetworkEvent(ev, Filter.Pvs(target));
    }
}
