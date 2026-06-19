// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.Whitelist;
using Robust.Shared.Prototypes;
using Robust.Shared.Utility;
using Robust.Shared.Audio;

namespace Content.Goobstation.Shared.Administration;

/// <summary>
/// Briefing data for antag specifier.
/// </summary>
[DataDefinition]
public sealed partial class AntagSpecifierBriefing
{
    [DataField(required: true)]
    public string Text = default!;

    [DataField]
    public string? Color;

    [DataField]
    public SoundSpecifier? Sound;
}

/// <summary>
/// Prototype that defines antag selection configuration.
/// </summary>
[Prototype("antagSpecifier")]
public sealed partial class AntagSpecifierPrototype : IPrototype
{
    /// <inheritdoc/>
    [IdDataField]
    public string ID { get; private set; } = default!;

    /// <summary>
    /// Components that block this antag from being assigned.
    /// </summary>
    [DataField]
    public EntityWhitelist? Blacklist { get; set; }

    /// <summary>
    /// Preferred roles that can be selected for this antag.
    /// </summary>
    [DataField]
    public List<string>? PrefRoles { get; set; }

    /// <summary>
    /// Mind roles to assign.
    /// </summary>
    [DataField]
    public List<string>? MindRoles { get; set; }

    /// <summary>
    /// Briefing information.
    /// </summary>
    [DataField]
    public AntagSpecifierBriefing? Briefing { get; set; }

    /// <summary>
    /// Components to add to the entity.
    /// </summary>
    [DataField]
    public List<ComponentRegistryEntry>? Components { get; set; }
}

/// <summary>
/// Entry for component registry.
/// </summary>
[DataDefinition]
public sealed partial class ComponentRegistryEntry
{
    [DataField("type", required: true)]
    public string ComponentType = default!;
}
