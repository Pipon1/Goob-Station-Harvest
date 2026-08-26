# SPDX-License-Identifier: AGPL-3.0-or-later

humanoid-appearance-component-unknown-species = Personne
humanoid-appearance-component-examine = { $gender ->
    [male]
        { CAPITALIZE(SUBJECT($user)) } { CONJUGATE-BE($user) } { $age ->
            [jeune] un { $age } { $species }
            [vieux] un { $age } { $species }
            [moyen] un { $species } d'âge moyen
           *[other] un { $age } { $species }
        }
    [female]
        { CAPITALIZE(SUBJECT($user)) } { CONJUGATE-BE($user) } { $age ->
            [jeune] une { $age } { $species }
            [vieux] une { $age } { $species }
            [moyen] une { $species } d'âge moyen
           *[other] une { $age } { $species }
        }
   *[other]
        { CAPITALIZE(SUBJECT($user)) } { CONJUGATE-BE($user) } { $age ->
            [jeune] { FR_INDEFINITE($species) } { $age } { $species }
            [vieux] { FR_INDEFINITE($species) } { $age } { $species }
            [moyen] { FR_INDEFINITE($species) } { $species } d'âge moyen
           *[other] { FR_INDEFINITE($species) } { $age } { $species }
        }
}.
