namespace Content.Shared._Harvest.Botany.SeedAnalyzer;

using Robust.Shared.Audio;
using Robust.Shared.Prototypes;

[RegisterComponent]
public sealed partial class SeedAnalyzerComponent : Component
{
    /// <summary>
    /// Item slot containing the seed packet being analyzed.
    /// </summary>
    [DataField]
    public string SeedSlotId = "seedSlot";

    [DataField]
    public EntProtoId PaperPrototype = "Paper";

    [DataField]
    public TimeSpan PrintDelay = TimeSpan.FromSeconds(5);

    [DataField]
    public SoundSpecifier PrintSound = new SoundPathSpecifier("/Audio/Machines/printer.ogg");

    [ViewVariables]
    public TimeSpan NextPrintTime;
}
