using Content.Server.Botany.Components;
using Content.Shared._Harvest.Botany.PlantHealthAnalyzer;
using Content.Shared.DoAfter;
using Content.Shared.Interaction;
using Robust.Server.Audio;
using Robust.Server.GameObjects;
using Robust.Shared.Timing;

namespace Content.Server._Harvest.Botany.PlantHealthAnalyzer;

public sealed class PlantHealthAnalyzerSystem : EntitySystem
{
    [Dependency]
    private readonly UserInterfaceSystem _ui = default!;

    [Dependency]
    private readonly SharedDoAfterSystem _doAfter = default!;

    [Dependency]
    private readonly AudioSystem _audio = default!;

    [Dependency]
    private readonly IGameTiming _timing = default!;

    [Dependency]
    private readonly SharedInteractionSystem _interaction = default!;

    public override void Initialize()
    {
        base.Initialize();
        SubscribeLocalEvent<PlantHealthAnalyzerComponent, AfterInteractEvent>(OnAfterInteract);
        SubscribeLocalEvent<PlantHealthAnalyzerComponent, PlantHealthAnalyzerDoAfterEvent>(OnDoAfter);
        SubscribeLocalEvent<PlantHealthAnalyzerComponent, BoundUIClosedEvent>(OnUiClosed);
    }

    public override void Update(float frameTime)
    {
        base.Update(frameTime);

        var now = _timing.CurTime;
        var query = EntityQueryEnumerator<PlantHealthAnalyzerComponent>();
        while (query.MoveNext(out var uid, out var analyzer))
        {
            if (analyzer.Target == null || analyzer.User == null || now < analyzer.NextRefresh)
                continue;

            if (!_ui.IsUiOpen(uid, PlantHealthAnalyzerUiKey.Key))
            {
                ClearTarget(analyzer);
                continue;
            }

            if (Deleted(analyzer.Target.Value) || Deleted(analyzer.User.Value) ||
                !_interaction.InRangeUnobstructed(
                    (analyzer.User.Value, null),
                    (analyzer.Target.Value, null)))
            {
                _ui.CloseUi(uid, PlantHealthAnalyzerUiKey.Key, analyzer.User.Value);
                ClearTarget(analyzer);
                continue;
            }

            analyzer.NextRefresh = now + analyzer.RefreshInterval;
            UpdateUi((uid, analyzer));
        }
    }

    private void OnAfterInteract(
        Entity<PlantHealthAnalyzerComponent> analyzer,
        ref AfterInteractEvent args)
    {
        if (args.Handled || args.Target == null || !args.CanReach ||
            !HasComp<PlantHolderComponent>(args.Target.Value))
            return;

        _doAfter.TryStartDoAfter(new DoAfterArgs(
            EntityManager,
            args.User,
            analyzer.Comp.ScanDelay,
            new PlantHealthAnalyzerDoAfterEvent(),
            analyzer.Owner,
            target: args.Target,
            used: analyzer.Owner)
        {
            NeedHand = true,
            BreakOnMove = true,
            BreakOnDropItem = true
        });

        args.Handled = true;
    }

    private void OnDoAfter(
        Entity<PlantHealthAnalyzerComponent> analyzer,
        ref PlantHealthAnalyzerDoAfterEvent args)
    {
        if (args.Handled || args.Cancelled || args.Target == null ||
            !TryComp<PlantHolderComponent>(args.Target.Value, out var holder))
            return;

        var data = holder.Seed == null ? null : BuildPlantData(holder);

        _audio.PlayPvs(analyzer.Comp.ScanningSound, analyzer.Owner);

        if (!_ui.TryOpenUi(analyzer.Owner, PlantHealthAnalyzerUiKey.Key, args.User))
            return;

        analyzer.Comp.Target = args.Target.Value;
        analyzer.Comp.User = args.User;
        analyzer.Comp.NextRefresh = _timing.CurTime + analyzer.Comp.RefreshInterval;
        _ui.SetUiState(analyzer.Owner,
            PlantHealthAnalyzerUiKey.Key,
            new PlantHealthAnalyzerUiState(data, GetNetEntity(args.Target.Value)));
        args.Handled = true;
    }

