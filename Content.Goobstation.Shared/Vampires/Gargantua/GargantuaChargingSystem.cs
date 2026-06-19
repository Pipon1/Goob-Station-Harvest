// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Goobstation.Shared.EntityEffects;
using Content.Shared.EntityEffects;
using Content.Shared.Throwing;
using Robust.Shared.Network;
using Robust.Shared.Physics.Events;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.Vampires.Gargantua;

public sealed partial class GargantuaChargingSystem : EntitySystem
{
    [Dependency] private SharedEntityEffectSystem _effects = default!;
    [Dependency] private IPrototypeManager _proto = default!;
    [Dependency] private INetManager _net = default!;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<GargantuaChargingComponent, StartCollideEvent>(OnCollide);

        SubscribeLocalEvent<GargantuaChargingComponent, LandEvent>(OnLand);
        SubscribeLocalEvent<GargantuaChargingComponent, StopThrowEvent>(OnStopThrow);
    }

    private void OnCollide(Entity<GargantuaChargingComponent> ent, ref StartCollideEvent args)
    {
        if (args.OurEntity != ent.Owner || !args.OtherFixture.Hard)
            return;

        if (!_proto.TryIndex(ent.Comp.Effect, out EntityEffectPrototype? effectProto))
            return;

        foreach (var effect in effectProto!.Effects)
            _effects.Effect(effect, new EntityEffectBaseArgs(args.OtherEntity, EntityManager));
    }

    private void OnLand(Entity<GargantuaChargingComponent> ent, ref LandEvent args)
    {
        RemCompDeferred(ent.Owner, ent.Comp);
    }

    private void OnStopThrow(Entity<GargantuaChargingComponent> ent, ref StopThrowEvent args)
    {
        RemCompDeferred(ent.Owner, ent.Comp);
    }
}
