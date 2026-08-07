// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.EntityEffects;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

[UsedImplicitly]
public sealed partial class AdjustReagentGroup : EntityEffectBase<AdjustReagentGroup>
{
    [DataField("amount", required: true)]
    public float Amount = 0f;

    [DataField("group", required: true)]
    public string Group = string.Empty;

    public override string? EntityEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => null;
}
