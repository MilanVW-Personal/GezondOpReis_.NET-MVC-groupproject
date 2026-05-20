# Functionaliteiten
Zoals ik al aangaf in de algemene README, zullen deze functionaliteiten diegene zijn waaraan ik gewerkt heb gedurende het hele project. 
Zo wordt het bestand niet te uitgebreid als ik elke functionaliteit zou uitleggen.

## 🌍 Bestemmingen
Deze module bevat CRUD-functionaliteit voor het beheren van bestemmingen die gekoppeld kunnen worden aan groepsreizen.

### Functionaliteiten
- Overzicht van alle bestemmingen
- Nieuwe bestemmingen aanmaken
- Bestemmingen bewerken
- Bestemmingen verwijderen
- Success- en validatiealerts

### Gebruikte componenten
#### Configuration
- `MapperProfile.cs`

#### Controllers
- `BestemmingController.cs`

#### Repository (Data/Repo)
- `BestemmingRepo.cs`
- `IBestemmingRepo.cs`

#### Models
- `Bestemming.cs`

#### ViewModels
- `BestemmingViewModel.cs`
- `BestemmingEditViewModel.cs`
- `BestemmingDeleteViewModel.cs`

#### Views
- `Views/Bestemming/*`

---

### Screenshots

| Screenshot | Beschrijving |
|---|---|
| ![](screenshots-functionaliteiten/bestemmingen/overzicht-bestemmingen.png) | Overzicht van alle bestemmingen binnen het beheerpaneel. |
| ![](screenshots-functionaliteiten/bestemmingen/create-bestemming.png) | Formulier voor het aanmaken van een nieuwe bestemming. |
| ![](screenshots-functionaliteiten/bestemmingen/bestemming-edit.png) | Bewerken van bestaande bestemmingen. |
| ![](screenshots-functionaliteiten/bestemmingen/bestemming-delete.png) | Confirmatiemodal voor het verwijderen van bestemmingen. |
| ![](screenshots-functionaliteiten/bestemmingen/alert-succes.png) | Success/validatie alert die verschijnt bij elke CRUD actie. |



## 🥾 Activiteiten
CRUD-functionaliteit voor het beheren van activiteiten binnen het platform. Activiteiten kunnen gekoppeld worden aan reizen en vormen samen het programma van een groepsreis.

### Functionaliteiten
- Activiteiten aanmaken
- Activiteiten bekijken in overzicht
- Activiteiten bewerken
- Activiteiten verwijderen
- Success- en validatiealerts

### Gebruikte componenten
#### Configuration
- `MapperProfile.cs`

#### Controllers
- `ActiviteitenController.cs`

#### Repository (Data/Repo)
- `ActiviteitenRepo.cs`
- `IActiviteitenRepo.cs`

#### Models
- `Activiteit.cs`

#### ViewModels
- `ActiviteitViewModel.cs`
- `ActiviteitEditViewModel.cs`
- `ActiviteitDeleteViewModel.cs`

#### Views
- `Views/Activiteit/*`

---

### Screenshots
| Screenshot | Beschrijving |
|---|---|
| ![](screenshots-functionaliteiten/activiteiten/aanmaken-activiteit.png) | Formulier voor het aanmaken van een nieuwe activiteit. |
| ![](screenshots-functionaliteiten/activiteiten/nieuwe-activiteit-in-lijst.png) | Nieuwe activiteit die onderaan de lijst verschijnt. |
| ![](screenshots-functionaliteiten/activiteiten/edit-activiteit.png) | Bewerken van bestaande activiteiten. |
| ![](screenshots-functionaliteiten/activiteiten/delete-activiteit.png) | Confirmatiemodal voor het verwijderen van activiteiten. |
| ![](screenshots-functionaliteiten/activiteiten/alert-succes.png) | Success/validatie alert die verschijnt bij elke CRUD actie. |


## 🗃️ Dashboard
Het dashboard geeft gebruikers een overzicht van hun reizen, ingedeeld in drie categorieën: aankomende, lopende en afgelopen reizen.

De data wordt dynamisch opgebouwd op basis van de reisdatums en ingeschreven deelnemers.

### Functionaliteiten
- Overzicht van aankomende reizen
- Overzicht van lopende reizen
- Overzicht van afgelopen reizen
- Dynamische categorisatie op basis van datums
- Toegang tot gezinsbeheer vanuit dashboard
- Mogelijkheid om reviews te plaatsen na afloop van een reis

