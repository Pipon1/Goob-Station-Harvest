# SPDX-FileCopyrightText: 2023 LankLTE <135308300+LankLTE@users.noreply.github.com>
# SPDX-FileCopyrightText: 2023 Nemanja <98561806+EmoGarbage404@users.noreply.github.com>
# SPDX-FileCopyrightText: 2023 Sailor <109166122+Equivocateur@users.noreply.github.com>
# SPDX-FileCopyrightText: 2023 mhamster <81412348+mhamsterr@users.noreply.github.com>
# SPDX-FileCopyrightText: 2024 Aidenkrz <aiden@djkraz.com>
# SPDX-FileCopyrightText: 2024 Eris <eris@erisws.com>
# SPDX-FileCopyrightText: 2024 Flesh <62557990+PolterTzi@users.noreply.github.com>
# SPDX-FileCopyrightText: 2024 Gotimanga <127038462+Gotimanga@users.noreply.github.com>
# SPDX-FileCopyrightText: 2024 Steve <marlumpy@gmail.com>
# SPDX-FileCopyrightText: 2024 Zonespace <41448081+Zonespace27@users.noreply.github.com>
# SPDX-FileCopyrightText: 2024 alex-georgeff <54858069+taurie@users.noreply.github.com>
# SPDX-FileCopyrightText: 2024 marc-pelletier <113944176+marc-pelletier@users.noreply.github.com>
# SPDX-FileCopyrightText: 2024 metalgearsloth <31366439+metalgearsloth@users.noreply.github.com>
# SPDX-FileCopyrightText: 2024 slarticodefast <161409025+slarticodefast@users.noreply.github.com>
# SPDX-FileCopyrightText: 2025 Aiden <28298836+Aidenkrz@users.noreply.github.com>
# SPDX-FileCopyrightText: 2025 Aiden <aiden@djkraz.com>
# SPDX-FileCopyrightText: 2025 SX-7 <92227810+SX-7@users.noreply.github.com>
#
# SPDX-License-Identifier: AGPL-3.0-or-later

-create-3rd-person =
    { $chance ->
        [1] Crée
        *[other] créer
    }

-cause-3rd-person =
    { $chance ->
        [1] Cause
        *[other] causer
    }

-satiate-3rd-person =
    { $chance ->
        [1] Rassasie
        *[other] rassasier
    }

entity-effect-guidebook-spawn-entity =
    { $chance ->
        [1] Crée
        *[other] créer
    } { $amount ->
        [1] {INDEFINITE($entname)}
        *[other] {$amount} {MAKEPLURAL($entname)}
    }

entity-effect-guidebook-destroy =
    { $chance ->
        [1] Détruit
        *[other] détruire
    } l'objet

entity-effect-guidebook-break =
    { $chance ->
        [1] Casse
        *[other] casser
    } l'objet

entity-effect-guidebook-explosion =
    { $chance ->
        [1] Cause
        *[other] causer
    } une explosion

entity-effect-guidebook-emp =
    { $chance ->
        [1] Cause
        *[other] causer
    } une impulsion électromagnétique

entity-effect-guidebook-flash =
    { $chance ->
        [1] Cause
        *[other] causer
    } un flash aveuglant

entity-effect-guidebook-foam-area =
    { $chance ->
        [1] Crée
        *[other] créer
    } de grandes quantités de mousse

entity-effect-guidebook-smoke-area =
    { $chance ->
        [1] Crée
        *[other] créer
    } de grandes quantités de fumée

entity-effect-guidebook-satiate-thirst =
    { $chance ->
        [1] Rassasie
        *[other] rassasier
    } { $relative ->
        [1] la soif moyennement
        *[other] la soif à {NATURALFIXED($relative, 3)}x le taux moyen
    }

entity-effect-guidebook-satiate-hunger =
    { $chance ->
        [1] Rassasie
        *[other] rassasier
    } { $relative ->
        [1] la faim moyennement
        *[other] la faim à {NATURALFIXED($relative, 3)}x le taux moyen
    }

entity-effect-guidebook-health-change =
    { $chance ->
        [1] { $healsordeals ->
                [heals] Guérit
                [deals] Inflige
                *[both] Modifie la santé de
             }
        *[other] { $healsordeals ->
                    [heals] guérir
                    [deals] infliger
                    *[both] modifier la santé de
                 }
    } { $changes }

entity-effect-guidebook-even-health-change =
    { $chance ->
        [1] { $healsordeals ->
            [heals] Guérit uniformément
            [deals] Inflige uniformément
            *[both] Modifie uniformément la santé de
        }
        *[other] { $healsordeals ->
            [heals] guérir uniformément
            [deals] infliger uniformément
            *[both] modifier uniformément la santé de
        }
    } { $changes }

