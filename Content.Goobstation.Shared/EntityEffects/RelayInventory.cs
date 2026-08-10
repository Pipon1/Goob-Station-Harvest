// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.EntityEffects;
using Content.Shared.Inventory;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

/// <summary>
/// For an entity with an inventory, applies an effect to all items in the inventory within specific <see cref="SlotFlags"/>.
/// </summary>
[UsedImplicitly]
public sealed partial class RelayInventory : EntityEffectBase<RelayInventory>
{
    /// <summary>
    /// Effect to apply to the items.
    /// </summary>
    [DataField("effect", required: true)]
    public EntityEffect TargetEffect = default!;

    /// <summary>
    /// Which slot flags to look for.
    /// </summary>
    [DataField]
    public SlotFlags SlotFlags = SlotFlags.NONE;

    public override string? EntityEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys) => null;
}

public sealed partial class RelayInventorySystem : EntityEffectSystem<InventoryComponent, RelayInventory>
{
    [Dependency] private readonly InventorySystem _inventory = default!;
    [Dependency] private readonly SharedEntityEffectsSystem _entityEffects = default!;

    protected override void Effect(Entity<InventoryComponent> entity, ref EntityEffectEvent<RelayInventory> args)
    {
        _inventory.TryGetContainerSlotEnumerator((entity.Owner, entity.Comp), out var enumerator, args.Effect.SlotFlags);
        while (enumerator.NextItem(out var item))
        {
            _entityEffects.ApplyEffect(item, args.Effect.TargetEffect, args.Scale, args.User);
        }
    }
}
