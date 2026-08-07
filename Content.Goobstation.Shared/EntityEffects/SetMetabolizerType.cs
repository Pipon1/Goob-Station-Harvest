// SPDX-FileCopyrightText: 2025 GoobBot <uristmchands@proton.me>
// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.Body.Prototypes;
using Content.Shared.EntityEffects;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

[UsedImplicitly]
public sealed partial class SetMetabolizerType : EntityEffectBase<SetMetabolizerType>
{
    [DataField]
    public HashSet<ProtoId<MetabolizerTypePrototype>> MetabolizerTypes = new();

    public override string? EntityEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => null;
}
