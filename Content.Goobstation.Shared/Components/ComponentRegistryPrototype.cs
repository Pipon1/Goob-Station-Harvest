// SPDX-License-Identifier: AGPL-3.0-or-later

using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.Components;

/// <summary>
/// Prototype that holds a list of components that can be added/removed from entities.
/// </summary>
[Prototype("componentRegistry")]
public sealed partial class ComponentRegistryPrototype : IPrototype
{
    /// <inheritdoc/>
    [IdDataField]
    public string ID { get; private set; } = default!;

    /// <summary>
    /// The components to register.
    /// </summary>
    [DataField(required: true)]
    public List<ComponentRegistryEntry> Components = default!;
}

/// <summary>
/// Entry for component registry.
/// </summary>
[DataDefinition]
public sealed partial class ComponentRegistryEntry
{
    /// <summary>
    /// The component type name.
    /// </summary>
    [DataField("type", required: true)]
    public string Type = default!;
}
