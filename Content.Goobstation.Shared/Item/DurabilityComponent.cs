// SPDX-License-Identifier: AGPL-3.0-or-later

using Robust.Shared.GameStates;

namespace Content.Goobstation.Shared.Item;

/// <summary>
/// Tracks durability of an item that degrades with use.
/// </summary>
[RegisterComponent, NetworkedComponent]
public sealed partial class DurabilityComponent : Component
{
    /// <summary>
    /// Probability that the item takes damage on use.
    /// </summary>
    [DataField]
    public float DamageProbability = 1.0f;

    /// <summary>
    /// Minimum damage roll.
    /// </summary>
    [DataField]
    public int MinDamageRoll = 1;

    /// <summary>
    /// Maximum damage roll.
    /// </summary>
    [DataField]
    public int MaxDamageRoll = 1;

    /// <summary>
    /// Whether the item can be repaired.
    /// </summary>
    [DataField]
    public bool Repairable = false;

    /// <summary>
    /// Current durability value.
    /// </summary>
    [DataField]
    public int CurrentDurability = 0;

    /// <summary>
    /// Thresholds for durability states.
    /// </summary>
    [DataField]
    public Dictionary<int, string> DurabilityThresholds = new();
}
