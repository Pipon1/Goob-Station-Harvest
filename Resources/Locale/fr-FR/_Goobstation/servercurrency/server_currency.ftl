# SPDX-FileCopyrightText: 2025 Aiden <28298836+Aidenkrz@users.noreply.github.com>
# SPDX-FileCopyrightText: 2025 Aiden <aiden@djkraz.com>
# SPDX-FileCopyrightText: 2025 SX-7 <92227810+SX-7@users.noreply.github.com>
# SPDX-FileCopyrightText: 2025 gluesniffler <159397573+gluesniffler@users.noreply.github.com>
#
# SPDX-License-Identifier: AGPL-3.0-or-later

server-currency-name-singular = Goob Coin
server-currency-name-plural = Goob Coins

## Commands

server-currency-gift-command = gift
server-currency-gift-command-description = Offre une partie de votre solde à un autre joueur.
server-currency-gift-command-help = Usage : gift <joueur> <valeur>
server-currency-gift-command-error-1 = Vous ne pouvez pas vous offrir à vous-même !
server-currency-gift-command-error-2 = Vous ne pouvez pas vous permettre ce cadeau ! Votre solde est de {$balance}.
server-currency-gift-command-giver = Vous avez donné {$amount} à {$player}.
server-currency-gift-command-reciever = {$player} vous a donné {$amount}.

server-currency-balance-command = balance
server-currency-balance-command-description = Affiche votre solde.
server-currency-balance-command-help = Usage : balance
server-currency-balance-command-return = Vous avez {$balance}.

server-currency-add-command = balance:add
server-currency-add-command-description = Ajoute de la monnaie au solde d'un joueur.
server-currency-add-command-help = Usage : balance:add <joueur> <valeur>

server-currency-remove-command = balance:rem
server-currency-remove-command-description = Retire de la monnaie du solde d'un joueur.
server-currency-remove-command-help = Usage : balance:rem <joueur> <valeur>

server-currency-set-command = balance:set
server-currency-set-command-description = Définit le solde d'un joueur.
server-currency-set-command-help = Usage : balance:set <joueur> <valeur>

server-currency-get-command = balance:get
server-currency-get-command-description = Récupère le solde d'un joueur.
server-currency-get-command-help = Usage : balance:get <joueur>

server-currency-command-completion-1 = Nom d'utilisateur
server-currency-command-completion-2 = Valeur
server-currency-command-error-1 = Impossible de trouver un joueur avec ce nom.
server-currency-command-error-2 = La valeur doit être un entier.
server-currency-command-return = {$player} a {$balance}.

# 65% Update

gs-balanceui-title = Boutique
gs-balanceui-confirm = Confirmer

gs-balanceui-gift-label = Transfert :
gs-balanceui-gift-player = Joueur
gs-balanceui-gift-player-tooltip = Insérez le nom du joueur auquel vous voulez envoyer l'argent
gs-balanceui-gift-value = Valeur
gs-balanceui-gift-value-tooltip = Montant à transférer

gs-balanceui-shop-label = Boutique de Jetons
gs-balanceui-shop-empty = Rupture de stock !
gs-balanceui-shop-buy = Acheter
gs-balanceui-shop-footer = ⚠ Ahelp pour utiliser votre jeton. Une seule utilisation par jour.

gs-balanceui-shop-token-label = Jetons
gs-balanceui-shop-tittle-label = Titres

gs-balanceui-shop-buy-token-antag = Acheter un Jeton Antag - {$price} Goob Coins
gs-balanceui-shop-buy-token-admin-abuse = Acheter un Jeton Abus Admin - {$price} Goob Coins
gs-balanceui-shop-buy-token-hat = Acheter un Jeton Chapeau - {$price} Goob Coins

gs-balanceui-shop-token-antag = Jeton Antag Haut Niveau
gs-balanceui-shop-token-admin-abuse = Jeton Abus Admin
gs-balanceui-shop-token-hat = Jeton Chapeau

gs-balanceui-shop-buy-token-antag-desc = Vous permet de devenir n'importe quel antagoniste. (Hors Mages)
gs-balanceui-shop-buy-token-admin-abuse-desc = Vous permet de demander à un admin d'abuser de ses pouvoirs contre vous. Les admins sont encouragés à se lâcher.
gs-balanceui-shop-buy-token-hat-desc = Un admin vous donnera un chapeau aléatoire.

gs-balanceui-admin-add-label = Ajouter (ou retirer) de l'argent :
gs-balanceui-admin-add-player = Nom du joueur
gs-balanceui-admin-add-value = Valeur

gs-balanceui-remark-token-antag = Acheté un jeton antag.
gs-balanceui-remark-token-admin-abuse = Acheté un jeton abus admin.
gs-balanceui-remark-token-hat = Acheté un jeton chapeau.
gs-balanceui-shop-click-confirm = Cliquez à nouveau pour confirmer
gs-balanceui-shop-purchased = Acheté {$item}