// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.EntityEffects;
using Content.Goobstation.Shared.Vampires;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

/// <summary>
/// Effect that adjusts vampire blood.
/// </summary>
[UsedImplicitly]
public sealed partial class AdjustVampireBlood : EntityEffect
{
    /// <summary>
    /// The amount of blood to add (positive) or remove (negative).
    /// </summary>
    [DataField(required: true)]
    public int Amount;

    /// <inheritdoc/>
    protected override string? ReagentEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys) => null;

    public override void Effect(EntityEffectBaseArgs args)
    {
        if (!args.EntityManager.TryGetComponent<VampireComponent>(args.TargetEntity, out var vampire))
            return;

        var vampireSystem = args.EntityManager.System<SharedVampireSystem>();
        vampireSystem.AdjustBlood((args.TargetEntity, vampire), Amount);
    }
}
