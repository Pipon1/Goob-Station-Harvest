using System.Linq;
using System.Text;
using Content.Shared._Harvest.Botany.SeedAnalyzer;
using Content.Shared.Atmos.Prototypes;
using Content.Shared.Chemistry.Reagent;
using Robust.Shared.Prototypes;

namespace Content.Server._Harvest.Botany.SeedAnalyzer;

public sealed class SeedAnalyzerReportBuilder(IPrototypeManager prototypes)
{
    public string Build(SeedAnalyzerData seed)
    {
        var report = new StringBuilder();
        report.AppendLine();
        report.AppendLine(Loc.GetString("seed-analyzer-report-title", ("plant", Loc.GetString(seed.DisplayName))));
        report.AppendLine();
        AppendStat(report, "seed-analyzer-stat-yield", seed.Yield, seed.Baseline?.Yield);
        AppendStat(report, "seed-analyzer-stat-potency", seed.Potency, seed.Baseline?.Potency);
        AppendStat(report, "seed-analyzer-stat-endurance", seed.Endurance, seed.Baseline?.Endurance);
        report.AppendLine();
        AppendStat(report, "seed-analyzer-stat-maturation", seed.Maturation, seed.Baseline?.Maturation);
        AppendStat(report, "seed-analyzer-stat-production", seed.Production, seed.Baseline?.Production);
        AppendStat(report, "seed-analyzer-stat-lifespan", seed.Lifespan, seed.Baseline?.Lifespan);
        report.AppendLine();
        AppendStat(report, "seed-analyzer-stat-water", seed.WaterConsumption, seed.Baseline?.WaterConsumption);
        AppendStat(report, "seed-analyzer-stat-nutrients", seed.NutrientConsumption, seed.Baseline?.NutrientConsumption);
        report.AppendLine(Loc.GetString("seed-analyzer-report-temperature",
            ("value", FormatRange(seed.MinimumTemperature, seed.MaximumTemperature, seed.Baseline?.MinimumTemperature, seed.Baseline?.MaximumTemperature))));
        report.AppendLine(Loc.GetString("seed-analyzer-report-pressure",
            ("value", FormatRange(seed.MinimumPressure, seed.MaximumPressure, seed.Baseline?.MinimumPressure, seed.Baseline?.MaximumPressure))));
        report.AppendLine();
        report.AppendLine(Loc.GetString("seed-analyzer-report-properties",
            ("viable", FormatCompared(YesNo(seed.Viable), seed.Baseline == null ? null : YesNo(seed.Baseline.Viable))),
            ("seedless", FormatCompared(YesNo(seed.Seedless), seed.Baseline == null ? null : YesNo(seed.Baseline.Seedless))),
            ("ligneous", FormatCompared(YesNo(seed.Ligneous), seed.Baseline == null ? null : YesNo(seed.Baseline.Ligneous)))));
        report.AppendLine(Loc.GetString("seed-analyzer-report-harvest-type",
            ("value", FormatCompared(FormatHarvestType(seed.HarvestType),
                seed.Baseline == null ? null : FormatHarvestType(seed.Baseline.HarvestType)))));
        AppendStat(report, "seed-analyzer-report-toxin-tolerance", seed.ToxinTolerance, seed.Baseline?.ToxinTolerance);
        AppendStat(report, "seed-analyzer-report-pest-tolerance", seed.PestTolerance, seed.Baseline?.PestTolerance);
        AppendStat(report, "seed-analyzer-report-weed-tolerance", seed.WeedTolerance, seed.Baseline?.WeedTolerance);
        report.AppendLine();

        report.AppendLine(Loc.GetString("seed-analyzer-report-products-title"));
        report.AppendLine(seed.Products.Count == 0
            ? Loc.GetString("seed-analyzer-none")
            : Loc.GetString("seed-analyzer-report-products", ("yield", seed.Yield),
                ("products", string.Join(", ", seed.Products.Select(GetProductName)))));
        report.AppendLine();

        report.AppendLine(Loc.GetString("seed-analyzer-report-reagents-title"));
        foreach (var reagent in seed.Reagents)
            report.AppendLine(Loc.GetString("seed-analyzer-report-reagent", ("name", GetReagentName(reagent.ReagentId)),
                ("current", FormatNumber(reagent.CurrentAmount)),
                ("min", FormatNumber(reagent.MinimumAmount)),
                ("max", FormatNumber(reagent.MaximumAmount))));
        if (seed.Reagents.Count == 0)
            report.AppendLine(Loc.GetString("seed-analyzer-none"));
        report.AppendLine();

        report.AppendLine(Loc.GetString("seed-analyzer-report-gases-title"));
        foreach (var gas in seed.ConsumedGases)
            report.AppendLine(Loc.GetString("seed-analyzer-report-gas-consumed", ("amount", gas.Amount), ("gas", GetGasName(gas.GasId))));
        foreach (var gas in seed.ProducedGases)
            report.AppendLine(Loc.GetString("seed-analyzer-report-gas-produced", ("amount", gas.Amount), ("gas", GetGasName(gas.GasId))));
        if (seed.ConsumedGases.Count == 0 && seed.ProducedGases.Count == 0)
            report.AppendLine(Loc.GetString("seed-analyzer-none"));
        return report.ToString();
    }

    private static void AppendStat(StringBuilder report, string key, float value, float? baseline) =>
        report.AppendLine(Loc.GetString(key, ("value", FormatCompared(FormatNumber(value), baseline == null ? null : FormatNumber(baseline.Value)))));

    private static string FormatRange(float minimum, float maximum, float? baselineMinimum, float? baselineMaximum)
    {
        var current = $"{FormatNumber(minimum)}-{FormatNumber(maximum)}";
        var baseline = baselineMinimum == null || baselineMaximum == null
            ? null
            : $"{FormatNumber(baselineMinimum.Value)}-{FormatNumber(baselineMaximum.Value)}";
        return FormatCompared(current, baseline);
    }

    private static string FormatCompared(string current, string? baseline) =>
        baseline == null ? current : $"{current} ({baseline})";

    private static string FormatNumber(float value) => value.ToString("0.##");

    private static string FormatHarvestType(SeedAnalyzerHarvestType harvestType)
    {
        return harvestType switch
        {
            SeedAnalyzerHarvestType.Repeat => Loc.GetString("seed-analyzer-harvest-repeat"),
            SeedAnalyzerHarvestType.SelfHarvest => Loc.GetString("seed-analyzer-harvest-automatic"),
            _ => Loc.GetString("seed-analyzer-harvest-single")
        };
    }

    private string GetReagentName(string id) => prototypes.TryIndex<ReagentPrototype>(id, out var reagent) ? reagent.LocalizedName : id;
    private string GetGasName(string id) => prototypes.TryIndex<GasPrototype>(id, out var gas) ? Loc.GetString(gas.Name) : id;
    private string GetProductName(SeedAnalyzerProductData product) => prototypes.TryIndex<EntityPrototype>(product.PrototypeId, out var proto) ? Loc.GetString(proto.Name) : product.PrototypeId;
    private static string YesNo(bool value) => Loc.GetString(value ? "seed-analyzer-yes" : "seed-analyzer-no");
}
