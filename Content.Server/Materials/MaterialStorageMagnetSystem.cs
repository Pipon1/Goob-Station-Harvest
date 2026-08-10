using Content.Shared.Materials;
using Content.Shared.Materials.OreSilo;
using Content.Shared.Storage.Components;
using Content.Shared.Storage.EntitySystems;
using Robust.Shared.Map;
using Robust.Shared.Timing;

namespace Content.Server.Materials;

/// <summary>
/// Automatically inserts nearby materials into an ore silo equipped with a magnet.
/// </summary>
public sealed class MaterialStorageMagnetSystem : EntitySystem
{
    [Dependency] private readonly IGameTiming _timing = default!;
    [Dependency] private readonly EntityLookupSystem _lookup = default!;
    [Dependency] private readonly MaterialStorageSystem _materialStorage = default!;
    [Dependency] private readonly SharedStorageSystem _storage = default!;
    [Dependency] private readonly SharedTransformSystem _transform = default!;

    private static readonly TimeSpan ScanDelay = TimeSpan.FromSeconds(1);

    private readonly Dictionary<EntityUid, PendingMagnetAnimation> _pendingAnimations = new();

    private readonly record struct PendingMagnetAnimation(
        EntityUid Material,
        EntityCoordinates InitialCoordinates,
        EntityCoordinates FinalCoordinates,
        Angle InitialRotation);

    public override void Initialize()
    {
        base.Initialize();
        SubscribeLocalEvent<MaterialStorageComponent, MaterialEntityInsertedEvent>(OnMaterialInserted);
    }

    private void OnMaterialInserted(Entity<MaterialStorageComponent> ent, ref MaterialEntityInsertedEvent args)
    {
        if (!_pendingAnimations.Remove(ent.Owner, out var animation))
            return;

        _storage.PlayPickupAnimation(
            animation.Material,
            animation.InitialCoordinates,
            animation.FinalCoordinates,
            animation.InitialRotation);
    }

    public override void Update(float frameTime)
    {
        base.Update(frameTime);

        var currentTime = _timing.CurTime;
        var query = EntityQueryEnumerator<
            MagnetPickupComponent,
            MaterialStorageComponent,
            OreSiloComponent,
            TransformComponent>();

        while (query.MoveNext(
            out var uid,
            out var magnet,
            out var materialStorage,
            out var silo,
            out var transform))
        {
            if (!silo.MagnetEnabled || magnet.NextScan > currentTime)
                continue;

            magnet.NextScan = currentTime + ScanDelay;
            Dirty(uid, magnet);

            var finalCoords = transform.Coordinates;
            var moverCoords = _transform.GetMoverCoordinates(uid, transform);

            foreach (var entity in _lookup.GetEntitiesInRange(
                         uid,
                         magnet.Range,
                         LookupFlags.Dynamic | LookupFlags.Sundries))
            {
                if (entity == uid)
                    continue;

                var entityTransform = Transform(entity);
                var entityMapCoords = _transform.GetMapCoordinates(entity, xform: entityTransform);
                var initialCoords = _transform.ToCoordinates(moverCoords.EntityId, entityMapCoords);

                _pendingAnimations[uid] = new PendingMagnetAnimation(
                    entity,
                    initialCoords,
                    finalCoords,
                    entityTransform.LocalRotation);

                try
                {
                    _materialStorage.TryInsertMaterialEntity(uid, entity, uid, materialStorage);
                }
                finally
                {
                    // Failed insertions do not raise MaterialEntityInsertedEvent.
                    _pendingAnimations.Remove(uid);
                }
            }
        }
    }
}
