// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.EntityEffects;
using Content.Shared.Cloning;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

[UsedImplicitly]
public sealed partial class SpawnClone : EntityEffectBase<SpawnClone>
{
    [DataField]
    public ProtoId<CloningSettingsPrototype> Settings = default!;

    public override string? EntityEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => null;
}
