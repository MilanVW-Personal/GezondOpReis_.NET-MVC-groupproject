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



### 📸 Screenshots

| Screenshot | Beschrijving |
|---|---|
| ![overzicht-bestemmingen](screenshots-functionaliteiten/bestemmingen/overzicht-bestemmingen.png) | Overzicht van alle bestemmingen binnen het beheerpaneel. |
| ![create-form-bestemming](screenshots-functionaliteiten/bestemmingen/create-bestemming.png) | Formulier voor het aanmaken van een nieuwe bestemming. |
| ![edit-form-bestemming](screenshots-functionaliteiten/bestemmingen/bestemming-edit.png) | Bewerken van bestaande bestemmingen. |
| ![delete-alert-bestemming](screenshots-functionaliteiten/bestemmingen/bestemming-delete.png) | Bevestigingsvenster voor het verwijderen van bestemmingen. |
| ![success-alert](screenshots-functionaliteiten/bestemmingen/alert-succes.png) | Success/validatie alert die verschijnt bij elke CRUD actie. |

---

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


### 📸 Screenshots
| Screenshot | Beschrijving |
|---|---|
| ![create-activiteit](screenshots-functionaliteiten/activiteiten/aanmaken-activiteit.png) | Formulier voor het aanmaken van een nieuwe activiteit. |
| ![nieuwe-activiteit](screenshots-functionaliteiten/activiteiten/nieuwe-activiteit-in-lijst.png) | Nieuwe activiteit die onderaan de lijst verschijnt. |
| ![edit-activiteit-form](screenshots-functionaliteiten/activiteiten/edit-activiteit.png) | Bewerken van bestaande activiteiten. |
| ![delete-alert-activiteit](screenshots-functionaliteiten/activiteiten/delete-activiteit.png) | Bevestigingsvenster voor het verwijderen van activiteiten. |
| ![success-alert](screenshots-functionaliteiten/activiteiten/alert-succes.png) | Success/validatie alert die verschijnt bij elke CRUD actie. |

---

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

### 📸 Screenshots
| Screenshot | Beschrijving |
|---|---|
| ![upcoming-trips](screenshots-functionaliteiten/dashboard/aankomende-groepsreizen.png) | Overzicht van de aankomende groepsreizen. |
| ![current-trips](screenshots-functionaliteiten/dashboard/current-reizen.png) |  Overzicht van de lopende groepsreizen. |
| ![past-trips](screenshots-functionaliteiten/dashboard/afgelopen-reizen.png) |  Overzicht van de afgelopen groepsreizen. |

---

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

### 📸 Screenshots
| Screenshot | Beschrijving |
|---|---|
| ![review-create](screenshots-functionaliteiten/review/review-create.png) | Review plaatsen met sterren en commentaar. Dit kan maar 1x per gebruiker. |
| ![review-edit](screenshots-functionaliteiten/review/review-edit.png) |  Bestaande review bewerken. |
| ![review-detailpage](screenshots-functionaliteiten/review/review-detailpage.png) |  Review zichtbaar op detailpagina van de reis. Bij bewerken van een review, wordt het hier automatisch geüpdatet. |

---

## 👩🏻‍🍼 Gezinsleden
Beheer van kinderen binnen een ouder-account, inclusief inschrijvingen op groepsreizen.

### Functionaliteiten
- Kinderen toevoegen
- Kinderen bewerken
- Kinderen verwijderen
- Inschrijven op reizen
- Uitschrijven van reizen
- Medische info beheren (allergieën, medicatie)

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

### 📸 Screenshots
| Screenshot | Beschrijving |
|---|---|
| ![overzicht-van-kinderen](screenshots-functionaliteiten/gezinsleden/overzicht-kinderen.png) | Overzicht van alle kinderen van een ouder. |
| ![create-form-kind](screenshots-functionaliteiten/gezinsleden/create-kind.png) |  Nieuw kind toevoegen met medische info. |
| ![nieuw-kind](screenshots-functionaliteiten/gezinsleden/nieuw-kind-overzicht.png) |  Nieuw kind onderaan toegevoegd in overzicht. |
| ![edit-form-kind](screenshots-functionaliteiten/gezinsleden/edit-kind.png) | Gegevens van een bestaand kind aanpassen, inclusief medische info. |
| ![delete-alert-kind](screenshots-functionaliteiten/gezinsleden/delete-kind.png) | Bevestigingsvenster voor het verwijderen van een kind.|
| ![ingeschreven-kind-reis-met-uitschrijven](screenshots-functionaliteiten/gezinsleden/ingeschreven-kind.png) | Kind inschrijven/uitschrijven voor een reis. |