# SPDX-FileCopyrightText: 2025 Aiden <28298836+Aidenkrz@users.noreply.github.com>
# SPDX-FileCopyrightText: 2025 Aiden <aiden@djkraz.com>
# SPDX-FileCopyrightText: 2025 Aviu00 <93730715+Aviu00@users.noreply.github.com>
#
# SPDX-License-Identifier: AGPL-3.0-or-later

reagent-effect-guidebook-deal-stamina-damage =
    { $chance ->
        [1] { $deltasign ->
                [1] Inflige
                *[-1] Soigne
            }
        *[other]
            { $deltasign ->
                [1] inflige
                *[-1] soigne
            }
    } { $amount } { $immediate ->
                    [true] immédiat
                    *[false] sur la durée
                  } dégâts d'endurance

reagent-effect-guidebook-stealth-entities = Camoufle les êtres vivants à proximité.

reagent-effect-guidebook-change-faction = Change la faction de l'être pour {$faction}.

reagent-effect-guidebook-mutate-plants-nearby = Mutation aléatoire des plantes à proximité.

reagent-effect-guidebook-dnascramble = Détresse l'ADN de la personne.

reagent-effect-guidebook-change-species = Transforme la cible en {$species}.

reagent-effect-guidebook-change-species-random = Transforme la cible en une espèce complètement aléatoire.

reagent-effect-guidebook-sex-change = Change le genre de la personne

reagent-effect-guidebook-immunity-modifier =
    { $chance ->
        [1] Modifie
        *[other] modifie
    } le taux de gain d'immunité par {NATURALFIXED($gainrate, 5)}, la force par {NATURALFIXED($strength, 5)} pendant au moins {NATURALFIXED($time, 3)} {MANY("seconde", $time)}

reagent-effect-guidebook-disease-progress-change =
    { $chance ->
        [1] Modifie
        *[other] modifie
    } la progression des maladies {$type} de {NATURALFIXED($amount, 5)}

reagent-effect-guidebook-disease-mutate = Mute les maladies de {NATURALFIXED($amount, 4)}