// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Goobstation.Shared.MobClass;
using JetBrains.Annotations;
using Robust.Client.UserInterface;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Client.MobClass;

[UsedImplicitly]
public sealed class MobClassSelectorBui(EntityUid owner, Enum uiKey) : BoundUserInterface(owner, uiKey)
{
    private MobClassSelectorWindow? _window;

    protected override void Open()
    {
        base.Open();

        _window = this.CreateWindow<MobClassSelectorWindow>();
        _window.OpenCentered();

        _window.Specialize += Specialize;
    }

    private void Specialize(ProtoId<MobClassPrototype>? obj)
    {
        if (obj is not { } mobClass)
            return;

        SendPredictedMessage(new MobClassSelectedMessage(mobClass));
    }

    protected override void UpdateState(BoundUserInterfaceState state)
    {
        base.UpdateState(state);

        if (state is not MobClassState selectorState)
            return;

        _window?.PopulateWindow(selectorState.Group);
    }
}
