using Content.Server.Botany.Components;
using Content.Server.Botany.Systems;
using Content.Server.Power.EntitySystems;
using Content.Shared._Harvest.Botany.SeedAnalyzer;
using Content.Shared.Containers.ItemSlots;
using Content.Shared.Paper;
using Robust.Server.Audio;
using Robust.Server.GameObjects;
using Robust.Shared.Containers;
using Robust.Shared.Prototypes;
using Robust.Shared.Timing;

namespace Content.Server._Harvest.Botany.SeedAnalyzer;

public sealed class SeedAnalyzerSystem : EntitySystem
{
    [Dependency] private readonly BotanySystem _botany = default!;
    [Dependency] private readonly ItemSlotsSystem _itemSlots = default!;
    [Dependency] private readonly UserInterfaceSystem _ui = default!;
    [Dependency] private readonly IGameTiming _timing = default!;
    [Dependency] private readonly IPrototypeManager _prototypes = default!;
    [Dependency] private readonly AudioSystem _audio = default!;
    [Dependency] private readonly PaperSystem _paper = default!;
    [Dependency] private readonly SharedAppearanceSystem _appearance = default!;

    private SeedAnalyzerDataBuilder _dataBuilder = default!;
    private SeedAnalyzerReportBuilder _reportBuilder = default!;

    public override void Initialize()
    {
        base.Initialize();
        _dataBuilder = new SeedAnalyzerDataBuilder(_prototypes);
        _reportBuilder = new SeedAnalyzerReportBuilder(_prototypes);

        SubscribeLocalEvent<SeedAnalyzerComponent, BoundUIOpenedEvent>(OnUiOpened);
        SubscribeLocalEvent<SeedAnalyzerComponent, MapInitEvent>(OnMapInit);
        SubscribeLocalEvent<SeedAnalyzerComponent, EntInsertedIntoContainerMessage>(OnContainerModified);
        SubscribeLocalEvent<SeedAnalyzerComponent, EntRemovedFromContainerMessage>(OnContainerModified);
        Subs.BuiEvents<SeedAnalyzerComponent>(SeedAnalyzerUiKey.Key, subs =>
        {
            subs.Event<SeedAnalyzerEjectMessage>(OnEject);
            subs.Event<SeedAnalyzerPrintMessage>(OnPrint);
        });
    }

    private SeedAnalyzerData? GetData(Entity<SeedAnalyzerComponent> analyzer)
    {
        var seedEntity = _itemSlots.GetItemOrNull(analyzer.Owner, analyzer.Comp.SeedSlotId);
        if (seedEntity == null ||
            !TryComp<SeedComponent>(seedEntity.Value, out var component) ||
            !_botany.TryGetSeed(component, out var seed))
            return null;

        return _dataBuilder.Build(component, seed);
    }

    private void UpdateUi(Entity<SeedAnalyzerComponent> analyzer)
    {
        var seedEntity = _itemSlots.GetItemOrNull(analyzer.Owner, analyzer.Comp.SeedSlotId);
        _ui.SetUiState(analyzer.Owner,
            SeedAnalyzerUiKey.Key,
            new SeedAnalyzerUiState(
                GetData(analyzer),
                seedEntity == null ? null : GetNetEntity(seedEntity.Value),
                analyzer.Comp.NextPrintTime));
    }

    private void OnUiOpened(Entity<SeedAnalyzerComponent> analyzer, ref BoundUIOpenedEvent args) => UpdateUi(analyzer);

    private void OnMapInit(Entity<SeedAnalyzerComponent> analyzer, ref MapInitEvent args)
    {
        var seedInserted = _itemSlots.GetItemOrNull(analyzer.Owner, analyzer.Comp.SeedSlotId) != null;
        _appearance.SetData(analyzer.Owner, SeedAnalyzerVisuals.SeedInserted, seedInserted);
    }

    private void OnContainerModified(Entity<SeedAnalyzerComponent> analyzer, ref EntInsertedIntoContainerMessage args)
    {
        if (args.Container.ID == analyzer.Comp.SeedSlotId)
        {
            _appearance.SetData(analyzer.Owner, SeedAnalyzerVisuals.SeedInserted, true);
            UpdateUi(analyzer);
        }
    }

    private void OnContainerModified(Entity<SeedAnalyzerComponent> analyzer, ref EntRemovedFromContainerMessage args)
    {
        if (args.Container.ID == analyzer.Comp.SeedSlotId)
        {
            _appearance.SetData(analyzer.Owner, SeedAnalyzerVisuals.SeedInserted, false);
            UpdateUi(analyzer);
        }
    }

    private void OnEject(Entity<SeedAnalyzerComponent> analyzer, ref SeedAnalyzerEjectMessage args)
    {
        if (_itemSlots.TryGetSlot(analyzer.Owner, analyzer.Comp.SeedSlotId, out var slot))
            _itemSlots.TryEjectToHands(analyzer.Owner, slot, args.Actor);
    }

    private void OnPrint(Entity<SeedAnalyzerComponent> analyzer, ref SeedAnalyzerPrintMessage args)
    {
        if (_timing.CurTime < analyzer.Comp.NextPrintTime ||
            !this.IsPowered(analyzer.Owner, EntityManager) ||
            GetData(analyzer) is not { } data)
            return;

        var paper = SpawnAtPosition(analyzer.Comp.PaperPrototype, Transform(analyzer).Coordinates);
        _paper.SetContent(paper, _reportBuilder.Build(data));
        _audio.PlayPvs(analyzer.Comp.PrintSound, analyzer.Owner);
        analyzer.Comp.NextPrintTime = _timing.CurTime + analyzer.Comp.PrintDelay;
        UpdateUi(analyzer);
    }
}
