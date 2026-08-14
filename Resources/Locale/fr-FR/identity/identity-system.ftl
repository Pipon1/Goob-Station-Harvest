# SPDX-FileCopyrightText: 2022 Kara <lunarautomaton6@gmail.com>
# SPDX-FileCopyrightText: 2025 Aiden <28298836+Aidenkrz@users.noreply.github.com>
# SPDX-FileCopyrightText: 2025 Aiden <aiden@djkraz.com>
#
# SPDX-License-Identifier: AGPL-3.0-or-later

identity-unknown-name = ???

identity-age-young = jeune
identity-age-middle-aged = moyen
identity-age-old = vieux

identity-gender-feminine = femme
identity-gender-masculine = homme
identity-gender-person = personne

# This absolutely sucks to read but i don't care it works.
identity-unknown-examine = { $age ->
    [jeune] { $job ->
        [empty] { $gender ->
            [male] jeune homme
            [female] jeune femme
            [epicene] jeune personne
           *[other] jeune personne
        }
       *[other] { $gender ->
            [male] jeune homme { $job }
            [female] jeune femme { $job }
            [epicene] jeune personne { $job }
           *[other] jeune personne { $job }
        }
    }
    [moyen] { $job ->
        [empty] { $gender ->
            [male] homme d'âge moyen
            [female] femme d'âge moyen
            [epicene] personne d'âge moyen
           *[other] personne d'âge moyen
        }
       *[other] { $gender ->
            [male] homme d'âge moyen { $job }
            [female] femme d'âge moyen { $job }
            [epicene] personne d'âge moyen { $job }
           *[other] personne d'âge moyen { $job }
        }
    }
    [vieux] { $job ->
        [empty] { $gender ->
            [male] vieil homme
            [female] vieille femme
            [epicene] vieille personne
           *[other] vieille personne
        }
       *[other] { $gender ->
            [male] vieil homme { $job }
            [female] vieille femme { $job }
            [epicene] vieille personne { $job }
           *[other] vieille personne { $job }
        }
    }
   *[other] { $job ->
        [empty] { $gender ->
            [male] jeune homme
            [female] jeune femme
            [epicene] jeune personne
           *[other] jeune personne
        }
       *[other] { $gender ->
            [male] jeune homme { $job }
            [female] jeune femme { $job }
            [epicene] jeune personne { $job }
           *[other] jeune personne { $job }
        }
    }
}.
