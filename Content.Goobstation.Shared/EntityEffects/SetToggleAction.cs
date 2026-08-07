// SPDX-FileCopyrightText: 2025 GoobBot <uristmchands@proton.me>
// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Goobstation.Shared.Actions;
using Content.Shared.Actions;
using Content.Shared.Actions.Components;
using Content.Shared.EntityEffects;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

[UsedImplicitly]
public sealed partial class SetToggleAction : EntityEffectBase<SetToggleAction>
{
    [DataField]
    public bool Toggled = false;

    public override string? EntityEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => null;
}

public sealed partial class SetToggleActionSystem : EntityEffectSystem<ActionsComponent, SetToggleAction>
{
    [Dependency] private readonly SharedActionsSystem _actions = default!;

    protected override void Effect(Entity<ActionsComponent> entity, ref EntityEffectEvent<SetToggleAction> args)
    {
        _actions.SetToggled(entity.Owner, args.Effect.Toggled);

        if (TryComp<ToggleEffectActionComponent>(entity.Owner, out var toggleComp))
        {
            toggleComp.Toggled = args.Effect.Toggled;
            Dirty(entity.Owner, toggleComp);
        }
    }
}
