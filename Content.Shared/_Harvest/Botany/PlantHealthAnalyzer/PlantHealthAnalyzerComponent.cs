namespace Content.Shared._Harvest.Botany.PlantHealthAnalyzer;

using Robust.Shared.Audio;

[RegisterComponent]
public sealed partial class PlantHealthAnalyzerComponent : Component
{
    [DataField]
    public TimeSpan ScanDelay = TimeSpan.FromSeconds(1);

    [DataField]
    public SoundSpecifier ScanningSound = new SoundPathSpecifier("/Audio/Items/Medical/healthscanner.ogg");

    [DataField]
    public TimeSpan RefreshInterval = TimeSpan.FromSeconds(0.5);

    [ViewVariables]
    public EntityUid? Target;

    [ViewVariables]
    public EntityUid? User;

    [ViewVariables]
    public TimeSpan NextRefresh;
}
