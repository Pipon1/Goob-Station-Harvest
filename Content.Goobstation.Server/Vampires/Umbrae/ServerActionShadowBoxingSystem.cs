// SPDX-FileCopyrightText: 2025 GoobBot <uristmchands@proton.me>
// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Goobstation.Shared.Vampires.Umbrae;
using Content.Server.Cloning;
using Content.Server.NPC.Components;
using Content.Shared.CombatMode;
using Content.Shared.Mind.Components;
using Content.Shared.NPC;
using Content.Shared.Stealth;
using Content.Shared.Stealth.Components;

namespace Content.Goobstation.Server.Vampires.Umbrae;

public sealed partial class ServerActionShadowBoxingSystem : ActionShadowBoxingSystem
{
    [Dependency] private CloningSystem _cloning = default!;
    [Dependency] private SharedStealthSystem _stealth = default!;
    [Dependency] private SharedTransformSystem _transform = default!;

    protected override EntityUid SpawnShadowClone(EntityUid user, EntityUid target)
    {
        var coordinates = _transform.GetMapCoordinates(target);
        if (!_cloning.TryCloning(user, coordinates, "ShadowCloneSettings", out var clone) || clone == null)
            return default;

        var cloneUid = clone.Value;

        // Make the clone transparent like the shadow cloak
        var stealth = EnsureComp<StealthComponent>(cloneUid);
        _stealth.SetMaxVisibility(cloneUid, 0f, stealth);
        _stealth.SetVisibility(cloneUid, 0f, stealth);

        // Remove mind so it can't be controlled or interacted with as a player
        RemCompDeferred<MindContainerComponent>(cloneUid);

        // Give the clone hostile AI to attack the target
        EnsureComp<ActiveNPCComponent>(cloneUid);
        EnsureComp<CombatModeComponent>(cloneUid);

        var melee = AddComp<NPCMeleeCombatComponent>(cloneUid);
        melee.Target = target;

        return cloneUid;
    }
}
