// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.Actions;
using Content.Shared.Actions.Components;
using Content.Shared.EntityEffects;
using Content.Shared.Whitelist;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

/// <summary>
/// For actions, applies an effect to the action entities that the user has.
/// </summary>
[UsedImplicitly]
public sealed partial class RelayActions : EntityEffectBase<RelayActions>
{
    /// <summary>
    ///  The effect to apply
    /// </summary>
    [DataField("effect", required: true)]
    public EntityEffect TargetEffect = default!;

    /// <summary>
    /// If non-null, found entities must also match this whitelist.
    /// </summary>
    [DataField]
    public EntityWhitelist? Whitelist;

    /// <summary>
    /// If non-null, found entities must also match this blacklist.
    /// </summary>
    [DataField]
    public EntityWhitelist? Blacklist;

    public override string? EntityEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys) => null;
}

public sealed partial class RelayActionsSystem : EntityEffectSystem<ActionsComponent, RelayActions>
{
    [Dependency] private readonly SharedActionsSystem _actions = default!;
    [Dependency] private readonly EntityWhitelistSystem _whitelist = default!;
    [Dependency] private readonly SharedEntityEffectsSystem _entityEffects = default!;

    protected override void Effect(Entity<ActionsComponent> entity, ref EntityEffectEvent<RelayActions> args)
    {
        foreach (var action in _actions.GetActions(entity.Owner, entity.Comp))
        {
            if (!_whitelist.CheckBoth(action, args.Effect.Whitelist, args.Effect.Blacklist))
                continue;

            _entityEffects.ApplyEffect(action, args.Effect.TargetEffect, args.Scale, args.User);
        }
    }
}
