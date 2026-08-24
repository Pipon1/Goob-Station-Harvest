# SPDX-License-Identifier: AGPL-3.0-or-later

game-ticker-restart-round = Redémarrage de la partie...
game-ticker-start-round = La partie démarre maintenant...
game-ticker-start-round-cannot-start-game-mode-fallback = Échec du démarrage du mode de jeu {$failedGameMode} ! Valeur par défaut : {$fallbackMode}...
game-ticker-start-round-cannot-start-game-mode-restart = Échec du démarrage du mode de jeu {$failedGameMode} ! Redémarrage de la partie...
game-ticker-start-round-invalid-map = La carte sélectionnée {$map} est inéligible pour le mode de jeu {$mode}. Le mode de jeu  pourrait ne pas fonctionner comme prévu...
game-ticker-unknown-role = Inconnu
game-ticker-delay-start = Le début de la partie est retardée de {$seconds} secondes.
game-ticker-pause-start = Le compte à rebours du début du round a été mis sur pause.
game-ticker-pause-start-resumed = Le compte à rebours du début du round a repris.
game-ticker-player-join-game-message = Bienvenue sur Space Station 14 ! Si c'est la première fois que vous jouez, pensez à lire les règles du jeu, et n'hésitez pas à demander de l'aide en LOOC (local OOC) ou OOC (généralement seulement disponible entre les parties).
game-ticker-get-info-text = Bonjour et bienvenue sur [color=white]Space Station 14 ![/color]
                            La partie actuelle est : [color=white]#{$roundId}[/color]
                            Le nombre de joueurs actuel est : [color=white]{$playerCount}[/color]
                            La carte actuelle est : [color=white]{$mapName}[/color]
                            Le mode de jeu actuel est : [color=white]{$gmTitle}[/color]
                            >[color=yellow]{$desc}[/color]
game-ticker-get-info-preround-text = Bonjour et bienvenue sur [color=white]Space Station 14 ![/color]
                            La partie actuelle est : [color=white]#{$roundId}[/color]
                            Le nombre de joueurs actuel est : [color=white]{$playerCount}[/color] ([color=white]{$readyCount}[/color] {$readyCount ->
                                [one] est
                                *[other] sont
                            } prêt)
                            La carte actuelle est : [color=white]{$mapName}[/color]
                            Le mode de jeu actuel est : [color=white]{$gmTitle}[/color]
                            >[color=yellow]{$desc}[/color]
game-ticker-no-map-selected = [color=yellow]Carte pas encore sélectionnée ![/color]
game-ticker-player-no-jobs-available-when-joining = Quand vous avez essayé de rejoindre la partie, aucun rôle n'était disponible.

# Displayed in chat to admins when a player joins
player-join-message = Le joueur {$name} a rejoint.
player-first-join-message = Le joueur {$name} a rejoint pour la première fois.

# Displayed in chat to admins when a player leaves
player-leave-message = Le joueur {$name} est parti.

latejoin-arrival-announcement = {$character} ({$job}) est arrivé à la station !
latejoin-arrival-announcement-special = {$job} {$character} est prêt !
latejoin-arrival-sender = Station
latejoin-arrivals-direction = Une navette de transfert vers votre station arrivera bientôt.
latejoin-arrivals-direction-time = Une navette de transfert vers votre station arrivera dans {$time}.
latejoin-arrivals-dumped-from-shuttle = Une force mystérieuse vous empêche de partir avec la navette des arrivées.
latejoin-arrivals-teleport-to-spawn = Une force mystérieuse vous téléporte hors de la navette des arrivées. Passez un bon service !

preset-not-enough-ready-players = Ne peut pas démarrer {$presetName}. Il faut au moins {$minimumPlayers} joueurs mais il n'y en a que {$readyPlayersCount}.
preset-no-one-ready = Ne peut pas démarrer {$presetName}. Aucun joueur n'est prêt.

game-run-level-PreRoundLobby = Lobby pré-partie
game-run-level-InRound = En partie
game-run-level-PostRound = Post partie
