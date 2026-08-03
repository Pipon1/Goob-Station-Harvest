using Content.Shared.Sprite;
using Robust.Client.GameObjects;
using Robust.Shared.Utility;

namespace Content.Client.Sprite;

public sealed class SpriteOverrideSystem : EntitySystem
{
    [Dependency] private readonly SpriteSystem _sprite = null!;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<SpriteOverrideComponent, AfterAutoHandleStateEvent>(OnHandleState);
        SubscribeLocalEvent<SpriteOverrideComponent, ComponentStartup>(OnStartup);
    }

    private void OnStartup(EntityUid uid, SpriteOverrideComponent component, ComponentStartup args)
    {
        ApplyOverride(uid, component);
    }

    private void OnHandleState(EntityUid uid, SpriteOverrideComponent component, ref AfterAutoHandleStateEvent args)
    {
        ApplyOverride(uid, component);
    }

    private void ApplyOverride(EntityUid uid, SpriteOverrideComponent component)
    {
        if (!TryComp(uid, out SpriteComponent? sprite))
            return;

        if (!string.IsNullOrEmpty(component.RSIPath))
        {
            _sprite.LayerSetRsi((uid, sprite), 0, new ResPath(component.RSIPath), component.RSIState);
        }

        if (component.Scale != null)
        {
            _sprite.SetScale((uid, sprite), component.Scale.Value);
        }
    }
}
