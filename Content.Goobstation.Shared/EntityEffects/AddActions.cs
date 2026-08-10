// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.Actions;
using Content.Shared.EntityEffects;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

[UsedImplicitly]
public sealed partial class AddActions : EntityEffectBase<AddActions>
{
    [DataField(required: true)]
    public List<EntProtoId> Actions = new();

    public override string? EntityEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => null;
}

public sealed partial class AddActionsSystem : EntityEffectSystem<MetaDataComponent, AddActions>
{
    [Dependency] private readonly SharedActionsSystem _actions = default!;

    protected override void Effect(Entity<MetaDataComponent> entity, ref EntityEffectEvent<AddActions> args)
    {
        foreach (var actionProto in args.Effect.Actions)
        {
            _actions.AddAction(entity.Owner, actionProto);
        }
    }
}
