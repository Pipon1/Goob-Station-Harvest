## Survivor

roles-antag-survivor-name = Survivant
# It's a Halo reference
roles-antag-survivor-objective = Objectif actuel : Survivre

survivor-role-greeting =
    Vous êtes un survivant. Avant tout, vous devez retourner au commandement central vivant.
    Collectez autant de puissance de feu que nécessaire pour garantir votre survie.
    Ne faites confiance à personne.
survivor-round-end-dead-count =

{
    $deadCount ->
        [un] [color=red]{$deadCount}[/color] survivant est mort.
        *[d'autres] [color=red]{$deadCount}[/color] survivants sont morts.
}

survivor-round-end-alive-count =
{
    $aliveCount ->
        [un] [color=yellow]{$aliveCount}[/color] survivant a été abandonné sur la station.
        *[d'autres] [color=yellow]{$aliveCount}[/color] survivants ont été abandonnés sur la station.
}

survivor-round-end-alive-on-shuttle-count =
{
    $aliveCount ->
        [un] [color=green]{$aliveCount}[/color] survivant s'est échappé vivant.
        *[d'autres] [color=green]{$aliveCount}[/color] survivants se sont échappés vivants.
}

## Wizard
# Goob commented out.
#objective-issuer-swf = [color=turquoise]La Fédération des Sorciers de l'espace[/color]
#
#wizard-title = Sorcier
#wizard-description = Il y a un sorcier sur la station ! On ne sait jamais ce qu'il pourrait faire.
#
#roles-antag-wizard-name = Sorcier
#roles-antag-wizard-objective = Leur enseigner une leçon qu'ils n'oublieront jamais.
#
#wizard-role-greeting =
#    C'est l'heure de la magie, boule de feu !
#    Il y a eu des tensions entre la Fédération des Sorciers de l'espace et NanoTrasen. Vous avez été sélectionné par la Fédération des Sorciers de l'espace pour rendre visite à la station et les « rappeler » pourquoi les lanceurs de sorts ne doivent pas être pris à la légère.
#    Semez le chaos et la destruction ! Ce que vous ferez dépend de vous, mais rappelez-vous que la Fédération des Sorciers veut que vous sortiez vivant.
#
#wizard-round-end-name = sorcier

## TODO: Wizard Apprentice (Coming sometime post-wizard release)