### Gebruikte componenten
#### Controllers
- `DashboardController.cs`

#### ViewModels
- `DashboardViewModel.cs`

#### Views
- `Views/Dashboard`

---

### Screenshots
| Screenshot | Beschrijving |
|---|---|
| ![](screenshots-functionaliteiten/dashboard/aankomende-groepsreizen.png) | Overzicht van de aankomende groepsreizen. |
| ![](screenshots-functionaliteiten/dashboard/current-reizen.png) |  Overzicht van de lopende groepsreizen. |
| ![](screenshots-functionaliteiten/dashboard/afgelopen-reizen.png) |  Overzicht van de afgelopen groepsreizen. |


## ⭐ Reviews
Functionaliteit om reviews te plaatsen, bewerken en weergeven op groepsreizen. Reviews worden gekoppeld aan een specifieke reis en gebruiker.

### Functionaliteiten
- Review plaatsen na afloop van een reis
- Review bewerken
- Review tonen op detailpagina van een reis
- Sterrenscore + commentaar
- Directe update in de UI

### Gebruikte componenten
#### Configuration
- `MapperProfile.cs`

#### Controllers
- `ReviewController.cs`

#### Repository (Data/Repo)
- `ReviewRepo.cs`
- `IReviewRepo.cs`

#### Models
- `Review.cs`

#### ViewModels
- `ReviewViewModel.cs`
- `ReviewCreateViewModel.cs`
- `ReviewEditViewModel.cs`

#### Views
- `Views/Review/*`

### Screenshots
| Screenshot | Beschrijving |
|---|---|
| ![](screenshots-functionaliteiten/review/review-create.png) | Review plaatsen met sterren en commentaar. Dit kan maar 1x per gebruiker. |
| ![](screenshots-functionaliteiten/review/review-edit.png) |  Bestaande review bewerken. |
| ![](screenshots-functionaliteiten/review/review-detailpage.png) |  Review zichtbaar op detailpagina van de reis. Bij bewerken van een review, wordt het hier automatisch geüpdatet. |

---

## 👩🏻‍🍼 Gezinsleden
Beheer van kinderen binnen een ouder-account, inclusief inschrijvingen op groepsreizen.

### Functionaliteiten
- Kinderen toevoegen
- Kinderen bewerken
- Kinderen verwijderen
- Inschrijven op reizen
- Uitschrijven van reizen
- Medische info beheren (allergie)

### Gebruikte componenten
#### Configuration
- `MapperProfile.cs`

#### Controllers
- `KindController.cs`

#### Repository (Data/Repo)
- `KindRepository.cs`
- `IKindRepository.cs`

#### Models
- `Kind.cs`
- `Deelnemer.cs`
- `CustomUser.cs`

#### ViewModels
- `DeelnemerDetailsViewModel.cs`
- `KindViewModel.cs`
- `KindEditViewModel.cs` 
- `KindCreateViewModel.cs`
- `KindDeleteViewModel.cs`
- `GroepsreisInfoViewModel.cs`

#### Views
- `Kind`
- `GroepsReis/ReisInfo.cshtml`

