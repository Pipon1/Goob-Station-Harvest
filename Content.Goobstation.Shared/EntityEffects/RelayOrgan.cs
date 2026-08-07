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
public sealed partial class RelayOrgan : EntityEffectBase<RelayOrgan>
{
    [DataField]
    public string Category = string.Empty;

    [DataField("effects", required: true)]
    public List<EntityEffect> Effects = new();

    public override string? EntityEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => null;
}

public sealed partial class RelayOrganSystem : EntityEffectSystem<BodyComponent, RelayOrgan>
{
    [Dependency] private readonly SharedBodySystem _body = default!;
    [Dependency] private readonly SharedEntityEffectsSystem _entityEffects = default!;

    protected override void Effect(Entity<BodyComponent> entity, ref EntityEffectEvent<RelayOrgan> args)
    {
        foreach (var organ in _body.GetBodyOrgans(entity.Owner, entity.Comp))
        {
            if (!string.IsNullOrEmpty(args.Effect.Category))
            {
                if (!TryComp<OrganComponent>(organ.Id, out var organComp))
                    continue;

                if (!organComp.SlotId.Contains(args.Effect.Category, System.StringComparison.InvariantCultureIgnoreCase))
                    continue;
            }

            foreach (var effect in args.Effect.Effects)
            {
                _entityEffects.ApplyEffect(organ.Id, effect, args.Scale, args.User);
            }
        }
    }
}
