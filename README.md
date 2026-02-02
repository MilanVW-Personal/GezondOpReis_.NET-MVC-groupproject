# Groepsproject .NET MVC - GezondOpReis
## Korte uitleg
Deze repository bevat alle code voor het groepsproject 'GezondOpReis' dat we voor het vak 'MVC Project' hebben moeten ontwikkelen. 
Met deze README wil ik een duidelijker beeld schetsen over hoe dit project juist in elkaar zit en aan welke features ik zelf heb gewerkt.

## Wat is dit project?
Dit project is een webapplicatie, die via het .NET framework is gemaakt, volgens ASP.NET, Entity Framework en het MVC principe. 
Voor dit project hebben we elk per week aan één of soms zelfs meerdere branches gewerkt.
We werkten met een feature-branch workflow, waarbij elke branch een specifieke (kern-)functionaliteit bevatte die voor de goede werking van de webapplicatie zorgt. 

Simpel gezegd is het een platform waar je reizen kunt boeken. Je kan op verschillende manieren deelnemen aan deze reizen. 
Bij elk van deze reizen horen ook activiteiten, die zelf dan uit een programma bestaan.
Je kunt als gewone reiziger meegaan, maar ook als ouder, monitor, (hoofd-)verantwoordelijke. 
Deelnemers hebben dan ook de mogelijkheid om bepaalde opleidingen te volgen.

Elk van deze rollen heeft een bepaalde verantwoordelijkheid. Een gebruiker van deze website kan zich bij het inschrijven als monitor opgeven. 
Als je je kind wil inschrijven voor een reis, dan kan je als ouder dit doen. 
Onkosten die tijdens de reis worden gemaakt, worden door de (hoofd-)verantwoordelijke op het systeem geüpload.
Bij elke gebruiker wordt er ook een medische fiche opgeslagen, die door de gebruiker zelf kan worden ingevuld of aangepast. 
De bedoeling hiervan is dat de verantwoordelijken de nodige medicijnen of remedies mee kunnen nemen op de reis. 
Tenslotte kan je per reis ook een review achterlaten, die dan bij die reis zullen worden getoond.

Elke pagina wordt opgebouwd aan de hand van Razor pages en bijhorende controllers. 
Alle data werd beheerd in een SQL Server database en ontsloten via Entity Framework Core.

## Waarom hebben we dit project gemaakt?
Zoals eerder gezegd, was dit een verplichte groepsopdracht die we moesten ontwikkelen om onze kennis van het MVC principe en Entity Framework te testen.

## Wanneer zijn we aan dit project begonnen?
We zijn dit project gestart op 13 november 2024 en hebben er aan gewerkt tot 20 december 2024, een paar dagen voor de uiterlijke deadline.
Deze was, als ik het me goed herinner, 22 december 2024, maar dit kan ook 20 december zelf geweest zijn.

## Hoe zijn we te werk gegaan?
We hebben aan dit project gewerkt volgens de Agile/Scrum methodiek.
We hadden het vak 3 keer per week, op maandag, woensdag en vrijdag. 

### Maandag
Op maandagen hebben we altijd eerst samengezeten om te bespreken wat er die week moest gebeuren en wie dit ging doen. 
Deze taken hebben we overzichtelijk verdeeld via GitHub Issues verdeeld, door de functionaliteiten telkens aan een van onze namen te hangen.
Al deze informatie werd altijd opgeschreven in een SPRINT-planning, waar elk groepslid elke keer afwisselend SCRUM-master was en de notities maakte. 
Deze moest aan het einde van elke week ook geüpload worden op ons leerplatform.

### Woensdag
Op woensdagen werd er eerst altijd overlopen wat ieder van ons al had gedaan en wat er nog moest gebeuren in de week. 
Daarnaast werd er daar ook genoteerd wat er goed/vlot ging en wat er minder goed/vlot ging. Nadien konden we verder werken aan de features die we maandag gestart waren.

### Vrijdag
Dan, op vrijdagen, moesten we ons werk van de afgelopen week allemaal samenvoegen / mergen met de `main` branch. 
Nadien konden we als groep ons werk voorstellen aan onze docent via een Teams-call, die telkens ook het werk beoordeelde.
De feedback die onze docent gaf, werd ook door de SCRUM-master genoteerd in de SPRINT-planning, waarna deze kon worden geüpload op het leerplatform.

Deze methodiek hebben we blijven toepassen tot op het einde van het project, waar, na het krijgen van de feedback, we moesten ingeven wat we tof vonden aan het project, wat er goed ging, wat er nog beter kon...
Nadat het project was ingediend hebben we tenslotte nog een evaluatie moeten invullen waarbij we telkens onszelf of elkaar beoordeelden, telkens door een punt op 5 te geven.

## Gebruikte technologieën
#### Backend
- .NET
- ASP.NET Core
- Entity Framework
- C#
- MVC
- SQL

#### Frontend
- Razor pages

#### Tools en methodologieën
- Agile/Scrum
- GitHub Issues
- Git (feature-branch workflow)


## Functionaliteiten
Ik gaf al eerder zijn dat dit project heel uitgebreid is. Om die reden ga ik enkel in het bestand [`functionaliteiten.md`](functionaliteiten.md) mijn gemaakte features uitleggen.

## English version
English-speaking visitors of this repository will be able to view the English version of this README via the file [`README_EN`](README_EN.md). 
That file also contains a link to the English version of the detailed `functionaliteiten.md` documentation.