entity-effect-guidebook-status-effect-old =
    { $type ->
        [update]{ $chance ->
                    [1] Cause
                     *[other] causer
                 } {LOC($key)} pendant au moins {NATURALFIXED($time, 3)} {MANY("second", $time)} sans accumulation
        [add]   { $chance ->
                    [1] Cause
                    *[other] causer
                } {LOC($key)} pendant au moins {NATURALFIXED($time, 3)} {MANY("second", $time)} avec accumulation
        [set]  { $chance ->
                    [1] Cause
                    *[other] causer
                } {LOC($key)} pendant {NATURALFIXED($time, 3)} {MANY("second", $time)} sans accumulation
        *[remove]{ $chance ->
                    [1] Enlève
                    *[other] enlever
                } {NATURALFIXED($time, 3)} {MANY("second", $time)} de {LOC($key)}
    }

entity-effect-guidebook-status-effect =
    { $type ->
    [update]{ $chance ->
    [1] Cause
    *[other] causer
                     } {LOC($key)} pendant au moins {NATURALFIXED($time, 3)} {MANY("second", $time)} sans accumulation
    [add]   { $chance ->
    [1] Cause
    *[other] causer
                    } {LOC($key)} pendant au moins {NATURALFIXED($time, 3)} {MANY("second", $time)} avec accumulation
    [set]  { $chance ->
    [1] Cause
    *[other] causer
                    } {LOC($key)} pendant au moins {NATURALFIXED($time, 3)} {MANY("second", $time)} sans accumulation
    *[remove]{ $chance ->
    [1] Enlève
    *[other] enlever
                    } {NATURALFIXED($time, 3)} {MANY("second", $time)} de {LOC($key)}
        } { $delay ->
    [0] immédiatement
    *[other] après un délai de {NATURALFIXED($delay, 3)} seconde
        }

reagent-effect-guidebook-status-effect-delay =
    { $type ->
        [add]   { $chance ->
                    [1] Cause
                    *[other] causer
                } {LOC($key)} pendant au moins {NATURALFIXED($time, 3)} {MANY("second", $time)} avec accumulation
        *[set]  { $chance ->
                    [1] Cause
                    *[other] causer
                } {LOC($key)} pendant au moins {NATURALFIXED($time, 3)} {MANY("second", $time)} sans accumulation
        [remove]{ $chance ->
                    [1] Enlève
                    *[other] enlever
                } {NATURALFIXED($time, 3)} {MANY("second", $time)} de {LOC($key)}
    } après un délai de {NATURALFIXED($delay, 3)} seconde

entity-effect-guidebook-status-effect-indef =
    { $type ->
    [update]{ $chance ->
    [1] Cause
    *[other] causer
                     } permanent {LOC($key)}
    [add]   { $chance ->
    [1] Cause
    *[other] causer
                    } permanent {LOC($key)}
    [set]  { $chance ->
    [1] Cause
    *[other] causer
                    } permanent {LOC($key)}
    *[remove]{ $chance ->
    [1] Enlève
    *[other] enlever
                    } {LOC($key)}
        } { $delay ->
    [0] immédiatement
    *[other] après un délai de {NATURALFIXED($delay, 3)} seconde
        }

reagent-effect-guidebook-knockdown =
    { $type ->
        [add]   { $chance ->
                    [1] Cause
                    *[other] causer
                } {LOC($key)} pendant au moins {NATURALFIXED($time, 3)} {MANY("second", $time)} avec accumulation
        *[set]  { $chance ->
                    [1] Cause
                    *[other] causer
                } {LOC($key)} pendant au moins {NATURALFIXED($time, 3)} {MANY("second", $time)} sans accumulation
        [remove]{ $chance ->
                    [1] Enlève
                    *[other] enlever
                } {NATURALFIXED($time, 3)} {MANY("second", $time)} de {LOC($key)}
    } après un délai de {NATURALFIXED($delay, 3)} seconde

entity-effect-guidebook-set-solution-temperature-effect =
    { $chance ->
        [1] Fixe
        *[other] fixer
    } la température de la solution à exactement {NATURALFIXED($temperature, 2)}k

