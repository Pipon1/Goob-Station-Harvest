// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.Popups;
using Content.Shared.Weapons.Ranged.Events;
using JetBrains.Annotations;

namespace Content.Goobstation.Shared.StatusEffects;

/// <summary>
/// System that prevents entities with UnableToShootStatusEffectComponent from using guns.
/// </summary>
[UsedImplicitly]
public sealed class UnableToShootStatusEffectSystem : EntitySystem
{
    [Dependency] private SharedPopupSystem _popup = default!;

    public override void Initialize()
    {
        base.Initialize();
        SubscribeLocalEvent<UnableToShootStatusEffectComponent, ShotAttemptedEvent>(OnShotAttempted);
    }

    private void OnShotAttempted(Entity<UnableToShootStatusEffectComponent> ent, ref ShotAttemptedEvent args)
    {
        args.Cancel();
        _popup.PopupClient("Your blood-swollen hands can't operate a gun!", ent.Owner, PopupType.MediumCaution);
    }
}
