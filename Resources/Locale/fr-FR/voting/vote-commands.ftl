# SPDX-License-Identifier: AGPL-3.0-or-later

### Voting system related console commands

## 'createvote' command

cmd-createvote-desc = Crée un vote
cmd-createvote-help = Usage: createvote <'restart'|'preset'|'map'>
cmd-createvote-cannot-call-vote-now = Vous ne pouvez pas appeler un vote maintenant !
cmd-createvote-invalid-vote-type = Type de vote invalide
cmd-createvote-arg-vote-type = <type de vote>

## 'customvote' command

cmd-customvote-desc = Crée un vote personnalisé
cmd-customvote-help = Usage: customvote <titre> <option1> <option2> [option3...]
cmd-customvote-on-finished-tie = Le vote '{$title}' s'est terminé : égalité entre {$ties} !
cmd-customvote-on-finished-win = Le vote '{$title}' s'est terminé : {$winner} gagne !
cmd-customvote-arg-title = <titre>
cmd-customvote-arg-option-n = <option{ $n }>

## 'vote' command

cmd-vote-desc = Vote sur un vote actif
cmd-vote-help = vote <voteId> <option>
cmd-vote-cannot-call-vote-now = Vous ne pouvez pas appeler de vote pour le moment !
cmd-vote-on-execute-error-must-be-player = Doit être un joueur
cmd-vote-on-execute-error-invalid-vote-id = ID de vote invalide
cmd-vote-on-execute-error-invalid-vote-options = Options de vote invalides
cmd-vote-on-execute-error-invalid-vote = Vote invalide
cmd-vote-on-execute-error-invalid-option = Option invalide

## 'listvotes' command

cmd-listvotes-desc = Liste les votes actuellement actifs
cmd-listvotes-help = Usage: listvotes

## 'cancelvote' command

cmd-cancelvote-desc = Annule un vote actif
cmd-cancelvote-help = Usage: cancelvote <id>
                      Vous pouvez obtenir l'ID avec la commande listvotes.
cmd-cancelvote-error-invalid-vote-id = ID de vote invalide
cmd-cancelvote-error-missing-vote-id = ID manquant
cmd-cancelvote-arg-id = <id>
