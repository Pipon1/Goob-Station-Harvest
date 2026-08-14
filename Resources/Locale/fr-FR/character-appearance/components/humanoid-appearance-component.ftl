# SPDX-License-Identifier: AGPL-3.0-or-later

humanoid-appearance-component-unknown-species = Personne
humanoid-appearance-component-examine = { CAPITALIZE(SUBJECT($user)) } { CONJUGATE-BE($user) } { $age ->
    [jeune] { INDEFINITE($age) } { $age } { $species }
    [vieux] { INDEFINITE($age) } { $age } { $species }
    [moyen] { INDEFINITE($species) } { $species } d'âge moyen
   *[other] { INDEFINITE($age) } { $age } { $species }
}.
