// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared._NF.Storage.Components;
using Content.Shared.Materials;
using Content.Shared.Storage.EntitySystems;
using Robust.Shared.Physics.Components;
using Robust.Shared.Timing;
using Content.Shared.Examine;   // Frontier
using Content.Shared.Hands.Components;  // Frontier
using Content.Shared.Verbs;     // Frontier
using Robust.Shared.Utility;    // Frontier
using Robust.Shared.Network;

namespace Content.Shared._NF.Storage.EntitySystems;

/// <summary>
/// <see cref="MaterialStorageMagnetPickupComponent"/>
/// </summary>
public sealed class MaterialStorageMagnetPickupSystem : EntitySystem
{
    [Dependency] private readonly IGameTiming _timing = default!;
    [Dependency] private readonly EntityLookupSystem _lookup = default!;
    [Dependency] private readonly SharedMaterialStorageSystem _materialStorage = default!;
    [Dependency] private readonly SharedStorageSystem _storage = default!;
    [Dependency] private readonly SharedTransformSystem _transform = default!;
    [Dependency] private readonly INetManager _net = default!;

    private static readonly TimeSpan ScanDelay = TimeSpan.FromSeconds(1);

    private EntityQuery<PhysicsComponent> _physicsQuery;

    public override void Initialize()
    {
        base.Initialize();
        _physicsQuery = GetEntityQuery<PhysicsComponent>();
        SubscribeLocalEvent<MaterialStorageMagnetPickupComponent, MapInitEvent>(OnMagnetMapInit);
        SubscribeLocalEvent<MaterialStorageMagnetPickupComponent, EntityUnpausedEvent>(OnMagnetUnpaused);
        SubscribeLocalEvent<MaterialStorageMagnetPickupComponent, ExaminedEvent>(OnExamined);  // Frontier
        SubscribeLocalEvent<MaterialStorageMagnetPickupComponent, GetVerbsEvent<AlternativeVerb>>(AddToggleMagnetVerb);    // Frontier
    }

    private void OnMagnetUnpaused(EntityUid uid, MaterialStorageMagnetPickupComponent component, ref EntityUnpausedEvent args)
    {
        component.NextScan += args.PausedTime;
    }

    private void OnMagnetMapInit(EntityUid uid, MaterialStorageMagnetPickupComponent component, MapInitEvent args)
    {
        component.NextScan = _timing.CurTime + TimeSpan.FromSeconds(1); // Need to add 1 sec to fix a weird time bug with it that make it never start the magnet
    }

    // Frontier, used to add the magnet toggle to the context menu
    private void AddToggleMagnetVerb(EntityUid uid, MaterialStorageMagnetPickupComponent component, GetVerbsEvent<AlternativeVerb> args)
    {
        if (!args.CanAccess || !args.CanInteract)
            return;

        if (!HasComp<HandsComponent>(args.User))
            return;

        AlternativeVerb verb = new()
        {
            Act = () =>
            {
                ToggleMagnet(uid, component);
            },
            Icon = new SpriteSpecifier.Texture(new("/Textures/Interface/VerbIcons/Spare/poweronoff.svg.192dpi.png")),
            Text = Loc.GetString("comp-magnet-pickup-toggle-verb"),
            Priority = 3
        };

        args.Verbs.Add(verb);
    }

    // Frontier, used to show the magnet state on examination. Goobstation edit.
    private void OnExamined(EntityUid uid, MaterialStorageMagnetPickupComponent component, ExaminedEvent args)
    {
        if (component.MagnetEnabled)
            args.PushMarkup(Loc.GetString("comp-magnet-pickup-examined-on"));
        else
            args.PushMarkup(Loc.GetString("comp-magnet-pickup-examined-off"));
    }

    // Frontier, used to toggle the magnet on the ore bag/box
    public bool ToggleMagnet(EntityUid uid, MaterialStorageMagnetPickupComponent comp)
    {
        comp.MagnetEnabled = !comp.MagnetEnabled;
        return comp.MagnetEnabled;
    }

    public override void Update(float frameTime)
    {
        base.Update(frameTime);

        if (_net.IsClient)
            return;

        var query = EntityQueryEnumerator<MaterialStorageMagnetPickupComponent, MaterialStorageComponent, TransformComponent>();
        var currentTime = _timing.CurTime;

        while (query.MoveNext(out var uid, out var comp, out var storage, out var xform))
        {
            if (comp.NextScan > currentTime)
                continue;

            comp.NextScan = currentTime + ScanDelay;

            // Frontier - magnet disabled
            if (!comp.MagnetEnabled)
                continue;

            var parentUid = xform.ParentUid;
            var finalCoords = xform.Coordinates;
            var moverCoords = _transform.GetMoverCoordinates(uid, xform);

            foreach (var near in _lookup.GetEntitiesInRange(
                uid,
                comp.Range,
                LookupFlags.Dynamic | LookupFlags.Sundries))
            {
                if (!_physicsQuery.TryGetComponent(near, out var physics) ||
                    physics.BodyStatus != BodyStatus.OnGround)
                {
                    continue;
                }

                if (near == parentUid)
                    continue;

                var nearXform = Transform(near);
                var nearMapCoords = _transform.GetMapCoordinates(near, xform: nearXform);
                var nearCoords = _transform.ToCoordinates(moverCoords.EntityId, nearMapCoords);

                if (!_materialStorage.TryInsertMaterialEntity(uid, near, uid, storage))
                    continue;

                _storage.PlayPickupAnimation(
                    near,
                    nearCoords,
                    finalCoords,
                    nearXform.LocalRotation);
            }
        }
    }
}
