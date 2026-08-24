# SPDX-License-Identifier: AGPL-3.0-or-later

book-text-atmos-distro = Le réseau de distribution, ou "distro" pour faire court, est le souffle vital de la station. Il est responsable du transport de l'air depuis les atmosphériques à travers toute la station.

        Les tuyaux pertinents sont souvent peints en bleu, mais un moyen sûr de les identifier consiste à utiliser un scanner t-ray pour suivre quels tuyaux sont connectés aux ventilations actives de la station.

        Le mélange de gaz standard du réseau de distribution est de 20 degrés celsius, 78% d'azote (N2), 22% d'oxygène (O2). Vous pouvez le vérifier en utilisant un analyseur de gaz sur un tuyau de distro ou sur toute ventilation connectée à celui-ci. Des circonstances particulières peuvent nécessiter des mélanges spéciaux.

        Lorsqu'il s'agit de décider de la pression du distro, il y a quelques éléments à prendre en compte. Les ventilations actives régulent la pression de la station, donc tant que tout fonctionne correctement, il n'y a pas de pression de distro trop élevée.

        Une pression de distro plus élevée permettra au réseau de distro de servir de tampon entre les mineurs de gaz et les ventilations, offrant une quantité importante d'air supplémentaire pouvant être utilisée pour re-pressuriser la station après une brèche.

        Une pression de distro plus faible réduira la quantité de gaz perdue en cas de brèche du distro, un moyen rapide de gérer la contamination du distro. Cela peut également aider à ralentir ou à prévenir la sur-pressurisation de la station en cas de problèmes avec les ventilations.

        Les pressions de distro courantes se situent dans l'intervalle de 300-375 kPa, mais d'autres pressions peuvent être utilisées avec une connaissance des risques et des avantages.

        La pression du réseau est déterminée par la dernière pompe qui pompe dedans. Pour éviter les goulots d'étranglement, toutes les autres pompes entre les mineurs et la dernière pompe doivent être réglées à leur débit maximal, et tout dispositif inutile doit être supprimé.

        Vous pouvez vérifier la pression du distro à l'aide d'un analyseur de gaz, mais gardez à l'esprit que la demande élevée à cause des choses comme les brèches peut faire que la pression du distro soit inférieure à la pression cible pendant de longues périodes. Ainsi, si vous observez une baisse de pression, ne paniquez pas - ça pourrait être temporaire.

book-text-atmos-waste = Le réseau de déchets est le système principalement responsable de garder l'air sur la station libre de contaminants.

        Vous pouvez identifier les tuyaux pertinents grâce à leur couleur rouge ou en utilisant un scanner t-ray pour suivre quels tuyaux sont connectés aux épurateurs sur la station.

        Le réseau de déchets sert à transporter les gaz résiduels vers un traitement ou l'espace. Il est idéal de maintenir la pression à 0 kPa, mais elle peut parfois être à une pression non nulle faible pendant son utilisation.

        Les techniciens ont la possibilité de filtrer les gaz résiduels ou de les envoyer dans l'espace. Bien que l'espacement soit plus rapide, le filtrage permet de réutiliser les gaz pour le recyclage ou la vente.

        Le réseau de déchets peut également servir à diagnostiquer des problèmes atmosphériques sur la station. Des niveaux élevés de gaz résiduel peuvent suggérer une fuite importante, tandis que la présence de gaz non résiduels peut indiquer un problème de configuration ou de connexion physique des épurateurs. Si les gaz sont à haute température, cela pourrait indiquer un incendie.

book-text-atmos-alarms = Les alarmes à air sont situées partout dans les stations pour permettre la gestion et la surveillance de l'atmosphère locale.

            L'interface des alarmes à air fournit aux techniciens une liste des capteurs connectés, leurs lectures, et la possibilité d'ajuster les seuils. Ces seuils sont utilisés pour déterminer l'état d'alarme de l'alarme à air. Les techniciens peuvent également utiliser l'interface pour définir des pressions cibles pour les ventilations et configurer les vitesses de fonctionnement et les gaz cibles pour les épurateurs.

            Alors que l'interface permet un réglage précis des appareils contrôlés par l'alarme à air, il existe également plusieurs modes disponibles pour une configuration rapide de l'alarme. Ces modes sont automatiquement activés lorsque l'état de l'alarme change :
            - Filtrage : Le mode par défaut
            - Filtrage (large) : Un mode de filtrage qui modifie le fonctionnement des épurateurs pour nettoyer une zone plus large
            - Remplissage : Désactive les épurateurs et règle les ventilations sur leur pression maximale
            - Panique : Désactive les ventilations et règle les épurateurs pour aspirer

            Un multitool ou un configurateur de réseau peut être utilisé pour connecter des appareils aux alarmes à air.

book-text-atmos-vents =
    Voici un guide de référence rapide pour plusieurs dispositifs atmosphériques :

                ventilations passives :
                Ces ventilations ne nécessitent pas d'alimentation, elles permettent aux gaz de circuler librement dans les deux directions dans le réseau de tuyaux auquel elles sont connectés.

                ventilations actives :
                Ce sont les ventilations les plus courantes sur la station. Elles disposent d'une pompe interne et nécessitent du courant. Par défaut, elles ne pompent les gaz que hors des tuyaux, et uniquement jusqu'à 101 kPa. Cependant, elles peuvent être reconfigurées à l'aide d'une alarme à air. elles se verrouillent également si la pièce est inférieure à 1 kPa, afin d'éviter de pomper du gaz dans l'espace.

                Épurateurs d'air :
                Ces appareils permettent de filtrer les gaz de l'atmosphère et de les placer dans le réseau de tuyaux connecté (généralement le réseau de déchets). Ils peuvent être configurés pour sélectionner des gaz spécifiques lorsqu'ils sont connectés à une alarme à air.

                Injecteurs d'air :
                Les injecteurs sont similaires aux ventilations actives, mais ils n'ont pas de pompe interne et ne nécessitent pas d'alimentation. Ils ne peuvent pas être configurés, mais ils peuvent continuer à pomper des gaz jusqu'à des pressions beaucoup plus élevées.