    private void OnUiClosed(Entity<PlantHealthAnalyzerComponent> analyzer, ref BoundUIClosedEvent args)
    {
        if (Equals(args.UiKey, PlantHealthAnalyzerUiKey.Key) &&
            !_ui.IsUiOpen(analyzer.Owner, PlantHealthAnalyzerUiKey.Key))
            ClearTarget(analyzer.Comp);
    }

    private void UpdateUi(Entity<PlantHealthAnalyzerComponent> analyzer)
    {
        PlantHealthAnalyzerData? data = null;
        if (analyzer.Comp.Target is not { } target ||
            !TryComp<PlantHolderComponent>(target, out var holder))
        {
            ClearTarget(analyzer.Comp);
            _ui.SetUiState(analyzer.Owner,
                PlantHealthAnalyzerUiKey.Key,
                new PlantHealthAnalyzerUiState(null, null));
            return;
        }

        if (holder.Seed != null)
            data = BuildPlantData(holder);

        _ui.SetUiState(analyzer.Owner,
            PlantHealthAnalyzerUiKey.Key,
            new PlantHealthAnalyzerUiState(data, GetNetEntity(target)));
    }

    private PlantHealthAnalyzerData BuildPlantData(PlantHolderComponent holder)
    {
        var seed = holder.Seed!;
        var diagnostics = new List<PlantDiagnosticData>();

        var healthPercent = seed.Endurance <= 0f
            ? 0f
            : Math.Clamp(holder.Health / seed.Endurance * 100f, 0f, 100f);
        var growthPercent = seed.Maturation <= 0f
            ? 100f
            : Math.Clamp(holder.Age / seed.Maturation * 100f, 0f, 100f);

        if (holder.Dead)
            AddDiagnostic(diagnostics, PlantDiagnosticType.Dead, PlantDiagnosticSeverity.Critical);
        else if (healthPercent <= 25f)
            AddDiagnostic(diagnostics, PlantDiagnosticType.CriticalHealth, PlantDiagnosticSeverity.Critical);
        else if (healthPercent <= 50f)
            AddDiagnostic(diagnostics, PlantDiagnosticType.LowHealth, PlantDiagnosticSeverity.Warning);

        if (holder.Toxins > seed.ToxinsTolerance)
            AddDiagnostic(diagnostics, PlantDiagnosticType.ExcessToxins, PlantDiagnosticSeverity.Critical);
        if (holder.PestLevel > seed.PestTolerance)
            AddDiagnostic(diagnostics, PlantDiagnosticType.ExcessPests, PlantDiagnosticSeverity.Critical);
        if (holder.WeedLevel >= seed.WeedTolerance)
            AddDiagnostic(diagnostics, PlantDiagnosticType.ExcessWeeds, PlantDiagnosticSeverity.Critical);
        if (holder.Age > seed.Lifespan)
            AddDiagnostic(diagnostics, PlantDiagnosticType.OldAge, PlantDiagnosticSeverity.Warning);

        return new PlantHealthAnalyzerData
        {
            PlantName = seed.DisplayName,
            Dead = holder.Dead,
            ReadyToHarvest = holder.Harvest,
            HealthPercent = healthPercent,
            Age = holder.Age,
            GrowthPercent = growthPercent,
            ToxinLevel = holder.Toxins,
            PestLevel = holder.PestLevel,
            WeedLevel = holder.WeedLevel,
            ToxinTolerance = seed.ToxinsTolerance,
            PestTolerance = seed.PestTolerance,
            WeedTolerance = seed.WeedTolerance,
            Diagnostics = diagnostics
        };
    }

    private static void AddDiagnostic(
        List<PlantDiagnosticData> diagnostics,
        PlantDiagnosticType type,
        PlantDiagnosticSeverity severity)
    {
        diagnostics.Add(new PlantDiagnosticData
        {
            Type = type,
            Severity = severity
        });
    }

    private static void ClearTarget(PlantHealthAnalyzerComponent component)
    {
        component.Target = null;
        component.User = null;
    }
}
