using Content.Shared._Harvest.Botany.SeedAnalyzer;
using Robust.Client.UserInterface;

namespace Content.Client._Harvest.Botany.SeedAnalyzer;

public sealed class SeedAnalyzerBoundUserInterface(
    EntityUid owner,
    Enum uiKey)
    : BoundUserInterface(owner, uiKey)
{
    private SeedAnalyzerWindow? _window;

    protected override void Open()
    {
        base.Open();

        _window = this.CreateWindow<SeedAnalyzerWindow>();

        _window.OnEjectPressed += () =>
        {
            SendMessage(new SeedAnalyzerEjectMessage());
        };

        _window.OnPrintPressed += () =>
        {
            SendMessage(new SeedAnalyzerPrintMessage());
        };
    }

    protected override void UpdateState(BoundUserInterfaceState state)
    {
        base.UpdateState(state);

        if (state is not SeedAnalyzerUiState analyzerState)
            return;

        EntityUid? seedEntity = analyzerState.SeedEntity == null
            ? null
            : EntMan.GetEntity(analyzerState.SeedEntity.Value);
        _window?.UpdateState(analyzerState, seedEntity);
    }
}
