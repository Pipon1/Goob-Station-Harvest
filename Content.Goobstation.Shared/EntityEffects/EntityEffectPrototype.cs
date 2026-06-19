// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.EntityEffects;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

/// <summary>
/// Prototype that holds a list of entity effects that can be applied together.
/// </summary>
[Prototype("entityEffect")]
public sealed partial class EntityEffectPrototype : IPrototype
{
    /// <inheritdoc/>
    [IdDataField]
    public string ID { get; private set; } = default!;

    /// <summary>
    /// The effects to apply.
    /// </summary>
    [DataField(required: true)]
    public EntityEffect[] Effects = default!;
}
