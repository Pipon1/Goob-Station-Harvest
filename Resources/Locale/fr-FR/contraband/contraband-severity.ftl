# SPDX-FileCopyrightText: 2024 Kara <lunarautomaton6@gmail.com>
# SPDX-FileCopyrightText: 2024 Plykiya <58439124+Plykiya@users.noreply.github.com>
# SPDX-FileCopyrightText: 2024 ThatGuyUSA <thatguyusa123@gmail.com>
# SPDX-FileCopyrightText: 2025 Aiden <28298836+Aidenkrz@users.noreply.github.com>
# SPDX-FileCopyrightText: 2025 Aiden <aiden@djkraz.com>
# SPDX-FileCopyrightText: 2025 Ignaz "Ian" Kraft <ignaz.k@live.de>
# SPDX-FileCopyrightText: 2025 Killerqu00 <47712032+Killerqu00@users.noreply.github.com>
#
# SPDX-License-Identifier: AGPL-3.0-or-later

# Goobstation? Clown?
contraband-examine-text-Clown = [color=yellow]Cet objet appartient au clown, rendez-le avant qu'il ne soit triste.[/color]
contraband-examine-text-Minor =
    { $type ->
        *[item] [color=yellow]Cet objet est considéré comme une contrebande mineure.[/color]
        [reagent] [color=yellow]Ce réactif est considéré comme une contrebande mineure.[/color]
    }

contraband-examine-text-Restricted =
    { $type ->
        *[item] [color=yellow]Cet objet est restreint à un département.[/color]
        [reagent] [color=yellow]Ce réactif est restreint à un département.[/color]
    }

contraband-examine-text-Restricted-department =
    { $type ->
        *[item] [color=yellow]Cet objet est restreint à {$departments}, et peut être considéré comme de la contrebande.[/color]
        [reagent] [color=yellow]Ce réactif est restreint à {$departments}, et peut être considéré comme de la contrebande.[/color]
    }

contraband-examine-text-Major =
    { $type ->
        *[item] [color=red]Cet objet est considéré comme une contrebande majeure.[/color]
        [reagent] [color=red]Ce réactif est considéré comme une contrebande majeure.[/color]
    }

contraband-examine-text-GrandTheft =
    { $type ->
        *[item] [color=red]Cet objet est une cible très précieuse pour les agents du Syndicat ![/color]
        [reagent] [color=red]Ce réactif est une cible très précieuse pour les agents du Syndicat ![/color]
    }

contraband-examine-text-Highly-Illegal =
    { $type ->
        *[item] [color=crimson]Cet objet est une contrebande hautement illégale ![/color]
        [reagent] [color=crimson]Ce réactif est une contrebande hautement illégale ![/color]
    }

contraband-examine-text-Syndicate =
    { $type ->
        *[item] [color=crimson]Cet objet est une contrebande du Syndicat hautement illégale ![/color]
        [reagent] [color=crimson]Ce réactif est une contrebande du Syndicat hautement illégale ![/color]
    }

contraband-examine-text-Magical =
    { $type ->
        *[item] [color=#b337b3]Cet objet est une contrebande magique hautement illégale ![/color]
        [reagent] [color=#b337b3]Ce réactif est une contrebande magique hautement illégale ![/color]
    }

contraband-examine-text-avoid-carrying-around = [color=red][italic]Vous devriez probablement éviter de porter ceci visiblement sans une bonne raison.[/italic][/color]
contraband-examine-text-in-the-clear = [color=green][italic]Vous devriez être en sécurité pour porter ceci visiblement.[/italic][/color]

contraband-examinable-verb-text = Légalité
contraband-examinable-verb-message = Vérifier la légalité de cet objet.

contraband-department-plural = {$department}
contraband-job-plural = {MAKEPLURAL($job)}
