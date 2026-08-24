# SPDX-License-Identifier: AGPL-3.0-or-later

generator-clogged = {CAPITALIZE(THE($generator))} s'éteint brusquement !

portable-generator-verb-start = Démarrer le générateur
portable-generator-verb-start-msg-unreliable = Démarrer le générateur. Cela peut prendre quelques essais.
portable-generator-verb-start-msg-reliable = Démarrer le générateur.
portable-generator-verb-start-msg-unanchored = Le générateur doit être ancré en premier !
portable-generator-verb-stop = Arrêter le générateur
portable-generator-start-fail = Vous tirez sur la corde, mais il ne démarre pas.
portable-generator-start-success = Vous tirez sur la corde, et il gronde à la vie.

portable-generator-ui-title = Générateur portable
portable-generator-ui-status-stopped = Arrêté :
portable-generator-ui-status-starting = Démarrage :
portable-generator-ui-status-running = En cours d'exécution :
portable-generator-ui-start = Démarrer
portable-generator-ui-stop = Arrêter
portable-generator-ui-target-power-label = Puissance cible (kW) :
portable-generator-ui-efficiency-label = Efficacité :
portable-generator-ui-fuel-use-label = Consommation de carburant :
portable-generator-ui-fuel-left-label = Carburant restant :
portable-generator-ui-clogged = Des contaminants ont été détectés dans le réservoir de carburant !
portable-generator-ui-eject = Éjecter
portable-generator-ui-eta = (~{ $minutes } min)
portable-generator-ui-unanchored = Non ancré
portable-generator-ui-current-output = Sortie actuelle : {$voltage}
portable-generator-ui-network-stats = Réseau :
portable-generator-ui-network-stats-value = { POWERWATTS($supply) } / { POWERWATTS($load) }
portable-generator-ui-network-stats-not-connected = Non connecté

power-switchable-generator-examine = La puissance de sortie est réglée sur {$voltage}.
power-switchable-generator-switched = Puissance de sortie commutée sur {$voltage} !

power-switchable-voltage = { $voltage ->
    [HV] [color=orange]HV[/color]
    [MV] [color=yellow]MV[/color]
    *[LV] [color=green]LV[/color]
}
power-switchable-switch-voltage = Changer en {$voltage}

fuel-generator-verb-disable-on = Éteignez le générateur d'abord !
