# Groepsproject .NET MVC - GezondOpReis
.NET • ASP.NET Core • Entity Framework • MVC • SQL Server • Razor Pages

## 📌 Over dit project
Deze repository bevat de source code van het groepsproject **GezondOpReis**, ontwikkeld voor het vak *MVC Project*.

GezondOpReis is een webapplicatie waarmee gebruikers reizen kunnen boeken, beheren en opvolgen binnen verschillende rollen zoals reiziger, ouder, monitor en verantwoordelijke.

In deze README licht ik de architectuur, gebruikte technologieën, ontwikkelingsaanpak en mijn bijdrage aan het project toe.

---

## 🎯 Doel van het project
Het doel van dit project was om onze kennis van:
- het MVC-principe
- ASP.NET Core
- Entity Framework Core
- relationele databanken
- en Agile/Scrum teamwork

in de praktijk toe te passen binnen een grotere groepsapplicatie.

---

## 🧠 Wat is GezondOpReis?
GezondOpReis is een platform waarop gebruikers reizen kunnen boeken en beheren.

Binnen het platform bestaan verschillende gebruikersrollen:
- reiziger
- ouder
- monitor
- verantwoordelijke
- hoofdverantwoordelijke

Elke rol beschikt over specifieke functionaliteiten en verantwoordelijkheden.

### Voorbeelden van functionaliteiten
- Reizen en activiteiten bekijken
- Kinderen inschrijven voor reizen
- Opleidingen volgen
- Reviews achterlaten per reis
- Medische fiches beheren
- Onkosten uploaden tijdens reizen
- Activiteiten en programma's beheren

De applicatie werd opgebouwd volgens het MVC-principe met ASP.NET Core en Entity Framework Core.

Alle data werd beheerd in een SQL Server database.

---

## 🚧 Architectuur
De applicatie is opgebouwd volgens het MVC-patroon:

- **Models**: beheren de data en database-relaties
- **Views**: opgebouwd met Razor Pages
- **Controllers**: behandelen logica en gebruikersacties

Entity Framework Core werd gebruikt als ORM-laag voor communicatie met de SQL Server database.

Daarnaast werd gewerkt met een feature-branch workflow, waarbij elke feature afzonderlijk werd ontwikkeld en later gemerged naar de main branch.

---

## 🔄️ Werkwijze
Tijdens het project werkten we volgens de Agile/Scrum methodologie.

We hadden meerdere overlegmomenten per week waarbij:
- nieuwe functionaliteiten werden besproken
- taken verdeeld werden via GitHub Issues
- sprintplanningen werden opgesteld
- feedbackmomenten plaatsvonden met de docent

Elke week werden features ontwikkeld binnen aparte branches en vervolgens gemerged naar de main branch.

Daarnaast presenteerden we regelmatig onze voortgang via Teams-meetings.

---

## 👨🏻‍💻 Mijn bijdrage
Dit project werd ontwikkeld in groep. Omdat de applicatie erg uitgebreid is, heb ik mijn persoonlijke bijdragen en gemaakte functionaliteiten apart gedocumenteerd in
[`functionaliteiten.md`](functionaliteiten.md)

---

## 🕒 Ontwikkelingsperiode
Dit project werd ontwikkeld tussen:
- **13 november 2024**
- **20 december 2024**

---

## 🛠️ Technologieën
#### Backend
- .NET
- ASP.NET Core
- Entity Framework
- C#
- MVC
- SQL Server

#### Frontend
- Razor Pages
- HTML
- CSS
- JavaScript

#### Tools en methodologieën
- GitHub Issues
- Git & GitHub
- Feature-branch workflow
- Agile/Scrum

---

## ⚙ Installatie & setup

```bash
# Clone the repository
git clone <repository-url>

cd GezondOpReis

# Restore dependencies and run the project
dotnet restore
dotnet build
dotnet run
```

### Vereisten
- .NET SDK
- SQL Server
- Visual Studio / Rider / VS Code

--- 

## 🌐 English version
English-speaking visitors can read the translated version of this README via [`README_EN`](README_EN.md). 
The English version also contains a link to the translated `functionaliteiten.md` documentation.