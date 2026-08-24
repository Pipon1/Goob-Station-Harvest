# SPDX-FileCopyrightText: 2021 20kdc <asdd2808@gmail.com>
# SPDX-FileCopyrightText: 2021 DrSmugleaf <DrSmugleaf@users.noreply.github.com>
# SPDX-FileCopyrightText: 2021 Galactic Chimp <63882831+GalacticChimp@users.noreply.github.com>
# SPDX-FileCopyrightText: 2021 Leon Friedrich <60421075+ElectroJr@users.noreply.github.com>
# SPDX-FileCopyrightText: 2022 Kara <lunarautomaton6@gmail.com>
# SPDX-FileCopyrightText: 2024 Pieter-Jan Briers <pieterjan.briers+git@gmail.com>
# SPDX-FileCopyrightText: 2024 Plykiya <58439124+Plykiya@users.noreply.github.com>
# SPDX-FileCopyrightText: 2024 Plykiya <plykiya@protonmail.com>
# SPDX-FileCopyrightText: 2025 Aiden <28298836+Aidenkrz@users.noreply.github.com>
# SPDX-FileCopyrightText: 2025 Aiden <aiden@djkraz.com>
#
# SPDX-License-Identifier: AGPL-3.0-or-later

## UI

injector-volume-transfer-label = Volume : [color=white]{$currentVolume}/{$totalVolume}u[/color]
    Mode : [color=white]{$modeString}[/color] ([color=white]{$transferVolume}u[/color])
injector-volume-label = Volume : [color=white]{$currentVolume}/{$totalVolume}u[/color]
    Mode : [color=white]{$modeString}[/color]
injector-toggle-verb-text = Basculer le mode injecteur

## Entity

injector-component-inject-mode-name = injecter
injector-component-draw-mode-name = aspirer
injector-component-dynamic-mode-name = dynamique
injector-component-mode-changed-text = Maintenant {$mode}
injector-component-transfer-success-message = Vous transférez {$amount}u dans {THE($target)}.
injector-component-transfer-success-message-self = Vous transférez {$amount}u en vous-même.
injector-component-inject-success-message = Vous injectez {$amount}u dans {THE($target)} !
injector-component-inject-success-message-self = Vous vous injectez {$amount}u !
injector-component-draw-success-message = Vous aspirez {$amount}u de {THE($target)}.
injector-component-draw-success-message-self = Vous vous aspirez {$amount}u.

## Fail Messages

injector-component-target-already-full-message = {CAPITALIZE(THE($target))} est déjà plein !
injector-component-target-already-full-message-self = Vous êtes déjà plein !
injector-component-target-is-empty-message = {CAPITALIZE(THE($target))} est vide !
injector-component-target-is-empty-message-self = Vous êtes vide !
injector-component-cannot-toggle-draw-message = Trop plein pour aspirer !
injector-component-cannot-toggle-inject-message = Rien à injecter !
injector-component-cannot-toggle-dynamic-message = Impossible de basculer dynamique !
injector-component-empty-message = {CAPITALIZE(THE($injector))} est vide !
injector-component-blocked-user = L'équipement de protection a bloqué votre injection !
injector-component-blocked-other = {CAPITALIZE(THE(POSS-ADJ($target)))} l'armure a bloqué l'injection de {THE($user)} !
injector-component-cannot-transfer-message = Vous ne pouvez pas transférer dans {THE($target)} !
injector-component-cannot-transfer-message-self = Vous ne pouvez pas vous transférer !
injector-component-cannot-inject-message = Vous ne pouvez pas injecter dans {THE($target)} !
injector-component-cannot-inject-message-self = Vous ne pouvez pas vous injecter !
injector-component-cannot-draw-message = Vous ne pouvez pas aspirer de {THE($target)} !
injector-component-cannot-draw-message-self = Vous ne pouvez pas vous aspirer !
injector-component-ignore-mobs = Cet injecteur ne peut interagir qu'avec des conteneurs !

## mob-inject doafter messages

injector-component-needle-injecting-user = Vous commencez à injecter l'aiguille.
injector-component-needle-injecting-target = {CAPITALIZE(THE($user))} essaie de vous injecter une aiguille !
injector-component-needle-drawing-user = Vous commencez à aspirer avec l'aiguille.
injector-component-needle-drawing-target = {CAPITALIZE(THE($user))} essaie d'utiliser une aiguille pour vous aspirer !
injector-component-spray-injecting-user = Vous commencez à préparer la buse de pulvérisation.
injector-component-spray-injecting-target = {CAPITALIZE(THE($user))} essaie de placer une buse de pulvérisation sur vous !

## Target Popup Success messages
injector-component-feel-prick-message = Vous sentez une légère piqûre !

# Goob
injector-component-deny-user = Exosquelette trop épais !
