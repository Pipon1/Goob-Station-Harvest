// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.EntityEffects;
using Content.Shared.Hands.Components;
using Content.Shared.Hands.EntitySystems;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

/// <summary>
/// For hands, applies an effect to the entities that the user is holding.
/// </summary>
[UsedImplicitly]
public sealed partial class RelayHands : EntityEffect
{
    /// <summary>
    /// The effect to apply
    /// </summary>
    [DataField("effect", required: true)]
    public EntityEffect TargetEffect = default!;

    protected override string? ReagentEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys) => null;

    public override void Effect(EntityEffectBaseArgs args)
    {
        if (!args.EntityManager.TryGetComponent<HandsComponent>(args.TargetEntity, out var hands))
            return;

        var handsSystem = args.EntityManager.System<SharedHandsSystem>();

        foreach (var item in handsSystem.EnumerateHeld((args.TargetEntity, hands)))
        {
            TargetEffect.Effect(new EntityEffectBaseArgs(item, args.EntityManager));
        }
    }
}
