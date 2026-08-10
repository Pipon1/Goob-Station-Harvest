// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.EntityEffects;
using Robust.Shared.Audio;
using Robust.Shared.GameObjects;
using Robust.Shared.GameStates;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom;

namespace Content.Goobstation.Shared.Vampires.Haemomancer;

/// <summary>
/// Component that enables active blood leeching from nearby entities.
/// </summary>
[RegisterComponent, NetworkedComponent]
[AutoGenerateComponentState, AutoGenerateComponentPause]
public sealed partial class ActiveBloodLeecherComponent : Component
{
    /// <summary>
    /// How much blood is required to continue leeching.
    /// </summary>
    [DataField]
    public int BloodRequired = 10;

    /// <summary>
    /// Range to search for drainable entities.
    /// </summary>
    [DataField]
    public float Range = 5f;

    /// <summary>
    /// Maximum number of entities to drain at once.
    /// </summary>
    [DataField]
    public int MaxEntities = 3;

    /// <summary>
    /// Effects to apply to targeted entities.
    /// </summary>
    [DataField]
    public EntityEffect[]? TargetEffects;

    /// <summary>
    /// Effects to apply to the user.
    /// </summary>
    [DataField]
    public EntityEffect[]? UserEffects;

    /// <summary>
    /// How often to apply effects.
    /// </summary>
    [DataField]
    public TimeSpan UpdateRate = TimeSpan.FromSeconds(2f);

    /// <summary>
    /// The music to play during the action.
    /// </summary>
    [DataField]
    public SoundSpecifier? Music;

    /// <summary>
    /// The music entity, used to stop it when the component shuts down.
    /// </summary>
    [DataField]
    public EntityUid? MusicEntity;

    /// <summary>
    /// Next time to update.
    /// </summary>
    [DataField(customTypeSerializer: typeof(TimeOffsetSerializer)), AutoNetworkedField]
    [AutoPausedField]
    public TimeSpan NextUpdate;
}