entity-effect-guidebook-adjust-solution-temperature-effect =
    { $chance ->
        [1] { $deltasign ->
                [1] Ajoute
                *[-1] Enlève
            }
        *[other]
            { $deltasign ->
                [1] ajouter
                *[-1] enlever
            }
    } de la chaleur { $deltasign ->
                [1] à
                *[-1] de
           } la solution jusqu'à ce qu'elle atteigne { $deltasign ->
                [1] au maximum {NATURALFIXED($maxtemp, 2)}k
                *[-1] au minimum {NATURALFIXED($mintemp, 2)}k
            }

entity-effect-guidebook-adjust-reagent-reagent =
    { $chance ->
        [1] { $deltasign ->
                [1] Ajoute
                *[-1] Enlève
            }
        *[other]
            { $deltasign ->
                [1] ajouter
                *[-1] enlever
            }
    } {NATURALFIXED($amount, 2)}u de {$reagent} { $deltasign ->
        [1] à
        *[-1] de
    } la solution

entity-effect-guidebook-adjust-reagent-group =
    { $chance ->
        [1] { $deltasign ->
                [1] Ajoute
                *[-1] Enlève
            }
        *[other]
            { $deltasign ->
                [1] ajouter
                *[-1] enlever
            }
    } {NATURALFIXED($amount, 2)}u de produits chimiques du groupe {$group} { $deltasign ->
        [1] à
        *[-1] de
    } la solution

entity-effect-guidebook-adjust-temp =
    { $chance ->
        [1] { $deltasign ->
                [1] Ajoute
                *[-1] Enlève
            }
        *[other]
            { $deltasign ->
                [1] ajouter
                *[-1] enlever
            }
    } {POWERJOULES($amount)} de chaleur { $deltasign ->
            [1] à
            *[-1] de
        } le corps dans lequel c'est

entity-effect-guidebook-chem-cause-disease =
    { $chance ->
        [1] Cause
        *[other] causer
    } la maladie { $disease }

entity-effect-guidebook-chem-cause-random-disease =
    { $chance ->
        [1] Cause
        *[other] causer
    } les maladies { $diseases }

entity-effect-guidebook-jittering =
    { $chance ->
        [1] Cause
        *[other] causer
    } des tremblements

entity-effect-guidebook-clean-bloodstream =
    { $chance ->
        [1] Purifie
        *[other] purifier
    } le flux sanguin d'autres produits chimiques

entity-effect-guidebook-cure-disease =
    { $chance ->
        [1] Guérit
        *[other] guérir
    } les maladies

entity-effect-guidebook-eye-damage =
    { $chance ->
        [1] { $deltasign ->
                [1] Inflige
                *[-1] Guérit
            }
        *[other]
            { $deltasign ->
                [1] infliger
                *[-1] guérir
            }
    } des dégâts oculaires

entity-effect-guidebook-vomit =
    { $chance ->
        [1] Cause
        *[other] causer
    } des vomissements

entity-effect-guidebook-create-gas =
    { $chance ->
        [1] Crée
        *[other] créer
    } { $moles } { $moles ->
        [1] mole
        *[other] moles
    } de { $gas }

entity-effect-guidebook-drunk =
    { $chance ->
        [1] Cause
        *[other] causer
    } l'ivresse

entity-effect-guidebook-electrocute =
    { $chance ->
        [1] Électrocute
        *[other] électrocuter
    } le métaboliseur pendant {NATURALFIXED($time, 3)} {MANY("second", $time)}

entity-effect-guidebook-emote =
    { $chance ->
        [1] Force
        *[other] forcer
    } le métaboliseur à [bold][color=white]{$emote}[/color][/bold]

entity-effect-guidebook-extinguish-reaction =
    { $chance ->
        [1] Éteint
        *[other] éteindre
    } le feu

entity-effect-guidebook-flammable-reaction =
    { $chance ->
        [1] Augmente
        *[other] augmenter
    } l'inflammabilité

entity-effect-guidebook-ignite =
    { $chance ->
        [1] Enflamme
        *[other] enflammer
    } le métaboliseur

entity-effect-guidebook-make-sentient =
    { $chance ->
        [1] Rend
        *[other] rendre
    } le métaboliseur sensible

entity-effect-guidebook-make-polymorph =
    { $chance ->
        [1] Transforme
        *[other] transformer
    } le métaboliseur en { $entityname }

entity-effect-guidebook-modify-bleed-amount =
    { $chance ->
        [1] { $deltasign ->
                [1] Provoque
                *[-1] Réduit
            }
        *[other] { $deltasign ->
                    [1] provoquer
                    *[-1] réduire
                 }
    } des saignements

entity-effect-guidebook-modify-blood-level =
    { $chance ->
        [1] { $deltasign ->
                [1] Augmente
                *[-1] Diminue
            }
        *[other] { $deltasign ->
                    [1] augmenter
                    *[-1] diminuer
                 }
    } le niveau de sang

