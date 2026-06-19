// SPDX-FileCopyrightText: 2025 GoobBot <uristmchands@proton.me>
// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.Body.Components;
using Content.Shared.Body.Organ;
using Content.Shared.Body.Systems;
using Content.Shared.EntityEffects;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

[UsedImplicitly]
public sealed partial class RelayOrgan : EntityEffect
{
    [DataField]
    public string Category = string.Empty;

    [DataField("effects", required: true)]
    public List<EntityEffect> Effects = new();

    protected override string? ReagentEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => null;

    public override void Effect(EntityEffectBaseArgs args)
    {
        if (!args.EntityManager.TryGetComponent<BodyComponent>(args.TargetEntity, out var body))
            return;

        var bodySystem = args.EntityManager.System<SharedBodySystem>();

        foreach (var organ in bodySystem.GetBodyOrgans(args.TargetEntity, body))
        {
            // Check if the organ has the specified category
            if (!string.IsNullOrEmpty(Category))
            {
                if (!args.EntityManager.TryGetComponent<OrganComponent>(organ.Id, out var organComp))
                    continue;

                if (!organComp.SlotId.Contains(Category, System.StringComparison.InvariantCultureIgnoreCase))
                    continue;
            }

            foreach (var effect in Effects)
            {
                effect.Effect(new EntityEffectBaseArgs(organ.Id, args.EntityManager));
            }
        }
    }
}
