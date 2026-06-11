## COSMIC CULT ROUND, ANTAG & GAMEMODE TEXT

cosmiccult-announcement-sender = ???

cosmiccult-title = Culte Cosmique
cosmiccult-description = Des cultistes se cachent parmi l'équipage.

roles-antag-cosmiccult-name = Cultiste Cosmique
roles-antag-cosmiccult-description = Inaugurer la fin de toutes choses par la ruse et le sabotage, en lavant le cerveau de ceux qui vous s'opposeraient.

cosmiccult-gamemode-title = Le Culte Cosmique
cosmiccult-gamemode-description = Les scanners détectent une augmentation anormale du Λ-CDM. Il n'y a pas de données supplémentaires.

cosmiccult-vote-steward-initiator = L'Inconnu

cosmiccult-vote-steward-title = Intendance du Culte Cosmique
cosmiccult-vote-steward-briefing = Vous êtes l'Intendant du Culte Cosmique !
    Assurez-vous que Le Monument est placé dans un endroit sécurisé, et organisez le culte pour assurer votre victoire collective.
    Vous n'êtes pas autorisé à instruire les cultistes sur la façon d'utiliser ou de dépenser leur Entropie.

cosmiccult-vote-lone-steward-title = Le Cultiste Solitaire
cosmiccult-vote-lone-steward-briefing = Vous êtes complètement seul. Mais votre devoir n'est pas accompli.
    Assurez-vous que Le Monument est placé dans un endroit sécurisé, et terminez ce que le culte a commencé.

cosmiccult-finale-autocall-briefing = Le Monument s'active dans {$minutesandseconds} ! Rassemblez-vous et préparez-vous à la fin.
cosmiccult-finale-ready = Une lumière terrifiante jaillit du Monument !
cosmiccult-finale-speedup = L'appel s'accélère ! L'énergie déferle dans les environs...

cosmiccult-finale-degen = Vous vous sentez se désagréger !
cosmiccult-finale-location = Les scanners détectent un énorme pic de Λ-CDM {$location} !
cosmiccult-finale-cancel-begin = La volonté de votre esprit commence à briser le rituel...
cosmiccult-finale-beckon-begin = Les murmures au fond de votre esprit s'intensifient...
cosmiccult-finale-beckon-success = Vous appelez le rideau final.

cosmiccult-monument-powerdown = Le Monument devient étrangement silencieux.

## ROUNDEND TEXT

