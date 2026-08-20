# SPDX-License-Identifier: AGPL-3.0-or-later

discord-watchlist-connection-header =
    { $players ->
        [one] {$players} joueur sur une liste de surveillance s'est connecté
        *[other] {$players} joueurs sur une liste de surveillance se sont connectés
    } à {$serverName}

discord-watchlist-connection-entry = - {$playerName} avec le message "{$message}"{ $expiry ->
        [0] {""}
        *[other] {" "}(expire <t:{$expiry}:R>)
    }{ $otherWatchlists ->
        [0] {""}
        [one] {" "}et {$otherWatchlists} autre liste de surveillance
        *[other] {" "}et {$otherWatchlists} autres listes de surveillance
    }
