# SPDX-License-Identifier: AGPL-3.0-or-later

armor-examine-stamina = - [color=cyan]Endurance[/color] : dégâts réduits de [color=lightblue]{$num}%[/color].

armor-examine-cancel-delayed-knockdown = - [color=green]Annule complètement[/color] l'étourdissement différé de la matraque.

armor-examine-modify-delayed-knockdown-delay =
    - { $deltasign ->
          [1] [color=green]Augmente[/color]
          *[-1] [color=red]Diminue[/color]
      } le délai d'étourdissement différé de la matraque de [color=lightblue]{NATURALFIXED($amount, 2)} { $amount ->
          [1] seconde
          *[other] secondes
      }[/color].

armor-examine-modify-delayed-knockdown-time =
    - { $deltasign ->
          [1] [color=red]Augmente[/color]
          *[-1] [color=green]Diminue[/color]
      } la durée d'étourdissement différé de la matraque de [color=lightblue]{NATURALFIXED($amount, 2)} { $amount ->
          [1] seconde
          *[other] secondes
      }[/color].
