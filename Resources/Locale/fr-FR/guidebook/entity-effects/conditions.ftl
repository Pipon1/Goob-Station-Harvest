# SPDX-FileCopyrightText: 2023 Nemanja <98561806+EmoGarbage404@users.noreply.github.com>
# SPDX-FileCopyrightText: 2024 Kira Bridgeton <161087999+Verbalase@users.noreply.github.com>
# SPDX-FileCopyrightText: 2024 KrasnoshchekovPavel <119816022+KrasnoshchekovPavel@users.noreply.github.com>
# SPDX-FileCopyrightText: 2024 Steve <marlumpy@gmail.com>
# SPDX-FileCopyrightText: 2024 icekot8 <93311212+icekot8@users.noreply.github.com>
# SPDX-FileCopyrightText: 2024 marc-pelletier <113944176+marc-pelletier@users.noreply.github.com>
# SPDX-FileCopyrightText: 2024 potato1234_x <79580518+potato1234x@users.noreply.github.com>
# SPDX-FileCopyrightText: 2025 Aiden <28298836+Aidenkrz@users.noreply.github.com>
# SPDX-FileCopyrightText: 2025 Aiden <aiden@djkraz.com>
#
# SPDX-License-Identifier: AGPL-3.0-or-later

entity-condition-guidebook-total-damage =
    { $max ->
        [2147483648] il a au moins {NATURALFIXED($min, 2)} de dégâts totaux
        *[other] { $min ->
                    [0] il a au maximum {NATURALFIXED($max, 2)} de dégâts totaux
                    *[other] il a entre {NATURALFIXED($min, 2)} et {NATURALFIXED($max, 2)} de dégâts totaux
                 }
    }

entity-condition-guidebook-type-damage =
    { $max ->
        [2147483648] il a au moins {NATURALFIXED($min, 2)} de dégâts {$type}
        *[other] { $min ->
                    [0] il a au maximum {NATURALFIXED($max, 2)} de dégâts {$type}
                    *[other] il a entre {NATURALFIXED($min, 2)} et {NATURALFIXED($max, 2)} de dégâts {$type}
                 }
    }

entity-condition-guidebook-group-damage =
    { $max ->
        [2147483648] il a au moins {NATURALFIXED($min, 2)} de dégâts {$type}.
        *[other] { $min ->
                    [0] il a au maximum {NATURALFIXED($max, 2)} de dégâts {$type}.
                    *[other] il a entre {NATURALFIXED($min, 2)} et {NATURALFIXED($max, 2)} de dégâts {$type}
                 }
    }

entity-condition-guidebook-total-hunger =
    { $max ->
        [2147483648] la cible a au moins {NATURALFIXED($min, 2)} de faim totale
        *[other] { $min ->
                    [0] la cible a au maximum {NATURALFIXED($max, 2)} de faim totale
                    *[other] la cible a entre {NATURALFIXED($min, 2)} et {NATURALFIXED($max, 2)} de faim totale
                 }
    }

entity-condition-guidebook-reagent-threshold =
    { $max ->
        [2147483648] il y a au moins {NATURALFIXED($min, 2)}u de {$reagent}
        *[other] { $min ->
                    [0] il y a au maximum {NATURALFIXED($max, 2)}u de {$reagent}
                    *[other] il y a entre {NATURALFIXED($min, 2)}u et {NATURALFIXED($max, 2)}u de {$reagent}
                 }
    }

entity-condition-guidebook-mob-state-condition =
    la créature est { $state }

entity-condition-guidebook-job-condition =
    l'emploi de la cible est { $job }

entity-condition-guidebook-solution-temperature =
    la température de la solution est { $max ->
            [2147483648] au moins {NATURALFIXED($min, 2)}k
            *[other] { $min ->
                        [0] au maximum {NATURALFIXED($max, 2)}k
                        *[other] entre {NATURALFIXED($min, 2)}k et {NATURALFIXED($max, 2)}k
                     }
    }

entity-condition-guidebook-body-temperature =
    la température du corps est { $max ->
            [2147483648] au moins {NATURALFIXED($min, 2)}k
            *[other] { $min ->
                        [0] au maximum {NATURALFIXED($max, 2)}k
                        *[other] entre {NATURALFIXED($min, 2)}k et {NATURALFIXED($max, 2)}k
                     }
    }

entity-condition-guidebook-organ-type =
    l'organe métabolisant { $shouldhave ->
                                [true] est
                                *[false] n'est pas
                           } {INDEFINITE($name)} {$name} organe

entity-condition-guidebook-has-tag =
    la cible { $invert ->
                 [true] n'a pas
                 *[false] a
                } l'étiquette {$tag}

entity-condition-guidebook-this-reagent = ce réactif

# Goobstation?
entity-condition-guidebook-blood-reagent-threshold =
    { $max ->
        [2147483648] il y a au moins {NATURALFIXED($min, 2)}u de {$reagent}
        *[other] { $min ->
                    [0] il y a au maximum {NATURALFIXED($max, 2)}u de {$reagent}
                    *[other] il y a entre {NATURALFIXED($min, 2)}u et {NATURALFIXED($max, 2)}u de {$reagent}
                 }
    }
# Goobstation?

entity-condition-guidebook-breathing =
    le métaboliseur { $isBreathing ->
                [true] respire normalement
                *[false] s'étouffe
               }

entity-condition-guidebook-internals =
    le métaboliseur { $usingInternals ->
                [true] utilise des internales
                *[false] respire l'air atmosphérique
               }
