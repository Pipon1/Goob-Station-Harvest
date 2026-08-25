# SPDX-License-Identifier: AGPL-3.0-or-later

defusable-examine-defused = {CAPITALIZE(THE($name))} est [color=lime]désamorcé[/color].
defusable-examine-live = {CAPITALIZE(THE($name))} [color=red]tique[/color] et il reste [color=red]{$time}[/color] secondes.
defusable-examine-live-display-off = {CAPITALIZE(THE($name))} [color=red]tique[/color], et le minuteur semble éteint.
defusable-examine-inactive = {CAPITALIZE(THE($name))} est [color=lime]inactif[/color], mais peut toujours être armé.
defusable-examine-bolts = Les verrous sont {$down ->
[true] [color=red]descendus[/color]
*[false] [color=green]levés[/color]
}.
