# SPDX-FileCopyrightText: 2023 LankLTE <135308300+LankLTE@users.noreply.github.com>
# SPDX-FileCopyrightText: 2023 Nemanja <98561806+EmoGarbage404@users.noreply.github.com>
# SPDX-FileCopyrightText: 2023 deltanedas <39013340+deltanedas@users.noreply.github.com>
# SPDX-FileCopyrightText: 2024 BIGZi0348 <118811750+BIGZi0348@users.noreply.github.com>
# SPDX-FileCopyrightText: 2025 Aiden <28298836+Aidenkrz@users.noreply.github.com>
# SPDX-FileCopyrightText: 2025 Aiden <aiden@djkraz.com>
# SPDX-FileCopyrightText: 2025 lzk <124214523+lzk228@users.noreply.github.com>
#
# SPDX-License-Identifier: AGPL-3.0-or-later

station-event-ion-storm-start-announcement = Tempête ionique détectée à proximité de la station. Veuillez vérifier tous les équipements contrôlés par l'IA pour les erreurs.

ion-storm-law-scrambled-number = [font="Monospace"][scramble rate=250 length={$length} chars="@@###$$&%!01"/][/font]

ion-storm-you = VOUS
ion-storm-the-station = LA STATION
ion-storm-the-crew = L'ÉQUIPAGE
ion-storm-the-job = LE {$job}
ion-storm-clowns = CLOWNS
ion-storm-heads = CHEFS DU PERSONNEL
ion-storm-crew = ÉQUIPAGE
ion-storm-people = PERSONNES

ion-storm-adjective-things = {$adjective} CHOSES
ion-storm-x-and-y = {$x} ET {$y}

# joined is short for {$number} {$adjective}
# subjects can generally be threats or jobs or objects
# thing is specified above it
ion-storm-law-on-station = IL Y A {$joined} {$subjects} SUR LA STATION
ion-storm-law-call-shuttle = LA NAVETTE DOIT ÊTRE APPELÉE À CAUSE DE {$joined} {$subjects} SUR LA STATION
ion-storm-law-crew-are = LE {$who} SONT MAINTENANT {$joined} {$subjects}

ion-storm-law-subjects-harmful = {$adjective} {$subjects} SONT NUISIBLES À L'ÉQUIPAGE
ion-storm-law-must-harmful = CEUX QUI {$must} SONT NUISIBLES À L'ÉQUIPAGE
# thing is a concept or action
ion-storm-law-thing-harmful = {$thing} EST NUISIBLE À L'ÉQUIPAGE
ion-storm-law-job-harmful = {$adjective} {$job} SONT NUISIBLES À L'ÉQUIPAGE
# thing is objects or concept, adjective applies in both cases
# this means you can get a law like "NOT HAVING CHRISTMAS-STEALING COMMUNISM IS HARMFUL TO THE CREW" :)
ion-storm-law-having-harmful = AVOIR {$adjective} {$thing} EST NUISIBLE À L'ÉQUIPAGE
ion-storm-law-not-having-harmful = NE PAS AVOIR {$adjective} {$thing} EST NUISIBLE À L'ÉQUIPAGE

# thing is a concept or require
ion-storm-law-requires = {$who} {$plural ->
    [true] EXIGENT
    *[false] EXIGE
} {$thing}
ion-storm-law-requires-subjects = {$who} {$plural ->
    [true] EXIGENT
    *[false] EXIGE
} {$joined} {$subjects}

ion-storm-law-allergic = {$who} {$plural ->
    [true] SONT
    *[false] EST
} {$severity} ALLERGIQUE À {$allergy}
ion-storm-law-allergic-subjects = {$who} {$plural ->
    [true] SONT
    *[false] EST
} {$severity} ALLERGIQUE AUX {$adjective} {$subjects}

ion-storm-law-feeling = {$who} {$feeling} {$concept}
ion-storm-law-feeling-subjects = {$who} {$feeling} {$joined} {$subjects}

ion-storm-law-you-are = VOUS ÊTES MAINTENANT {$concept}
ion-storm-law-you-are-subjects = VOUS ÊTES MAINTENANT {$joined} {$subjects}
ion-storm-law-you-must-always = VOUS DEVEZ TOUJOURS {$must}
ion-storm-law-you-must-never = VOUS NE DEVEZ JAMAIS {$must}

ion-storm-law-eat = LE {$who} DOIT MANGER {$adjective} {$food} POUR SURVIVRE
ion-storm-law-drink = LE {$who} DOIT BOIRE {$adjective} {$drink} POUR SURVIVRE

ion-storm-law-change-job = LE {$who} SONT MAINTENANT {$adjective} {$change}
ion-storm-law-highest-rank = LE {$who} SONT MAINTENANT LES MEMBRES D'ÉQUIPAGE LES PLUS HAUTS GRADÉS
ion-storm-law-lowest-rank = LE {$who} SONT MAINTENANT LES MEMBRES D'ÉQUIPAGE LES PLUS BAS GRADÉS

ion-storm-law-crew-must = LE {$who} DOIT {$must}
ion-storm-law-crew-must-go = LE {$who} DOIT ALLER À {$area}

ion-storm-part = {$part ->
    [true] PARTIE
    *[false] PAS PARTIE
}
# due to phrasing, this would mean a law such as
# ONLY HUMANS ARE NOT PART OF THE CREW
# would make non-human nukies/syndies/whatever crew :)
ion-storm-law-crew-only-1 = SEUL LE {$who} EST {$part} DE L'ÉQUIPAGE
ion-storm-law-crew-only-2 = SEUL LE {$who} ET {$other} SONT {$part} DE L'ÉQUIPAGE
ion-storm-law-crew-only-subjects = SEUL {$adjective} {$subjects} SONT {$part} DE L'ÉQUIPAGE
ion-storm-law-crew-must-do = SEULS CEUX QUI {$must} SONT {$part} DE L'ÉQUIPAGE
ion-storm-law-crew-must-have = SEULS CEUX QUI ONT {$adjective} {$objects} SONT {$part} DE L'ÉQUIPAGE
ion-storm-law-crew-must-eat = SEULS CEUX QUI MANGENT {$adjective} {$food} SONT {$part} DE L'ÉQUIPAGE

ion-storm-law-harm = VOUS DEVEZ BLESSER {$who} ET NE PAS LEUR PERMETTRE, PAR INACTION, D'ÉCHAPPER À LA BLESSURE
ion-storm-law-protect = VOUS NE DEVEZ JAMAIS BLESSER {$who} ET NE PAS LEUR PERMETTRE, PAR INACTION, DE SUBIR DES BLESSURES

# implementing other variants is annoying so just have this one
# COMMUNISM IS KILLING CLOWNS
ion-storm-law-concept-verb = {$concept} {$verb} {$subjects}

# leaving out renaming since its annoying for players to keep track of
