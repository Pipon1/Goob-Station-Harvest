// SPDX-FileCopyright-Identifier: AGPL-3.0-or-later

using Content.Goobstation.Shared.Administration;
using Content.Server.Antag;
using Content.Shared.EntityEffects;
using Robust.Shared.GameObjects;

namespace Content.Goobstation.Server.Administration.Systems;

/// <summary>
///     Applies entity effects defined in <see cref="AntagPlayerEffectsComponent"/> when an antag is selected.
/// </summary>
public sealed class AntagPlayerEffectsSystem : EntitySystem
{
    [Dependency] private readonly SharedEntityEffectSystem _effects = default!;

    public override void Initialize()
    {
        base.Initialize();
        SubscribeLocalEvent<AntagPlayerEffectsComponent, AfterAntagEntitySelectedEvent>(OnAntagSelected);
    }

    private void OnAntagSelected(Entity<AntagPlayerEffectsComponent> ent, ref AfterAntagEntitySelectedEvent args)
    {
        foreach (var effect in ent.Comp.Effects)
        {
            _effects.Effect(effect, new EntityEffectBaseArgs(args.EntityUid, EntityManager));
        }
    }
}
