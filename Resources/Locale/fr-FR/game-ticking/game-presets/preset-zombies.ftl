# SPDX-License-Identifier: AGPL-3.0-or-later

zombie-title = Zombies
zombie-description = Les morts-vivants ont été déchaînés sur la station ! Travaille avec l'équipage pour survivre à l'épidémie et sécuriser la station.

zombieteors-title = Zombieteors
zombieteors-description = Les morts-vivants ont été déchaînés sur la station dans une douche de météores cataclysmique ! Travaille avec ton équipage et fais de ton mieux pour survivre !

zombie-not-enough-ready-players = Pas assez de joueurs prêts pour le jeu ! Il y avait {$readyPlayersCount} joueurs prêts sur le {$minimumPlayers} nécessaires. Impossible de commencer les Zombies.
zombie-no-one-ready = Aucun joueur prêt ! Impossible de commencer les Zombies.

zombie-patientzero-role-greeting = Vous êtes un patient zéro infecté. Récupère des fournitures et préparez-vous pour votre transformation éventuelle. Votre objectif est de prendre le contrôle de la station en infectant autant de personnes que possible.
zombie-healing = Vous ressentez un remous dans votre chair
zombie-infection-warning = Vous sentez le virus zombie prendre le contrôle
zombie-infection-underway = Votre sang commence à s'épaissir

## goob edit
zombie-start-announcement = Épidémie confirmée de danger biologique de niveau 7 à bord de la station. La sécurité ne peut plus vous protéger. Dirigez-vous vers les zones protégées et retranchez-vous pour l'évacuation.
### Over
zombie-alone = Vous vous sentez entièrement seul.

zombie-shuttle-call = Nous avons détecté que les morts-vivants ont pris le contrôle de la station. Envoi d'une navette d'urgence pour récupérer le personnel restant.

zombie-round-end-initial-count = {$initialCount ->
    [one] Il y avait un premier infecté :
    *[other] Il y avait {$initialCount} premiers infectés :
}
zombie-round-end-user-was-initial = - [color=plum]{$name}[/color] ([color=gray]{$username}[/color]) était l'un des premiers infectés.

zombie-round-end-amount-none = [color=green]Tous les zombies ont été éradiqués ![/color]
zombie-round-end-amount-low = [color=green]Presque tous les zombies ont été exterminés.[/color]
zombie-round-end-amount-medium = [color=yellow]{$percent}% de l'équipage ont été transformés en zombies.[/color]
zombie-round-end-amount-high = [color=crimson]{$percent}% de l'équipage ont été transformés en zombies.[/color]
zombie-round-end-amount-all = [color=darkred]Tout l'équipage est devenu des zombies![/color]

zombie-round-end-survivor-count = {$count ->
    [one] Il ne restait qu'un seul survivant :
    *[other] Il ne restait que {$count} survivants :
}
zombie-round-end-user-was-survivor = - [color=White]{$name}[/color] ([color=gray]{$username}[/color]) a survécu à l'épidémie.
