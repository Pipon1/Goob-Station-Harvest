// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Goobstation.Shared.Vampires;
using Content.Shared.Weapons.Melee.Events;

namespace Content.Goobstation.Server.Vampires;

/// <summary>
///     Server-side implementation of vampire bloodsucking system.
/// </summary>
public sealed class ServerVampireBloodsuckingSystem : SharedVampireBloodsuckingSystem
{
    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<VampireBloodsuckingComponent, MeleeHitEvent>(OnMeleeHit);
        SubscribeLocalEvent<VampireBloodsuckingComponent, BloodSuckDoAfterEvent>(OnBloodSuckDoAfter);
    }
}
