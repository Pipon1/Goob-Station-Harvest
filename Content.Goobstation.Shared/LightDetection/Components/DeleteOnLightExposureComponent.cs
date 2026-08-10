using Robust.Shared.GameStates;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom;

namespace Content.Goobstation.Shared.LightDetection.Components;

/// <summary>
/// Deletes the entity when exposed to light above a threshold for a specified duration.
/// </summary>
[RegisterComponent, NetworkedComponent, AutoGenerateComponentState(false, true), AutoGenerateComponentPause]
public sealed partial class DeleteOnLightExposureComponent : Component
{
    /// <summary>
    /// Light level threshold that triggers deletion.
    /// </summary>
    [DataField, AutoNetworkedField]
    public float LightLevel = 1.5f;

    /// <summary>
    /// Duration the entity must be exposed to light before being deleted.
    /// </summary>
    [DataField, AutoNetworkedField]
    public float Duration = 5f;

    /// <summary>
    /// Current accumulated exposure time.
    /// </summary>
    [ViewVariables, AutoNetworkedField]
    public float AccumulatedTime;

    [DataField(customTypeSerializer:typeof(TimeOffsetSerializer))]
    [AutoPausedField]
    public TimeSpan NextUpdate;

    [DataField]
    public TimeSpan UpdateInterval = TimeSpan.FromSeconds(1f);
}