cosmiccult-roundend-cultist-count = {$initialCount ->
    [1] Il y avait {$initialCount} [color=#4cabb3]Cultiste Cosmique[/color].
    *[other] Il y avait {$initialCount} [color=#4cabb3]Cultistes Cosmiques[/color].
}
cosmiccult-roundend-entropy-count = Le culte a siphonné {$count} d'entropie.
cosmiccult-roundend-cultpop-count = Les cultistes représentaient {$count} % de l'équipage.
cosmiccult-roundend-monument-stage = {$stage ->
    [1] Hélas, le Monument semble abandonné.
    [2] Le Monument a progressé, mais son achèvement était hors de portée.
    [3] Le Monument a été achevé.
    *[other] [color=red]Quelque chose a VRAIMENT mal tourné.[/color]
}

cosmiccult-roundend-cultcomplete = [color=#4cabb3]Victoire totale du Culte Cosmique ![/color]
cosmiccult-roundend-cultmajor = [color=#4cabb3]Victoire majeure du Culte Cosmique ![/color]
cosmiccult-roundend-cultminor = [color=#4cabb3]Victoire mineure du Culte Cosmique ![/color]
cosmiccult-roundend-neutral = [color=yellow]Fin neutre ![/color]
cosmiccult-roundend-crewminor = [color=green]Victoire mineure de l'équipage ![/color]
cosmiccult-roundend-crewmajor = [color=green]Victoire majeure de l'équipage ![/color]
cosmiccult-roundend-crewcomplete = [color=green]Victoire totale de l'équipage ![/color]

cosmiccult-summary-cultcomplete = Les Cultistes Cosmiques ont amené la fin !
cosmiccult-summary-cultmajor = La victoire des Cultistes Cosmiques est inévitable.
cosmiccult-summary-cultminor = Le Monument est achevé, mais pas encore entièrement renforcé.
cosmiccult-summary-neutral = Le culte vivra pour voir un autre jour.
cosmiccult-summary-crewminor = Le culte s'est retrouvé sans intendant.
cosmiccult-summary-crewmajor = Tous les Cultistes Cosmiques ont été éliminés.
cosmiccult-summary-crewcomplete = Tous les Cultistes Cosmiques ont été déconvertis !

cosmiccult-elimination-shuttle-call = D'après les scans de nos capteurs longue portée, l'anomalie Λ-CDM s'est dissipée. Nous vous remercions de votre prudence. Une navette d'urgence a été automatiquement appelée à la station pour les procédures de décontamination et de débriefing. Heure d'arrivée prévue : {$time} {$units}.
cosmiccult-elimination-announcement = D'après les scans de nos capteurs longue portée, l'anomalie Λ-CDM s'est dissipée. Nous vous remercions de votre prudence. Une navette d'urgence est déjà en route. Retournez en toute sécurité au CentComm pour les procédures de décontamination et de débriefing.

## BRIEFINGS

cosmiccult-role-roundstart-fluff =
    Alors que vous vous préparez pour un nouveau shift à bord d’une énième station NanoTrasen, un savoir incommensurable envahit soudainement votre esprit !
    Une révélation sans pareille. La fin d’une souffrance cyclique et sisyphéenne.
    Un adieu en douceur.

    Il ne vous reste plus qu’à l’accueillir.

cosmiccult-role-short-briefing =
    Vous êtes un Cultiste Cosmique !
    Vos objectifs sont répertoriés dans le menu des personnages.
    Pour en savoir plus sur votre rôle, consultez l'entrée correspondante dans le guide.

cosmiccult-role-conversion-fluff =
    Alors que l'invocation s'achève, un savoir incommensurable envahit soudainement votre esprit !
    Une révélation sans pareille. La fin d’une souffrance cyclique et sisyphéenne.
    Un adieu en douceur.

    Il ne vous reste plus qu'à l'accueillir.

cosmiccult-role-deconverted-fluff =
    Un grand vide envahit votre esprit. Un vide réconfortant, mais pourtant inconnu...
    Toutes les pensées et tous les souvenirs de votre passage au sein de la secte commencent à s'estomper et à s'effacer.

cosmiccult-role-deconverted-briefing =
    Déconverti !
    Vous n'êtes plus un Cultiste Cosmique.

cosmiccult-monument-stage1-briefing =
    Le Monument a été invoqué.
    Il se trouve à {$location} !

cosmiccult-monument-stage2-briefing =
    Le Monument gagne en puissance !
    Son influence affectera l'espace réel dans {$time} secondes.

cosmiccult-monument-stage3-briefing =
    Le Monument est achevé !
    Son influence commencera à se superposer à l'espace réel dans {$time} secondes.
    C'est la dernière ligne droite ! Accumulez autant d'entropie que possible.

## MALIGN RIFTS

cosmiccult-rift-inuse = Vous ne pouvez pas faire cela pour le moment.
cosmiccult-rift-invaliduser = Vous ne disposez pas des outils nécessaires pour y faire face.
cosmiccult-rift-chaplainoops = Maniez vos Écritures sacrées.
cosmiccult-rift-alreadyempowered = Vous êtes déjà investi de pouvoir ; l'énergie de la faille serait gaspillée.
cosmiccult-rift-beginabsorb = La faille commence à fusionner avec vous...
cosmiccult-rift-beginpurge = Votre consécration commence à purger la faille maligne...

cosmiccult-rift-absorb = {$NAME} absorbe la faille, et une lumière maligne renforce son corps !
cosmiccult-rift-purge = {$NAME} purge la faille maligne de la réalité !



## UI / BASE POPUP

cosmiccult-ui-deconverted-title = Non converti
cosmiccult-ui-converted-title = Converti
cosmiccult-ui-roundstart-title = L'Inconnu

cosmiccult-ui-converted-text-1 =
    Vous avez été converti en Cultiste Cosmique.
cosmiccult-ui-converted-text-2 =
    Aidez le culte à atteindre ses objectifs tout en préservant son secret.
    Coopérez avec vos compagnons cultistes.

cosmiccult-ui-roundstart-text-1 =
    Vous êtes un Cultiste Cosmique !
cosmiccult-ui-roundstart-text-2 =
    Aidez le culte à atteindre ses objectifs tout en préservant son secret.
    Écoutez les instructions de votre intendant du culte.

cosmiccult-ui-deconverted-text-1 =
    Vous n'êtes plus un Cultiste Cosmique.
cosmiccult-ui-deconverted-text-2 =
    Vous avez perdu tous vos souvenirs liés au Culte Cosmique.
    Si vous êtes reconverti, ces souvenirs vous reviendront.

cosmiccult-ui-popup-confirm = Confirmer



## OBJECTIVES / CHARACTERMENU

objective-issuer-cosmiccult = [bold][color=#cae8e8]L'Inconnu[/color][/bold]

objective-cosmiccult-charactermenu = Vous devez provoquer la fin de toutes choses. Accomplissez vos missions pour faire progresser le culte.
objective-cosmiccult-steward-charactermenu = Vous devez diriger le culte pour provoquer la fin de toutes choses. Supervisez et assurez la progression du culte.

objective-condition-entropy-title = SIPHONNEZ L'ENTROPIE
objective-condition-entropy-desc = Siphonnez collectivement au moins {$count} d'entropie auprès de l'équipage.
objective-condition-culttier-title = RENFORCEZ LE MONUMENT
objective-condition-culttier-desc = Assurez-vous que le Monument atteigne sa pleine puissance.
objective-condition-victory-title = AMENEZ LA FIN
objective-condition-victory-desc = Invoquez L'Inconnu et annoncez le dernier rappel.

## CHAT ANNOUNCEMENTS

cosmiccult-radio-tier1-progress = Le Monument est invoqué sur la station...

cosmiccult-announce-tier2-progress = Un engourdissement inquiétant picote vos sens.
cosmiccult-announce-tier2-warning = Les scanners détectent une augmentation notable du Λ-CDM ! Des failles dans l'espace réel pourraient apparaître sous peu. Veuillez alerter le chapelain de votre station si vous en observez.

cosmiccult-announce-tier3-progress = Des arcs d'énergie noosphérique crépitent à travers la structure grinçante de la station. La fin approche.
cosmiccult-announce-tier3-warning = Augmentation critique du Λ-CDM détectée. Le personnel infecté doit être maîtrisé ou neutralisé dès qu'il est repéré.

cosmiccult-announce-finale-warning = À tout l'équipage de la station. L'anomalie Λ-CDM atteint un niveau supercritique, les instruments tombent en panne ; horizon des événements de transition noosphère-monde réel IMMINENT. Si vous n'êtes pas déjà en mode contre-protocole, sortez immédiatement et intervenez. Nous répètons : intervenez immédiatement ou mourez.

cosmiccult-announce-victory-summon = UNE FRACTION DE LA PUISSANCE COSMIQUE EST INVOQUÉE.


## MISC

cosmiccult-spire-entropy = Une particule d'entropie se condense à la surface de la flèche.
cosmiccult-entropy-inserted = Vous insufflez {$count} d'entropie dans Le Monument.
cosmiccult-entropy-unavailable = Vous ne pouvez pas faire ça maintenant.
cosmiccult-astral-ascendant = {$name}, Ascendant
cosmiccult-gear-pickup-rejection = Le {$ITEM} résiste au toucher de {CAPITALIZE(THE($TARGET))} !
cosmiccult-gear-pickup = Vous sentez que vous vous désagrégez tandis que vous tenez le {$ITEM} !

# Goobstation

cult-alert-recall-shuttle = Des concentrations élevées de Λ-CDM d'origine inconnue ont été détectées à bord de la station. Toute présence anormale doit être éliminée ou maîtrisée avant que l'évacuation puisse être autorisée.
