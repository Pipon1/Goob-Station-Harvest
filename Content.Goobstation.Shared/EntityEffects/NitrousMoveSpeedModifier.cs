using Content.Shared.EntityEffects;
using Content.Shared.Movement.Components;
using Content.Shared.Movement.Systems;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

/// <summary>
/// Temporarily applies a movement speed modifier to the target.
/// </summary>
public sealed partial class NitrousMovespeedModifier : EntityEffectBase<NitrousMovespeedModifier>
{
    /// <summary>
    /// How much the entities' walk speed is multiplied by.
    /// </summary>
    [DataField]
    public float SpeedModifier = 1f;

    /// <summary>
    /// How long the modifier refreshes for
    /// </summary>
    [DataField]
    public TimeSpan Time = TimeSpan.FromSeconds(6f);

    public override string? EntityEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => Loc.GetString("entity-effect-guidebook-movespeed-modifier",
            ("chance", Probability),
            ("walkspeed", SpeedModifier),
            ("sprintspeed", SpeedModifier),
            ("time", Time.TotalSeconds));
}

/// <summary>
/// Remove reagent at set rate, changes the movespeed modifiers and adds a MovespeedModifierMetabolismComponent if not already there.
/// </summary>
public sealed class NitrousMovespeedModifierEffectSystem : EntityEffectSystem<InputMoverComponent, NitrousMovespeedModifier>
{
    [Dependency] private readonly MovementModStatusSystem _movementMod = default!;

    public static readonly EntProtoId StatusEffect = "NitrousStatusEffect";

    protected override void Effect(Entity<InputMoverComponent> ent, ref EntityEffectEvent<NitrousMovespeedModifier> args)
    {
        _movementMod.TryAddMovementSpeedModDuration(ent, StatusEffect, args.Effect.Time, args.Effect.SpeedModifier);
    }
}
