ore-silo-ui-title = Material Silo
ore-silo-ui-label-clients = Machines
ore-silo-ui-label-mats = Materials
ore-silo-ui-magnet-enabled = Magnet: Enabled
ore-silo-ui-magnet-disabled = Magnet: Disabled
ore-silo-ui-itemlist-entry = {$linked ->
    [true] {"[Linked] "}
    *[False] {""}
} {$name} ({$beacon}) {$inRange ->
    [true] {""}
    *[false] (Out of Range)
}
