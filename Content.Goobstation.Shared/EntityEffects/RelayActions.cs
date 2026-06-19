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
public sealed partial class RelayActions : EntityEffect
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

    protected override string? ReagentEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys) => null;

    public override void Effect(EntityEffectBaseArgs args)
    {
        if (!args.EntityManager.TryGetComponent<ActionsComponent>(args.TargetEntity, out var actions))
            return;

        var actionsSystem = args.EntityManager.System<SharedActionsSystem>();
        var whitelistSystem = args.EntityManager.System<EntityWhitelistSystem>();

        foreach (var action in actionsSystem.GetActions(args.TargetEntity, actions))
        {
            if (!whitelistSystem.CheckBoth(action, Whitelist, Blacklist))
                continue;

            TargetEffect.Effect(new EntityEffectBaseArgs(action, args.EntityManager));
        }
    }
}
