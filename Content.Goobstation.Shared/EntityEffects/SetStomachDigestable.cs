// SPDX-FileCopyrightText: 2025 GoobBot <uristmchands@proton.me>
// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.Body.Systems;
using Content.Shared.EntityEffects;
using Content.Shared.Whitelist;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

[UsedImplicitly]
public sealed partial class SetStomachDigestable : EntityEffect
{
    [DataField]
    public EntityWhitelist? SpecialDigestible;

    protected override string? ReagentEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => null;

    public override void Effect(EntityEffectBaseArgs args)
    {
        var stomachSystem = args.EntityManager.System<StomachSystem>();
        stomachSystem.SetSpecialDigestible(args.TargetEntity, SpecialDigestible);
    }
}