entity-effect-guidebook-paralyze =
    { $chance ->
        [1] Paralyse
        *[other] paralyser
    } le métaboliseur pendant au moins {NATURALFIXED($time, 3)} {MANY("second", $time)}

entity-effect-guidebook-movespeed-modifier =
    { $chance ->
        [1] Modifie
        *[other] modifier
    } la vitesse de mouvement par {NATURALFIXED($sprintspeed, 3)}x pendant au moins {NATURALFIXED($time, 3)} {MANY("second", $time)}

entity-effect-guidebook-reset-narcolepsy =
    { $chance ->
        [1] Retarde temporairement
        *[other] retarder temporairement
    } la narcolepsie

entity-effect-guidebook-wash-cream-pie-reaction =
    { $chance ->
        [1] Enlève
        *[other] enlever
    } la tarte à la crème du visage

entity-effect-guidebook-cure-zombie-infection =
    { $chance ->
        [1] Guérit
        *[other] guérir
    } une infection zombie en cours

entity-effect-guidebook-cause-zombie-infection =
    { $chance ->
        [1] Donne
        *[other] donner
    } l'infection zombie à un individu

entity-effect-guidebook-innoculate-zombie-infection =
    { $chance ->
        [1] Guérit
        *[other] guérir
    } une infection zombie en cours, et fournit l'immunité aux infections futures

entity-effect-guidebook-reduce-rotting =
    { $chance ->
        [1] Régénère
        *[other] régénérer
    } {NATURALFIXED($time, 3)} {MANY("second", $time)} de pourriture

entity-effect-guidebook-area-reaction =
    { $chance ->
        [1] Cause
        *[other] causer
    } une réaction de fumée ou de mousse pendant {NATURALFIXED($duration, 3)} {MANY("second", $duration)}

entity-effect-guidebook-add-to-solution-reaction =
    { $chance ->
        [1] Cause
        *[other] causer
    } {$reagent} à être ajouté à son conteneur de solution interne

entity-effect-guidebook-artifact-unlock =
    { $chance ->
        [1] Aide
        *[other] aider
        } à déverrouiller un artefact alien.

entity-effect-guidebook-artifact-durability-restore =
    Restaure {$restored} de durabilité dans les nœuds d'artefacts aliens actifs.

entity-effect-guidebook-plant-attribute =
    { $chance ->
        [1] Ajuste
        *[other] ajuster
    } {$attribute} par {$positive ->
    [true] [color=red]{$amount}[/color]
    *[false] [color=green]{$amount}[/color]
    }

entity-effect-guidebook-plant-cryoxadone =
    { $chance ->
        [1] Fait vieillir
        *[other] faire vieillir
    } la plante en arrière, en fonction de l'âge de la plante et du temps de croissance

entity-effect-guidebook-plant-phalanximine =
    { $chance ->
        [1] Restaure
        *[other] restaurer
    } la viabilité à une plante rendue non viable par une mutation

entity-effect-guidebook-plant-diethylamine =
    { $chance ->
        [1] Augmente
        *[other] augmenter
    } la durée de vie et/ou la santé de base de la plante avec 10% de chance chacune

entity-effect-guidebook-plant-robust-harvest =
    { $chance ->
        [1] Augmente
        *[other] augmenter
    } la puissance de la plante par {$increase} jusqu'à un maximum de {$limit}. Fait perdre ses graines à la plante une fois que la puissance atteint {$seedlesstreshold}. Essayer d'ajouter de la puissance au-delà de {$limit} peut causer une diminution du rendement à 10% de chance

entity-effect-guidebook-plant-seeds-add =
    { $chance ->
        [1] Restaure les
        *[other] restaurer les
    } graines de la plante

entity-effect-guidebook-plant-seeds-remove =
    { $chance ->
        [1] Enlève les
        *[other] enlever les
    } graines de la plante

entity-effect-guidebook-plant-mutate-chemicals =
    { $chance ->
        [1] Mute
        *[other] muter
    } une plante pour produire {$name}

# Goobstation?
reagent-effect-guidebook-add-to-chemicals =
    { $chance ->
        [1] { $deltasign ->
                [1] Ajoute
                *[-1] Enlève
            }
        *[other]
            { $deltasign ->
                [1] ajouter
                *[-1] enlever
            }
    } {NATURALFIXED($amount, 2)}u de {$reagent} { $deltasign ->
        [1] à
        *[-1] de
    } la solution
    