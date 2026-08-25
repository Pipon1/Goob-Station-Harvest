# templates
# service
ntr-document-service-starting-text1 = [color=#009100]█▄ █ ▀█▀    [head=3]Document NanoTrasen[/head]
    █ ▀█     █        À : Département Service
                           De : CentCom
                           Émis : {$date}
    ──────────────────────────────────────────[/color]

# security
ntr-document-security-starting-text1 = [head=3]Document NanoTrasen[/head]                               [color=#990909]█▄ █ ▀█▀
    À : Département Sécurité                                       █ ▀█     █
    De : CentCom
    Émis : {$date}
    ──────────────────────────────────────────[/color]

# cargo
ntr-document-cargo-starting-text1 = [head=3]  NanoTrasen[/head]        [color=#d48311]█▄ █ ▀█▀ [/color][bold]      À : Département Cargo[/bold][head=3]
       Document[/head]           [color=#d48311]█ ▀█     █       [/color] [bold]   De : CentCom[/bold]
    ──────────────────────────────────────────
                                        Émis : {$date}

# medical
ntr-document-medical-starting-text1 = [color=#118fd4]░             █▄ █ ▀█▀    [head=3]Document NanoTrasen[/head]                 ░
    █             █ ▀█     █        À : Département Médical                         █
    ░                                    De : CentCom                                     ░
                                         Émis : {$date}
    ──────────────────────────────────────────[/color]

# engineering
ntr-document-engineering-starting-text1 = [color=#a15000]█▄ █ ▀█▀    [head=3]Document NanoTrasen[/head]
    █ ▀█     █        À : Département Ingénierie
                           De : CentCom
                           Émis : {$date}
    ──────────────────────────────────────────[/color]

# science
ntr-document-science-starting-text1 = [color=#94196f]░             █▄ █ ▀█▀    [head=3]Document NanoTrasen[/head]                 ░
    █             █ ▀█     █        À : Département Science                         █
    ░                                    De : CentCom                                     ░
                                         Émis : {$date}
    ──────────────────────────────────────────[/color]
ntr-document-service-document-text =
    {$start}
    La direction veut que vous sachiez que vous n'êtes pas {$text1} {$text2}
    La direction serait ravie si vous {$text3}
    Les tampons ci-dessous confirment que {$text4}

ntr-document-security-document-text =
    {$start}
    La direction veut que vous vérifiiez certaines choses avant de tamponner ce document, assurez-vous que {$text1} {$text2}
    {$text3}
    {$text4}

ntr-document-cargo-document-text =
    {$start}
    {$text1}
    {$text2}
    En tamponnant ici, vous {$text3}

ntr-document-medical-document-text =
    {$start}
    {$text1} {$text2}
    {$text3}
    En tamponnant ici, vous {$text4}

ntr-document-engineering-document-text =
    {$start}
    {$text1} {$text2}
    {$text3}
    En tamponnant ici, vous {$text4}

ntr-document-science-document-text =
    {$start}
    Nous avons surveillé de près le Département Recherche. {$text1} {$text2}
    vu tout ce qui précède, nous voulons que vous assuriez {$text3}
    les tampons ci-dessous confirment {$text4}