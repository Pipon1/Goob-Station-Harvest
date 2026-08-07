// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.EntityEffects;
using Content.Shared.Popups;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

[UsedImplicitly]
public sealed partial class PopupPredicted : EntityEffectBase<PopupPredicted>
{
    [DataField(required: true)]
    public string Message = string.Empty;

    [DataField]
    public PopupType VisualType = PopupType.Small;

    public override string? EntityEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => null;
}

public sealed partial class PopupPredictedSystem : EntityEffectSystem<MetaDataComponent, PopupPredicted>
{
    [Dependency] private readonly SharedPopupSystem _popup = default!;

    protected override void Effect(Entity<MetaDataComponent> entity, ref EntityEffectEvent<PopupPredicted> args)
    {
        _popup.PopupPredicted(args.Effect.Message, entity.Owner, entity.Owner, args.Effect.VisualType);
    }
}
