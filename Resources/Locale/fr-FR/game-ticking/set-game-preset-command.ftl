# SPDX-FileCopyrightText: 2023 Nemanja <98561806+EmoGarbage404@users.noreply.github.com>
# SPDX-FileCopyrightText: 2024 Errant <35878406+Errant-4@users.noreply.github.com>
# SPDX-FileCopyrightText: 2024 metalgearsloth <31366439+metalgearsloth@users.noreply.github.com>
# SPDX-FileCopyrightText: 2025 Aiden <28298836+Aidenkrz@users.noreply.github.com>
# SPDX-FileCopyrightText: 2025 Aiden <aiden@djkraz.com>
#
# SPDX-License-Identifier: AGPL-3.0-or-later

set-game-preset-command-description = Définit le préréglage de jeu pour le nombre spécifié de manches à venir. Peut également afficher le titre et la description d'un autre préréglage dans le hall pour tromper les joueurs.
set-game-preset-command-help-text = setgamepreset <id> [nombre de manches, par défaut : 1] [préréglage leurre]
set-game-preset-command-hint-1 = <id>
set-game-preset-command-hint-2 = [nombre de manches]
set-game-preset-command-hint-3 = [préréglage leurre]

set-game-preset-optional-argument-not-integer = Si le deuxième argument est fourni, il doit s'agir d'un nombre.
set-game-preset-preset-error = Impossible de trouver le préréglage de jeu "{$preset}".
set-game-preset-decoy-error = Si le troisième argument est fourni, il doit s'agir d'un préréglage valide. Impossible de trouver le préréglage de jeu "{$preset}".

#set-game-preset-preset-set = Préréglage de jeu défini sur "{$preset}"
set-game-preset-preset-set-finite = Préréglage de jeu défini sur "{$preset}" pour les {$rounds} prochaines manches.
set-game-preset-preset-set-finite-with-decoy = Préréglage de jeu défini sur "{$preset}" pour les {$rounds} prochaines manches, tout en affichant "{$decoy}" dans le hall.
