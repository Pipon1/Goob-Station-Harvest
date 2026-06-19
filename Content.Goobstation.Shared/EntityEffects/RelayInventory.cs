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
public sealed partial class RelayInventory : EntityEffect
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

    protected override string? ReagentEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys) => null;

    public override void Effect(EntityEffectBaseArgs args)
    {
        if (!args.EntityManager.TryGetComponent<InventoryComponent>(args.TargetEntity, out var inventory))
            return;

        var inventorySystem = args.EntityManager.System<InventorySystem>();

        inventorySystem.TryGetContainerSlotEnumerator((args.TargetEntity, inventory), out var enumerator, SlotFlags);
        while (enumerator.NextItem(out var item))
        {
            TargetEffect.Effect(new EntityEffectBaseArgs(item, args.EntityManager));
        }
    }
}
