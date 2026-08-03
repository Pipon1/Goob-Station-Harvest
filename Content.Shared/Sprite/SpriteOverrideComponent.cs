using System.Numerics;
using Robust.Shared.GameStates;

namespace Content.Shared.Sprite;

/// <summary>
/// Allows overriding the entity's sprite RSI path and state from VV.
/// </summary>
[RegisterComponent, NetworkedComponent, AutoGenerateComponentState(true)]
[Access(typeof(SharedSpriteOverrideSystem), Other = AccessPermissions.ReadWriteExecute)]
public sealed partial class SpriteOverrideComponent : Component
{
    /// <summary>
    /// Path to the RSI file (e.g. "Mobs/Animals/mouse.rsi").
    /// </summary>
    [DataField, AutoNetworkedField]
    public string? RSIPath;

    /// <summary>
    /// State to use within the RSI.
    /// </summary>
    [DataField, AutoNetworkedField]
    public string? RSIState;

    /// <summary>
    /// Optional scale override applied alongside the sprite change.
    /// </summary>
    [DataField, AutoNetworkedField]
    public Vector2? Scale;
}
