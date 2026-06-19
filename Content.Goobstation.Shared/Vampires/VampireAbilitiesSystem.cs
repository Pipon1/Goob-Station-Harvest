// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.Administration.Logs;
using Content.Shared.Database;
using Content.Shared.EntityEffects;
using Content.Goobstation.Shared.MobClass;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.Vampires;

public abstract class SharedVampireAbilitiesSystem : EntitySystem
{
    [Dependency] protected ISharedAdminLogManager _admin = default!;
    [Dependency] protected SharedEntityEffectSystem _effects = default!;
    [Dependency] protected MobClassSystem _mobClass = default!;
    [Dependency] protected IPrototypeManager _proto = default!;

    protected SharedVampireSystem _vampire => EntitySystem.Get<SharedVampireSystem>();

    /// <summary>
    /// List of every vampire ability prototype.
    /// </summary>
    [ViewVariables]
    public List<ProtoId<VampireAbilityPrototype>> AllAbilities = new();

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<VampireAbilitiesComponent, MapInitEvent>(OnMapInit);
        SubscribeLocalEvent<VampireAbilitiesComponent, ComponentStartup>(OnComponentStartup);
        SubscribeLocalEvent<VampireAbilitiesComponent, MobClassSelectedEvent>(OnMobClassSelected);

        SubscribeLocalEvent<VampireAbilitiesComponent, VampireTotalBloodChangedEvent>(OnBloodChanged);

        SubscribeLocalEvent<PrototypesReloadedEventArgs>(OnPrototypesReloaded);

        LoadPrototypes();
    }

    private void OnComponentStartup(Entity<VampireAbilitiesComponent> ent, ref ComponentStartup args)
    {
        var totalBlood = _vampire.GetTotalBlood(ent.Owner);
        UnlockAbilities(ent, totalBlood);
    }

    protected void OnMobClassSelected(Entity<VampireAbilitiesComponent> ent, ref MobClassSelectedEvent args)
    {
        var totalBlood = _vampire.GetTotalBlood(ent.Owner);
        UnlockAbilities(ent, totalBlood);
    }

    protected void OnMapInit(Entity<VampireAbilitiesComponent> ent, ref MapInitEvent args)
    {
        var totalBlood = _vampire.GetTotalBlood(ent.Owner);
        UnlockAbilities(ent, totalBlood);
    }

    protected void OnBloodChanged(Entity<VampireAbilitiesComponent> ent, ref VampireTotalBloodChangedEvent args) =>
        UnlockAbilities(ent, args.Blood);

    /// <summary>
    /// Unlocks abilities based on various factors (mob class, total blood, conditions).
    /// </summary>
    protected void UnlockAbilities(Entity<VampireAbilitiesComponent> ent, int blood)
    {
        var user = ent.Owner;

        var mobClass = _mobClass.GetClass(user);
        foreach (var ability in AllAbilities)
        {
            if (!_proto.Resolve(ability, out var abilityProto))
                continue;

            // We tried to unlcok an ability, but we don't have enough total blood
            if (abilityProto.Cost > blood)
                continue;

            // We tried to unlock an ability, but we have already unlocked it
            if (ent.Comp.UnlockedAbilities.Contains(ability))
                continue;

            // We tried to unlock an ability that doesn't belong to us, or we're blacklisted from it.
            if (( abilityProto.Class is { } requiredClass && mobClass != requiredClass )
                || abilityProto.BlacklistClass is { } blacklistClass && mobClass == blacklistClass)
                continue;

            // We tried to unlock an ability, but we didn't pass the extra conditions
            // TODO: Trauma has EntityConditions system, Goob doesn't - need alternative implementation
            // if (abilityProto.Conditions is { } conditions && !_conditions.TryConditions(user, conditions))
            //     continue;

            if (abilityProto.OnUnlock is { } onUnlockEffects)
            {
                foreach (var effect in onUnlockEffects)
                    _effects.Effect(effect, new EntityEffectBaseArgs(user, EntityManager));
            }

            ent.Comp.UnlockedAbilities.Add(ability);
            Dirty(ent);

            _admin.Add(LogType.Vampire, LogImpact.Medium, $"User {ent.Owner} has gained the ability {ability.Id}");
        }
    }

    protected void LoadPrototypes()
    {
        AllAbilities.Clear();
        foreach (var proto in _proto.EnumeratePrototypes<VampireAbilityPrototype>())
        {
            var id = proto.ID;
            AllAbilities.Add(id);
        }
    }

    protected void OnPrototypesReloaded(PrototypesReloadedEventArgs args)
    {
        if (!args.WasModified<VampireAbilityPrototype>())
            return;

        LoadPrototypes();
    }
}