<table>
  <thead>
      <tr>
        <td style="text-align: center;"><b>Screenshot</b></td>
        <td style="text-align: center;"><b>Uitleg</b></td>
      </tr>
  </thead>
  <tr>
    <td width="500">
      <a href="screenshots-functionaliteiten/gezinsleden/overzicht-kinderen.png">
        <img src="screenshots-functionaliteiten/gezinsleden/overzicht-kinderen.png" width="500" alt="overzicht-kinderen">
      </a>
    </td>
    <td style="padding-block: 15px;">
       Als je als ouder bent ingelogd en je drukt op de 'Gezinsleden beheren' knop, dan kom je op dit scherm terecht. Hier zie je een overzicht van alle kinderen die je hebt toegevoegd. Voor een nieuw kind toe te voegen aan de lijst, druk je op de '+' rechtsbovenaan.
    </td>
  </tr>
  <tr>
   <td width="500">
      <a href="screenshots-functionaliteiten/gezinsleden/create-kind.png">
        <img src="screenshots-functionaliteiten/gezinsleden/create-kind.png" width="500" alt="create-kind">
      </a>
    </td>
    <td style="padding-block: 15px;">
       Als je op de '+' knop drukt, kom je op dit scherm terecht, waar je een kind kunt toevoegen. Als je kind geen allergieën of medicijnen zou hebben, dan kun je deze perfect leeg laten, want deze worden automatisch met 'Geen' opgevuld bij het aanmaken. Hier kun je ook de rechtse knop gebruiken om terug te gaan naar het overzicht van kinderen. Om je kind toe te voegen, druk je op de linkse knop 'Kind toevoegen'.
    </td>
  </tr>
  <tr>
    <td width="500">
      <a href="screenshots-functionaliteiten/gezinsleden/nieuw-kind-overzicht.png">
        <img src="screenshots-functionaliteiten/gezinsleden/nieuw-kind-overzicht.png" width="500" alt="nieuw-kind-overzicht">
      </a>
    </td>
    <td style="padding-block: 15px;">
       Als alles goed verlopen is, zal je na een druk op de submit-knop, terug op dit scherm terechtkomen, deze keer met het nieuwe kind onderaan de lijst toegevoegd. Je krijgt ook een alert te zien die aangeeft dat de actie goed gelukt is.
    </td>
  </tr>
  <tr>
    <td width="500">
      <a href="screenshots-functionaliteiten/gezinsleden/edit-kind.png">
        <img src="screenshots-functionaliteiten/gezinsleden/edit-kind.png" width="500" alt="edit-kind">
      </a>
    </td>
    <td style="padding-block: 15px;">
      Mocht je bepaalde gegevens van je kind willen aanpassen, dan druk je op het 'pennetje', waarna je op dit scherm wijzigingen kunt aanbrengen. Als je toch medicijnen of een allergie zou willen toevoegen, verander je dit gewoon in het tekstveld. De 'Geen' wordt enkel opgevuld als er niets in het veld wordt ingevuld. Om je wijzigingen door te voeren, druk je op de groene knop. Dit brengt je terug naar het overzicht, met opnieuw een alert die aangeeft dat de actie goed verlopen is. De wijzigingen zijn dan ook al zichtbaar in de lijst. De gele knop, is, nogmaals, de knop om terug te keren naar het overzicht, moest je toch geen wijzigingen willen aanbrengen.
    </td>
  </tr>
  <tr>
    <td width="500">
      <a href="screenshots-functionaliteiten/gezinsleden/delete-kind.png">
        <img src="screenshots-functionaliteiten/gezinsleden/delete-kind.png" width="500" alt="delete-kind">
      </a>
    </td>
    <td style="padding-block: 15px;">
      Zoals alle delete acties, krijg je hier een confirmatie of je al dan niet het geselecteerde kind wilt verwijderen. Om een kind te verwijderen druk je hier, zoals bij de andere acties, op het vuilbakje. Een druk op de 'Delete' knop zal het kind uit de lijst verwijderen. De 'Terug naar overzicht' knop zal je hier ook naar het overzicht terugbrengen.
    </td>
  </tr>
  <tr>
    <td width="500">
      <a href="screenshots-functionaliteiten/gezinsleden/ingeschreven-kind.png">
        <img src="screenshots-functionaliteiten/gezinsleden/ingeschreven-kind.png" width="500" alt="ingeschreven-kind-detailpagina">
      </a>
    </td>
    <td style="padding-block: 15px;">
      Als je kinderen hebt toegevoegd en deze graag wilt inschrijven voor een reis, dan kan je dat doen via de detailpagina van een groepsreis, die je kunt bereiken door op de 'Meer informatie' knop te drukken op de homepage, waar alle actieve en aankomende reizen worden getoond. Door op de gele knop 'Kind inschrijven' te drukken, zal je een pop-up krijgen. In deze pop-up kan je kiezen welk kind je graag wilt inschrijven en eventuele opmerkingen kunt meegeven. Als je daar op de submit-knop zou drukken, dan zal het kind op deze manier getoond worden. Indien je je kind wilt uitschrijven, druk dan op de rode knop 'Uitschrijven'. Hier krijg je een pop-up confirmatie. Afhankelijk van je antwoord hierop, zal je kind van de reis uitgeschreven worden en uit de lijst verwijderd worden.
    </td>
  </tr>
</table>