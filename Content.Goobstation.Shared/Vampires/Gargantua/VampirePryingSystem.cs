// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Goobstation.Shared.Vampires;
using Content.Shared.Popups;
using Content.Shared.Prying.Components;

namespace Content.Goobstation.Shared.Vampires.Gargantua;

public sealed partial class VampirePryingSystem : EntitySystem
{
    [Dependency] private SharedVampireSystem _vampire = default!;
    [Dependency] private SharedPopupSystem _popup = default!;

    public override void Initialize()
    {
        base.Initialize();

        // Make prying instant for vampire overwhelming force
        SubscribeLocalEvent<VampirePryingComponent, GetPryTimeModifierEvent>(OnGetPryTimeModifier);

        // Charge blood on successful pry (on the pryable entity itself)
        SubscribeLocalEvent<PryingComponent, PriedEvent>(OnPried);
    }

    private void OnGetPryTimeModifier(Entity<VampirePryingComponent> ent, ref GetPryTimeModifierEvent args)
    {
        // Vampire overwhelming force pries instantly
        args.BaseTime = 0f;
        args.PryTimeModifier = 0.01f;
    }

    private void OnPried(EntityUid uid, PryingComponent comp, ref PriedEvent args)
    {
        if (!TryComp<VampirePryingComponent>(args.User, out var vampPry))
            return;

        if (_vampire.HasUsableBlood(args.User, vampPry.BloodToRemove))
        {
            _vampire.SubtractUsableBlood(args.User, vampPry.BloodToRemove);
        }
        else
        {
            _popup.PopupClient("You do not have enough blood to maintain overwhelming force!", args.User, args.User, PopupType.SmallCaution);
        }
    }
}
