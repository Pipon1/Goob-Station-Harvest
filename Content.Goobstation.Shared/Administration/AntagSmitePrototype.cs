// SPDX-License-Identifier: AGPL-3.0-or-later

using Robust.Shared.Prototypes;
using Robust.Shared.Utility;

namespace Content.Goobstation.Shared.Administration;

/// <summary>
/// Prototype that defines admin smite configuration for an antag.
/// </summary>
[Prototype("antagSmite")]
public sealed partial class AntagSmitePrototype : IPrototype
{
    /// <inheritdoc/>
    [IdDataField]
    public string ID { get; private set; } = default!;

    /// <summary>
    /// The antag prototype ID.
    /// </summary>
    [DataField(required: true)]
    public string Antag = default!;

    /// <summary>
    /// The game rule prototype ID.
    /// </summary>
    [DataField(required: true)]
    public string Rule = default!;

    /// <summary>
    /// The component name for the rule.
    /// </summary>
    [DataField(required: true)]
    public string RuleComp = default!;

    /// <summary>
    /// Icon to display in the admin smite menu.
    /// </summary>
    [DataField]
    public SpriteSpecifier? Icon;
}
