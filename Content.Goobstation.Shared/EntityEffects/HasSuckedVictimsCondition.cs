// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Goobstation.Shared.Vampires;
using Content.Shared.EntityEffects;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

[UsedImplicitly]
public sealed partial class HasSuckedVictimsCondition : EntityEffectCondition
{
    [DataField]
    public int Amount = 1;

    public override bool Condition(EntityEffectBaseArgs args)
    {
        if (!args.EntityManager.TryGetComponent<VampireBloodsuckingComponent>(args.TargetEntity, out var bloodsucking))
            return false;

        return bloodsucking.ConsumedVictims.Count >= Amount;
    }

    public override string GuidebookExplanation(IPrototypeManager prototype)
    {
        return Loc.GetString("reagent-effect-condition-guidebook-has-sucked-victims", ("amount", Amount));
    }
}
