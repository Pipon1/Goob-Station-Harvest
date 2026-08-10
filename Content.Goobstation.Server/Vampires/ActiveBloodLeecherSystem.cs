// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Goobstation.Shared.Vampires.Haemomancer;
using Content.Server.Beam;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Server.Vampires;

public sealed class ActiveBloodLeecherSystem : SharedActiveBloodLeecherSystem
{
    [Dependency] private BeamSystem _beam = default!;

    private static readonly EntProtoId BeamProto = "BloodBeam";

    public override void CreateBeam(EntityUid user, EntityUid target, EntProtoId beamProto)
    {
        _beam.TryCreateBeam(user, target, beamProto, accumulateIndex: false);
    }
}
