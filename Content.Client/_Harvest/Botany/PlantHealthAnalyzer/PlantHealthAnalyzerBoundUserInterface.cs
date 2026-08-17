using Content.Shared._Harvest.Botany.PlantHealthAnalyzer;
using Robust.Client.UserInterface;

namespace Content.Client._Harvest.Botany.PlantHealthAnalyzer;

public sealed class PlantHealthAnalyzerBoundUserInterface(EntityUid owner, Enum uiKey)
    : BoundUserInterface(owner, uiKey)
{
    private PlantHealthAnalyzerWindow? _window;

    protected override void Open()
    {
        base.Open();
        _window = this.CreateWindow<PlantHealthAnalyzerWindow>();
    }

    protected override void UpdateState(BoundUserInterfaceState state)
    {
        base.UpdateState(state);

        if (state is not PlantHealthAnalyzerUiState analyzerState)
            return;

        EntityUid? plantHolder = analyzerState.PlantHolder == null
            ? null
            : EntMan.GetEntity(analyzerState.PlantHolder.Value);
        _window?.UpdateState(analyzerState, plantHolder);
    }
}
