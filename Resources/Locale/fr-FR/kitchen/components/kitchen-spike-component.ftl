# SPDX-FileCopyrightText: 2021 DrSmugleaf <DrSmugleaf@users.noreply.github.com>
# SPDX-FileCopyrightText: 2021 FoLoKe <36813380+FoLoKe@users.noreply.github.com>
# SPDX-FileCopyrightText: 2021 Galactic Chimp <63882831+GalacticChimp@users.noreply.github.com>
# SPDX-FileCopyrightText: 2021 ShadowCommander <10494922+ShadowCommander@users.noreply.github.com>
# SPDX-FileCopyrightText: 2021 mirrorcult <notzombiedude@gmail.com>
# SPDX-FileCopyrightText: 2022 Leon Friedrich <60421075+ElectroJr@users.noreply.github.com>
# SPDX-FileCopyrightText: 2022 metalgearsloth <31366439+metalgearsloth@users.noreply.github.com>
# SPDX-FileCopyrightText: 2022 mirrorcult <lunarautomaton6@gmail.com>
# SPDX-FileCopyrightText: 2024 lzk <124214523+lzk228@users.noreply.github.com>
# SPDX-FileCopyrightText: 2024 yglop <95057024+yglop@users.noreply.github.com>
# SPDX-FileCopyrightText: 2025 Aiden <28298836+Aidenkrz@users.noreply.github.com>
# SPDX-FileCopyrightText: 2025 Aiden <aiden@djkraz.com>
#
# SPDX-License-Identifier: AGPL-3.0-or-later

comp-kitchen-spike-deny-collect = { CAPITALIZE(THE($this)) } a déjà quelque chose dessus, finissez de récupérer sa viande d'abord !
comp-kitchen-spike-deny-butcher = { CAPITALIZE(THE($victim)) } ne peut pas être dépecé sur { THE($this) }.
comp-kitchen-spike-deny-changeling = { CAPITALIZE(THE($victim)) } résiste à être mis sur { THE($this) }.
comp-kitchen-spike-deny-absorbed = { CAPITALIZE(THE($victim)) } n'a rien à dépecer.
comp-kitchen-spike-deny-butcher-knife = { CAPITALIZE(THE($victim)) } ne peut pas être dépecé sur { THE($this) }, vous devez le dépecer avec un couteau.
comp-kitchen-spike-deny-not-dead = { CAPITALIZE(THE($victim)) } ne peut pas être dépecé. { CAPITALIZE(SUBJECT($victim)) } { CONJUGATE-BE($victim) } pas mort !
comp-kitchen-spike-begin-hook-self = Vous commencez à vous traîner sur { THE($hook) } !
comp-kitchen-spike-begin-hook-self-other = { CAPITALIZE(THE($victim)) } commence à se traîner sur { THE($hook) } !

comp-kitchen-spike-begin-hook-other-self = Vous commencez à traîner { CAPITALIZE(THE($victim)) } sur { THE($hook) } !
comp-kitchen-spike-begin-hook-other = { CAPITALIZE(THE($user)) } commence à traîner { CAPITALIZE(THE($victim)) } sur { THE($hook) } !

comp-kitchen-spike-hook-self = Vous vous êtes jeté sur { THE($hook) } !
comp-kitchen-spike-hook-self-other = { CAPITALIZE(THE($victim)) } s'est jeté sur { THE($hook) } !

comp-kitchen-spike-hook-other-self = Vous avez jeté { CAPITALIZE(THE($victim)) } sur { THE($hook) } !
comp-kitchen-spike-hook-other = { CAPITALIZE(THE($user)) } a jeté { CAPITALIZE(THE($victim)) } sur { THE($hook) } !

comp-kitchen-spike-begin-unhook-self = Vous commencez à vous traîner hors de { THE($hook) } !
comp-kitchen-spike-begin-unhook-self-other = { CAPITALIZE(THE($victim)) } commence à se traîner hors de { THE($hook) } !

comp-kitchen-spike-begin-unhook-other-self = Vous commencez à traîner { CAPITALIZE(THE($victim)) } hors de { THE($hook) } !
comp-kitchen-spike-begin-unhook-other = { CAPITALIZE(THE($user)) } commence à traîner { CAPITALIZE(THE($victim)) } hors de { THE($hook) } !

comp-kitchen-spike-unhook-self = Vous vous êtes libéré de { THE($hook) } !
comp-kitchen-spike-unhook-self-other = { CAPITALIZE(THE($victim)) } s'est libéré de { THE($hook) } !

comp-kitchen-spike-unhook-other-self = Vous avez libéré { CAPITALIZE(THE($victim)) } de { THE($hook) } !
comp-kitchen-spike-unhook-other = { CAPITALIZE(THE($user)) } a libéré { CAPITALIZE(THE($victim)) } de { THE($hook) } !

comp-kitchen-spike-begin-butcher-self = Vous commencez à dépecer { THE($victim) } !
comp-kitchen-spike-begin-butcher = { CAPITALIZE(THE($user)) } commence à dépecer { THE($victim) } !

comp-kitchen-spike-butcher-self = Vous avez dépecé {{ THE($victim) }} !
comp-kitchen-spike-butcher = { CAPITALIZE(THE($user)) } a dépecé { THE($victim) } !

comp-kitchen-spike-unhook-verb = Libérer

comp-kitchen-spike-hooked = [color=red]{ CAPITALIZE(THE($victim)) } est sur cette broche ![/color]

comp-kitchen-spike-meat-name = { $name } ({ $victim })

comp-kitchen-spike-victim-examine = [color=orange]{ CAPITALIZE(SUBJECT($target)) } semble plutôt maigre.[/color]
