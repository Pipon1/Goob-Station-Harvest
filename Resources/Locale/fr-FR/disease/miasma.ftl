# SPDX-License-Identifier: AGPL-3.0-or-later

ammonia-smell = Ça sent le pungent !

## Perishable

perishable-1 = [color=green]{ CAPITALIZE(POSS-ADJ($target)) } cadavre a l'air encore frais.[/color]
perishable-2 = [color=orangered]{ CAPITALIZE(POSS-ADJ($target)) } cadavre a l'air relativement frais.[/color]
perishable-3 = [color=red]{ CAPITALIZE(POSS-ADJ($target)) } cadavre n'a pas l'air très frais.[/color]

perishable-1-nonmob = [color=green]{ CAPITALIZE(SUBJECT($target)) } a l'air encore frais.[/color]
perishable-2-nonmob = [color=orangered]{ CAPITALIZE(SUBJECT($target)) } a l'air relativement frais.[/color]
perishable-3-nonmob = [color=red]{ CAPITALIZE(SUBJECT($target)) } n'a pas l'air très frais.[/color]

## Rotting

rotting-rotting = [color=orange]{ CAPITALIZE(POSS-ADJ($target)) } cadavre est en train de pourrir ![/color]
rotting-bloated = [color=orangered]{ CAPITALIZE(POSS-ADJ($target)) } cadavre est gonflé ![/color]
rotting-extremely-bloated = [color=red]{ CAPITALIZE(POSS-ADJ($target)) } cadavre est extrêmement gonflé ![/color]

rotting-rotting-nonmob = [color=orange]{ CAPITALIZE(SUBJECT($target)) } est en train de pourrir ![/color]
rotting-bloated-nonmob = [color=orangered]{ CAPITALIZE(SUBJECT($target)) } est gonflé ![/color]
rotting-extremely-bloated-nonmob = [color=red]{ CAPITALIZE(SUBJECT($target)) } est extrêmement gonflé ![/color]
