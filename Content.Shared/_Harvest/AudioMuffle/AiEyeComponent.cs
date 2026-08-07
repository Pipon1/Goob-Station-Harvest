using Robust.Shared.GameStates;

namespace Content.Shared._Harvest.AudioMuffle;

/// <summary>
/// Added to AI eye entities, used for audio muffle calculations.
/// </summary>
[RegisterComponent, NetworkedComponent]
public sealed partial class AiEyeComponent : Component;
