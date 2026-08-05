using Content.Shared.Administration.Components;
using Robust.Client.GameObjects;
using Robust.Shared.Utility;

namespace Content.Goobstation.Client.AdminTools;

public sealed class AdminOverrideSystem : EntitySystem
{
    [Dependency] private readonly SpriteSystem _sprite = null!;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<AdminOverrideComponent, AfterAutoHandleStateEvent>(OnHandleState);
        SubscribeLocalEvent<AdminOverrideComponent, ComponentStartup>(OnStartup);
    }

    private void OnStartup(EntityUid uid, AdminOverrideComponent component, ComponentStartup args)
    {
        ApplyOverrides(uid, component);
    }

    private void OnHandleState(EntityUid uid, AdminOverrideComponent component, ref AfterAutoHandleStateEvent args)
    {
        ApplyOverrides(uid, component);
    }

    private void ApplyOverrides(EntityUid uid, AdminOverrideComponent component)
    {
        if (!TryComp(uid, out SpriteComponent? sprite))
            return;

        if (!string.IsNullOrEmpty(component.RSIPath))
        {
            _sprite.LayerSetRsi((uid, sprite), 0, new ResPath(component.RSIPath), component.RSIState);
        }
    }
}
