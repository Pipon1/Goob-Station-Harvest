// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Goobstation.Shared.Vampires;
using Content.Shared.EntityEffects;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

/// <summary>
/// Entity effect that grants vampire blood to entities with <see cref="VampireComponent"/>.
/// Used as a metabolism effect when vampires ingest blood reagents.
/// </summary>
[UsedImplicitly]
public sealed partial class VampireGainBlood : EntityEffect
{
    /// <summary>
    /// How much vampire blood is gained per metabolism tick.
    /// </summary>
    [DataField]
    public int Amount = 5;

    protected override string? ReagentEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => null;

    public override void Effect(EntityEffectBaseArgs args)
    {
        if (!args.EntityManager.HasComponent<VampireComponent>(args.TargetEntity))
            return;

        var vampireSystem = args.EntityManager.System<SharedVampireSystem>();
        vampireSystem.AdjustBlood(args.TargetEntity, Amount);
    }
}
