# SPDX-License-Identifier: AGPL-3.0-or-later

bounty-console-menu-title = Console des primes du cargo
bounty-console-label-button-text = Imprimer l'étiquette
bounty-console-skip-button-text = Ignorer
bounty-console-time-label = Temps : [color=orange]{$time}[/color]
bounty-console-reward-label = Récompense : [color=limegreen]${$reward}[/color]
bounty-console-manifest-label = Manifeste : [color=orange]{$item}[/color]
bounty-console-manifest-entry =
    { $amount ->
        [1] {$item}
        *[other] {$item} x{$amount}
    }
bounty-console-manifest-reward = Récompense : ${$reward}
bounty-console-description-label = [color=gray]{$description}[/color]
bounty-console-id-label = ID#{$id}

bounty-console-flavor-left = Primes fournies par des revendeurs locaux peu scrupuleux.
bounty-console-flavor-right = v1.4

bounty-manifest-header = [font size=14][bold]Manifeste officiel des primes du cargo[/bold] (ID#{$id})[/font]
bounty-manifest-list-start = Manifeste des articles :

bounty-console-tab-available-label = Disponibles
bounty-console-tab-history-label = Historique
bounty-console-history-empty-label = Aucun historique de prime trouvé
bounty-console-history-notice-completed-label = [color=limegreen]Complétée[/color]
bounty-console-history-notice-skipped-label = [color=red]Ignorée[/color] par {$id}
