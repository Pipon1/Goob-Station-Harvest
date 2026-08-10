using Content.Goobstation.Shared.LightDetection.Components;
using Robust.Shared.Timing;

namespace Content.Goobstation.Server.LightDetection;

public sealed class DeleteOnLightExposureSystem : EntitySystem
{
    [Dependency] private readonly IGameTiming _timing = default!;

    public override void Update(float frameTime)
    {
        base.Update(frameTime);

        var query = EntityQueryEnumerator<DeleteOnLightExposureComponent, LightDetectionComponent>();
        while (query.MoveNext(out var uid, out var comp, out var lightDet))
        {
            if (comp.NextUpdate > _timing.CurTime)
                continue;

            comp.NextUpdate = _timing.CurTime + comp.UpdateInterval;

            if (lightDet.CurrentLightLevel >= comp.LightLevel)
            {
                comp.AccumulatedTime += (float)comp.UpdateInterval.TotalSeconds;

                if (comp.AccumulatedTime >= comp.Duration)
                {
                    QueueDel(uid);
                }
            }
            else
            {
                comp.AccumulatedTime = 0f;
            }
        }
    }
}
