// SPDX-FileCopyright-Identifier: AGPL-3.0-or-later

using Content.Goobstation.Shared.EntityEffects;
using Content.Server.Light.Components;
using Content.Server.Light.EntitySystems;

namespace Content.Goobstation.Server.EntityEffects;

public sealed class BreakLightBulbSystem : EntitySystem
{
    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<PoweredLightComponent, BreakLightBulbEvent>(OnBreakBulb);
    }

    private void OnBreakBulb(Entity<PoweredLightComponent> ent, ref BreakLightBulbEvent args)
    {
        var poweredLightSystem = EntitySystem.Get<PoweredLightSystem>();
        poweredLightSystem.TryDestroyBulb(ent, ent.Comp);
    }
}
