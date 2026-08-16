# SPDX-FileCopyrightText: 2025 Aiden <28298836+Aidenkrz@users.noreply.github.com>
# SPDX-FileCopyrightText: 2025 Aiden <aiden@djkraz.com>
# SPDX-FileCopyrightText: 2025 SX-7 <92227810+SX-7@users.noreply.github.com>
#
# SPDX-License-Identifier: AGPL-3.0-or-later

reagent-effect-condition-guidebook-stamina-damage-threshold =
    { $max ->
        [2147483648] la cible a au moins {NATURALFIXED($min, 2)} dégâts d'endurance
        *[other] { $min ->
                    [0] la cible a au plus {NATURALFIXED($max, 2)} dégâts d'endurance
                    *[other] la cible a entre {NATURALFIXED($min, 2)} et {NATURALFIXED($max, 2)} dégâts d'endurance
                 }
    }

reagent-effect-condition-guidebook-unique-bloodstream-chem-threshold =
    { $max ->
        [2147483648] { $min ->
                        [1] il y a au moins {$min} réactif
                        *[other] il y a au moins {$min} réactifs
                     }
        [1] { $min ->
               [0] il y a au plus {$max} réactif
               *[other] il y a entre {$min} et {$max} réactifs
            }
        *[other] { $min ->
                    [-1] il y a au plus {$max} réactifs
                    *[other] il y a entre {$min} et {$max} réactifs
                 }
    }

reagent-effect-condition-guidebook-typed-damage-threshold =
    { $inverse ->
        [true] la cible a au plus
        *[false] la cible a au moins
    } { $changes } dégâts