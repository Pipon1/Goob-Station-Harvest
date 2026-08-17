using Robust.Shared.GameStates;
using Robust.Shared.Serialization;

namespace Content.Shared.Materials.OreSilo;

/// <summary>
/// Provides additional materials to linked clients across long distances.
/// </summary>
[RegisterComponent, NetworkedComponent, AutoGenerateComponentState]
[Access(typeof(SharedOreSiloSystem))]
public sealed partial class OreSiloComponent : Component
{
    /// <summary>
    /// The <see cref="OreSiloClientComponent"/> that are connected to this silo.
    /// </summary>
    [DataField, AutoNetworkedField]
    public HashSet<EntityUid> Clients = new();

    /// <summary>
    /// The maximum distance you can be to the silo and still receive transmission.
    /// </summary>
    /// <remarks>
    /// Default value should be big enough to span a single large department.
    /// </remarks>
    [DataField, AutoNetworkedField]
    public float Range = 40f; // Goob - 20->40
}

[Serializable, NetSerializable]
public sealed class OreSiloBuiState : BoundUserInterfaceState
{
    public readonly HashSet<(NetEntity, string, string)> Clients;
    public readonly bool MagnetEnabled;

    public OreSiloBuiState(HashSet<(NetEntity, string, string)> clients, bool magnetEnabled)
    {
        Clients = clients;
        MagnetEnabled = magnetEnabled;
    }
}

[Serializable, NetSerializable]
public sealed class ToggleOreSiloClientMessage : BoundUserInterfaceMessage
{
    public readonly NetEntity Client;

    public ToggleOreSiloClientMessage(NetEntity client)
    {
        Client = client;
    }
}

/// <summary>
/// Sent by the silo UI when the magnet button is pressed.
/// </summary>
[Serializable, NetSerializable]
public sealed class ToggleOreSiloMagnetMessage : BoundUserInterfaceMessage
{
}

[Serializable, NetSerializable]
public enum OreSiloUiKey : byte
{
    Key
}
