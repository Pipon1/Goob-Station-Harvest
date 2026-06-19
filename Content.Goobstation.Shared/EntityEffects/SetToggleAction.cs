// SPDX-FileCopyrightText: 2025 GoobBot <uristmchands@proton.me>
// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Goobstation.Shared.Actions;
using Content.Shared.Actions;
using Content.Shared.EntityEffects;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

[UsedImplicitly]
public sealed partial class SetToggleAction : EntityEffect
{
    [DataField]
    public bool Toggled = false;

    protected override string? ReagentEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => null;

    public override void Effect(EntityEffectBaseArgs args)
    {
        var actionsSystem = args.EntityManager.System<SharedActionsSystem>();
        actionsSystem.SetToggled(args.TargetEntity, Toggled);

        if (args.EntityManager.TryGetComponent<ToggleEffectActionComponent>(args.TargetEntity, out var toggleComp))
        {
            toggleComp.Toggled = Toggled;
            args.EntityManager.Dirty(args.TargetEntity, toggleComp);
        }
    }
}
