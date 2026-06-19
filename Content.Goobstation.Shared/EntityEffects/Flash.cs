// SPDX-License-Identifier: AGPL-3.0-or-later

using System;
using Content.Shared.EntityEffects;
using Content.Shared.Flash;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

[UsedImplicitly]
public sealed partial class Flash : EntityEffect
{
    [DataField]
    public float SlowTo = 0.5f;

    [DataField]
    public float MaxRange = 10f;

    [DataField]
    public float Duration = 4f;

    protected override string? ReagentEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => null;

    public override void Effect(EntityEffectBaseArgs args)
    {
        var flashSystem = args.EntityManager.System<SharedFlashSystem>();
        flashSystem.Flash(
            args.TargetEntity,
            user: null,
            used: null,
            flashDuration: TimeSpan.FromSeconds(Duration),
            slowTo: SlowTo);
    }
}
