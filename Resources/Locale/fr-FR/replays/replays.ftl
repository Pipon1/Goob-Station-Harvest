# SPDX-License-Identifier: AGPL-3.0-or-later

# Loading Screen

replay-loading = Chargement ({$cur}/{$total})
replay-loading-reading = Lecture des fichiers
replay-loading-processing = Traitement des fichiers
replay-loading-spawning = Génération des entités
replay-loading-initializing = Initialisation des entités
replay-loading-starting= Démarrage des entités
replay-loading-failed = Échec du chargement du replay. Erreur :
                        {$reason}
replay-loading-retry = Essayer de charger avec plus de tolérance aux exceptions - PEUT PROUQUER DES BUGS !
replay-loading-cancel = Annuler

# Main Menu
replay-menu-subtext = Client de Replay
replay-menu-load = Charger le replay sélectionné
replay-menu-select = Sélectionner un replay
replay-menu-open = Ouvrir le dossier des replays
replay-menu-none = Aucun replay trouvé.

# Main Menu Info Box
replay-info-title = Informations sur le replay
replay-info-none-selected = Aucun replay sélectionné
replay-info-invalid = [color=red]Replay sélectionné invalide[/color]
replay-info-info = {"["}color=gray]Sélectionné :[/color]  {$name} ({$file})
                   {"["}color=gray]Temps :[/color]   {$time}
                   {"["}color=gray]ID du tour :[/color]   {$roundId}
                   {"["}color=gray]Durée :[/color]   {$duration}
                   {"["}color=gray]ID de la fork :[/color]   {$forkId}
                   {"["}color=gray]Version :[/color]   {$version}
                   {"["}color=gray]Moteur :[/color]   {$engVersion}
                   {"["}color=gray]Hash de type :[/color]   {$hash}
                   {"["}color=gray]Hash de compilation :[/color]   {$compHash}

# Replay selection window
replay-menu-select-title = Sélectionner un replay

# Replay related verbs
replay-verb-spectate = Spectateur

# command
cmd-replay-spectate-help = replay_spectate [entité facultative]
cmd-replay-spectate-desc = Attache ou détache le joueur local à un uid d'entité donné.
cmd-replay-spectate-hint = Uid d'entité facultatif

cmd-replay-toggleui-desc = Active/désactive l'interface de contrôle du replay.
