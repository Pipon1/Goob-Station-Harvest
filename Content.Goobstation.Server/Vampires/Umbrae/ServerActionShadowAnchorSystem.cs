// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Goobstation.Shared.Vampires.Umbrae;
using Content.Server.Cloning;
using Content.Shared.Mind.Components;
using Content.Shared.Stealth;
using Content.Shared.Stealth.Components;
using Robust.Shared.Map;

namespace Content.Goobstation.Server.Vampires.Umbrae;

public sealed partial class ServerActionShadowAnchorSystem : SharedActionShadowAnchorSystem
{
    [Dependency] private CloningSystem _cloning = default!;
    [Dependency] private SharedStealthSystem _stealth = default!;

    protected override void SpawnShadowClone(EntityUid uid, MapCoordinates coordinates)
    {
        if (!_cloning.TryCloning(uid, coordinates, "ShadowCloneSettings", out var clone) || clone == null)
            return;

        var cloneUid = clone.Value;
        var stealth = EnsureComp<StealthComponent>(cloneUid);
        _stealth.SetMaxVisibility(cloneUid, 0f, stealth);
        _stealth.SetVisibility(cloneUid, 0f, stealth);
        RemCompDeferred<MindContainerComponent>(cloneUid);
    }
}
