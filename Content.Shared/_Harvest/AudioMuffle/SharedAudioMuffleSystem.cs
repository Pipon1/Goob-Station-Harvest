using Content.Shared.Doors;
using Content.Shared.Doors.Components;

namespace Content.Shared._Harvest.AudioMuffle;

public abstract class SharedAudioMuffleSystem : EntitySystem
{
    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<SoundBlockerComponent, DoorStateChangedEvent>(OnDoorStateChanged);
        SubscribeLocalEvent<SoundBlockerComponent, MapInitEvent>(OnMapInit);
    }

    private void OnMapInit(Entity<SoundBlockerComponent> ent, ref MapInitEvent args)
    {
        if (!TryComp(ent, out DoorComponent? door))
            return;

        UpdateState(ent, door.State);
    }

    private void OnDoorStateChanged(Entity<SoundBlockerComponent> ent, ref DoorStateChangedEvent args)
    {
        UpdateState(ent, args.State);
    }

    private void UpdateState(Entity<SoundBlockerComponent> ent, DoorState state)
    {
        switch (state)
        {
            case DoorState.Closed:
                ent.Comp.Active = true;
                break;
            case DoorState.Open:
                ent.Comp.Active = false;
                break;
            default:
                return;
        }

        DirtyField(ent.AsNullable(), nameof(SoundBlockerComponent.Active));
    }
}
