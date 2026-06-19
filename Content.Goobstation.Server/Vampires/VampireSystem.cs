// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Goobstation.Shared.MobClass;
using Content.Goobstation.Shared.Vampires;
using Content.Server.Antag;
using Content.Server.GameTicking.Rules;
using Content.Server.Mind;
using Content.Server.Zombies;
using Content.Shared.Actions;
using Content.Shared.Alert;
using Content.Shared.NPC.Systems;
using Content.Shared.StatusEffectNew;
using Robust.Server.Player;
using Robust.Shared.Audio.Systems;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Server.Vampires;

/// <summary>
///     Server-side system for handling vampire antag logic.
/// </summary>
public sealed class VampireSystem : GameRuleSystem<VampireRuleComponent>
{
    [Dependency] private readonly SharedActionsSystem _actions = default!;
    [Dependency] private readonly SharedAudioSystem _audio = default!;
    [Dependency] private readonly MindSystem _mind = default!;
    [Dependency] private readonly AntagSelectionSystem _antag = default!;
    [Dependency] private readonly IPlayerManager _playerManager = default!;
    [Dependency] private readonly NpcFactionSystem _npcFaction = default!;
    [Dependency] private readonly StatusEffectsSystem _statusEffects = default!;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<VampireRuleComponent, AfterAntagEntitySelectedEvent>(OnSelectAntag);
    }

    private void OnSelectAntag(EntityUid uid, VampireRuleComponent comp, ref AfterAntagEntitySelectedEvent args)
    {
        MakeVampire(args.EntityUid, comp);
    }

    private void MakeVampire(EntityUid vampire, VampireRuleComponent rule)
    {
        // Add vampire component
        var vampireComp = EnsureComp<VampireComponent>(vampire);
        vampireComp.UsableBlood = 0;
        vampireComp.TotalBlood = 0;
        Dirty(vampire, vampireComp);

        // Add vampire abilities component
        EnsureComp<VampireAbilitiesComponent>(vampire);

        // Add vampire bloodsucking component
        EnsureComp<VampireBloodsuckingComponent>(vampire);

        // Add mob class component for specialization selection
        var mobClassComp = EnsureComp<MobClassComponent>(vampire);
        mobClassComp.BelongsTo = new ProtoId<MobClassGroupPrototype>("Vampire");
        Dirty(vampire, mobClassComp);

        // Add nullification component (holy water immunity tracker)
        EnsureComp<NullificationComponent>(vampire);

        // Add zombie immunity
        EnsureComp<ZombieImmuneComponent>(vampire);

        // Show blood level alert
        var alertsSystem = EntitySystem.Get<AlertsSystem>();
        alertsSystem.ShowAlert(vampire, "BloodLevel");

        // Add vampire faction
        _npcFaction.AddFaction(vampire, "VampireFaction");

        // Add vampire space status effect (handles starlight interactions)
        _statusEffects.TryAddStatusEffect(vampire, "VampireSpaceStatusEffect", out _, null);

        // NOTE: ActionChooseSpecialization is granted by the ability system at 150 total blood (ChooseSpecialization ability).
    }
}

