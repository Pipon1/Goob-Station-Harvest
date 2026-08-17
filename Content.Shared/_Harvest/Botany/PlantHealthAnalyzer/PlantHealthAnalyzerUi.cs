using Robust.Shared.Serialization;
using Content.Shared.DoAfter;

namespace Content.Shared._Harvest.Botany.PlantHealthAnalyzer;

[Serializable, NetSerializable]
public enum PlantHealthAnalyzerUiKey : byte
{
    Key
}

[Serializable, NetSerializable]
public enum PlantDiagnosticType : byte
{
    Dead,
    CriticalHealth,
    LowHealth,
    ExcessToxins,
    ExcessPests,
    ExcessWeeds,
    OldAge
}

[Serializable, NetSerializable]
public enum PlantDiagnosticSeverity : byte
{
    Information,
    Warning,
    Critical
}

[Serializable, NetSerializable]
public sealed class PlantDiagnosticData
{
    public PlantDiagnosticType Type;
    public PlantDiagnosticSeverity Severity;
}

[Serializable, NetSerializable]
public sealed class PlantHealthAnalyzerData
{
    public string PlantName = string.Empty;
    public bool Dead;
    public bool ReadyToHarvest;
    public float HealthPercent;
    public int Age;
    public float GrowthPercent;
    public float ToxinLevel;
    public float PestLevel;
    public float WeedLevel;
    public float ToxinTolerance;
    public float PestTolerance;
    public float WeedTolerance;
    public List<PlantDiagnosticData> Diagnostics = new();
}

[Serializable, NetSerializable]
public sealed class PlantHealthAnalyzerUiState : BoundUserInterfaceState
{
    public PlantHealthAnalyzerData? Plant;
    public NetEntity? PlantHolder;

    public PlantHealthAnalyzerUiState(PlantHealthAnalyzerData? plant, NetEntity? plantHolder)
    {
        Plant = plant;
        PlantHolder = plantHolder;
    }
}

[Serializable, NetSerializable]
public sealed partial class PlantHealthAnalyzerDoAfterEvent : SimpleDoAfterEvent
{
}
