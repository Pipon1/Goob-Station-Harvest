# SPDX-License-Identifier: AGPL-3.0-or-later

# UI
admin-notes-title = Notes pour {$player}
admin-notes-new-note = Nouvelle note
admin-notes-show-more = Voir plus
admin-notes-for = Note pour : {$player}
admin-notes-id = Id : {$id}
admin-notes-type = Type : {$type}
admin-notes-severity = Sévérité : {$severity}
admin-notes-secret = Secret
admin-notes-notsecret = Pas secret
admin-notes-expires = Expire le : {$expires}
admin-notes-expires-never = N'expire pas
admin-notes-edited-never = Jamais
admin-notes-round-id = ID de manche : {$id}
admin-notes-round-id-unknown = ID de manche : Inconnu
admin-notes-created-by = Créé par : {$author}
admin-notes-created-at = Créé le : {$date}
admin-notes-last-edited-by = Dernière modif par : {$author}
admin-notes-last-edited-at = Dernière modif le : {$date}
admin-notes-edit = Modifier
admin-notes-delete = Supprimer
admin-notes-hide = Masquer
admin-notes-delete-confirm = Confirmer la suppression
admin-notes-edited = Dernière modif par {$author} le {$date}
admin-notes-unbanned = Débanni par {$admin} le {$date}
admin-notes-message-desc = [color=white]Vous avez reçu { $count ->
    [1] un message administratif
    *[other] messages administratifs
} depuis la dernière fois que vous avez joué sur ce serveur.[/color]
admin-notes-message-admin = De [bold]{ $admin }[/bold], écrit le { TOSTRING($date, "f") } :
admin-notes-message-wait = Le bouton d'acceptation sera activé dans {$time} secondes.
admin-notes-message-accept = Ignorer définitivement
admin-notes-message-dismiss = Ignorer pour l'instant
admin-notes-message-seen = Vu
admin-notes-banned-from = Banni de
admin-notes-the-server = le serveur
admin-notes-permanently = définitivement
admin-notes-days = {$days} jours
admin-notes-hours = {$hours} heures
admin-notes-minutes = {$minutes} minutes

# Note editor UI
admin-note-editor-title-new = Création d'une nouvelle note pour {$player}
admin-note-editor-title-existing = Modification de la note {$id} sur {$player} par {$author}
admin-note-editor-pop-out = Détacher
admin-note-editor-secret = Secret ?
admin-note-editor-secret-tooltip = Cocher cela rendra la note invisible pour le joueur
admin-note-editor-type-note = Note
admin-note-editor-type-message = Message
admin-note-editor-type-watchlist = Liste de surveillance
admin-note-editor-type-server-ban = Ban serveur
admin-note-editor-type-role-ban = Ban de rôle
admin-note-editor-severity-select = Sélectionner
admin-note-editor-severity-none = Aucun
admin-note-editor-severity-low = Faible
admin-note-editor-severity-medium = Moyen
admin-note-editor-severity-high = Élevé
admin-note-editor-expiry-checkbox = Permanent ?
admin-note-editor-expiry-checkbox-tooltip = Cocher pour définir une expiration
admin-note-editor-expiry-label = Expire le :
admin-note-editor-expiry-label-params = Expire le : {$date} (dans {$expiresIn})
admin-note-editor-expiry-label-expired = Expiré
admin-note-editor-expiry-placeholder = Entrez la date d'expiration (aaaa-MM-jj HH:mm:ss)
admin-note-editor-submit = Soumettre
admin-note-editor-submit-confirm = Êtes-vous sûr ?

# Verb
admin-notes-verb-text = Ouvrir les notes admin

# Watchlist and message login
admin-notes-watchlist = Liste de surveillance pour {$player} : {$message}
admin-notes-new-message = Vous avez reçu un message admin de {$admin} : {$message}
admin-notes-fallback-admin-name = [Système]

# Admin remarks
admin-remarks-command-description = Ouvre la page des remarques admin
admin-remarks-command-error = Les remarques admin ont été désactivées
admin-remarks-title = Remarques admin

# Misc
system-user = [Système]
