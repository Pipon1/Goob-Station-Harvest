entity-effect-guidebook-modify-disgust =
    { $chance ->
        [1] { $deltasign ->
                [1] Augmente
                *[-1] Diminue
            }
       *[other]
            { $deltasign ->
                [1] augmente
                *[-1] diminue
            }
    } le niveau de dégoût de { $amount }