// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.EntityEffects;
using Content.Shared.Popups;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

[UsedImplicitly]
public sealed partial class PopupPredicted : EntityEffect
{
    [DataField(required: true)]
    public string Message = string.Empty;

    [DataField]
    public PopupType VisualType = PopupType.Small;

    protected override string? ReagentEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => null;

    public override void Effect(EntityEffectBaseArgs args)
    {
        var popupSys = args.EntityManager.System<SharedPopupSystem>();
        popupSys.PopupPredicted(Message, args.TargetEntity, args.TargetEntity, VisualType);
    }
}
