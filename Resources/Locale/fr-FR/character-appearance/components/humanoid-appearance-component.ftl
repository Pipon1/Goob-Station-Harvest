# SPDX-License-Identifier: AGPL-3.0-or-later

humanoid-appearance-component-unknown-species = Personne
humanoid-appearance-component-examine = { CAPITALIZE(SUBJECT($user)) } { CONJUGATE-BE($user) } { $age ->
    [jeune] { INDEFINITE($species) } { $age } { $species }
    [vieux] { INDEFINITE($species) } { $age } { $species }
    [moyen] { INDEFINITE($species) } { $species } d'âge moyen
   *[other] { $age } { $species }
}.
