using Robust.Shared.Serialization;

namespace Content.Shared._Harvest.Botany.SeedAnalyzer;

[Serializable, NetSerializable]
public enum SeedAnalyzerUiKey : byte
{
    Key
}

[Serializable, NetSerializable]
public enum SeedAnalyzerVisuals : byte
{
    SeedInserted,
    SeedLayer
}

[Serializable, NetSerializable]
public enum SeedAnalyzerHarvestType : byte
{
    Single,
    Repeat,
    SelfHarvest
}

[Serializable, NetSerializable]
public sealed class SeedAnalyzerReagentData
{
    public string ReagentId = string.Empty;
    public float MinimumAmount;
    public float MaximumAmount;
    public float CurrentAmount;
}

[Serializable, NetSerializable]
public sealed class SeedAnalyzerGasData
{
    public string GasId = string.Empty;
    public float Amount;
}

[Serializable, NetSerializable]
public sealed class SeedAnalyzerProductData
{
    public string PrototypeId = string.Empty;
}

[Serializable, NetSerializable]
public sealed class SeedAnalyzerData
{
    public string DisplayName = string.Empty;
    public int Yield;
    public float Potency;
    public float Endurance;
    public float Maturation;
    public float Production;
    public float Lifespan;
    public float WaterConsumption;
    public float NutrientConsumption;
    public float MinimumTemperature;
    public float MaximumTemperature;
    public float MinimumPressure;
    public float MaximumPressure;
    public bool Viable;
    public bool Seedless;
    public bool Ligneous;
    public float ToxinTolerance;
    public float PestTolerance;
    public float WeedTolerance;
    public SeedAnalyzerHarvestType HarvestType;
    public List<SeedAnalyzerReagentData> Reagents = new();
    public List<SeedAnalyzerGasData> ConsumedGases = new();
    public List<SeedAnalyzerGasData> ProducedGases = new();
    public List<SeedAnalyzerProductData> Products = new();
    public SeedAnalyzerBaselineData? Baseline;
}

[Serializable, NetSerializable]
public sealed class SeedAnalyzerBaselineData
{
    public int Yield;
    public float Potency;
    public float Endurance;
    public float Maturation;
    public float Production;
    public float Lifespan;
    public float WaterConsumption;
    public float NutrientConsumption;
    public float MinimumTemperature;
    public float MaximumTemperature;
    public float MinimumPressure;
    public float MaximumPressure;
    public bool Viable;
    public bool Seedless;
    public bool Ligneous;
    public float ToxinTolerance;
    public float PestTolerance;
    public float WeedTolerance;
    public SeedAnalyzerHarvestType HarvestType;
}

[Serializable, NetSerializable]
public sealed class SeedAnalyzerUiState : BoundUserInterfaceState
{
    public SeedAnalyzerData? Seed;
    public NetEntity? SeedEntity;
    public TimeSpan PrintReadyAt;

    public SeedAnalyzerUiState(SeedAnalyzerData? seed, NetEntity? seedEntity, TimeSpan printReadyAt)
    {
        Seed = seed;
        SeedEntity = seedEntity;
        PrintReadyAt = printReadyAt;
    }
}

[Serializable, NetSerializable]
public sealed class SeedAnalyzerEjectMessage : BoundUserInterfaceMessage;

[Serializable, NetSerializable]
public sealed class SeedAnalyzerPrintMessage : BoundUserInterfaceMessage;
