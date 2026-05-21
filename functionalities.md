# Functionalities
As mentioned in the main README, the features below are the functionalities I worked on throughout the project.

This way, the file does not become too extensive if I were to explain every feature.

## 🌍 Destinations
This module includes CRUD functionality for managing destinations that can be linked to group trips.

### Implemented features
- Overview of all destinations
- Create new destinations
- Edit destinations
- Delete destinations
- Success and validation alerts

### Used components
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

| Screenshot | Description |
|---|---|
| ![overview-destinations](screenshots-functionaliteiten/bestemmingen/overzicht-bestemmingen.png) | Overview of all destinations within the admin panel. |
| ![create-form-destination](screenshots-functionaliteiten/bestemmingen/create-bestemming.png) | Form for creating a new destination. |
| ![edit-form-destination](screenshots-functionaliteiten/bestemmingen/bestemming-edit.png) | Editing existing destinations. |
| ![delete-alert-destination](screenshots-functionaliteiten/bestemmingen/bestemming-delete.png) | Confirmation window for deleting destinations. |
| ![success-alert](screenshots-functionaliteiten/bestemmingen/alert-succes.png) | Success/validation alert that appears with every CRUD action. |

---

## 🥾 Activities
CRUD functionality for managing activities within the platform. Activities can be linked to trips and together form the program of a group trip.

### Implemented features
- Create activities
- View activities in overview
- Edit activities
- Delete activities
- Success and validation alerts

### Used components
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
| Screenshot | Description |
|---|---|
| ![create-activity](screenshots-functionaliteiten/activiteiten/aanmaken-activiteit.png) | Form for creating a new activity. |
| ![nieuwe-activity](screenshots-functionaliteiten/activiteiten/nieuwe-activiteit-in-lijst.png) | New activity that appears at the bottom of the list. |
| ![edit-activity-form](screenshots-functionaliteiten/activiteiten/edit-activiteit.png) | Editing existing activities. |
| ![delete-alert-activity](screenshots-functionaliteiten/activiteiten/delete-activiteit.png) | Confirmation window for deleting activities. |
| ![success-alert](screenshots-functionaliteiten/activiteiten/alert-succes.png) | Success/validation alert that appears with every CRUD action. |

---

## 🗃️ Dashboard
The dashboard provides users with an overview of their trips, organized into three categories: upcoming, ongoing, and completed trips.

The data is dynamically generated based on travel dates and registered participants.

### Implemented features
- Overview of upcoming trips
- Overview of ongoing trips
- Overview of completed trips
- Dynamic categorization based on dates
- Access to family management from the dashboard
- Option to post reviews after a trip has ended

### Used components
#### Controllers
- `DashboardController.cs`

#### ViewModels
- `DashboardViewModel.cs`

#### Views
- `Views/Dashboard/*`

### 📸 Screenshots
| Screenshot | Description |
|---|---|
| ![upcoming-trips](screenshots-functionaliteiten/dashboard/aankomende-groepsreizen.png) | Overview of the upcoming group trips. |
| ![current-trips](screenshots-functionaliteiten/dashboard/current-reizen.png) | Overview of the ongoing group trips. |
| ![past-trips](screenshots-functionaliteiten/dashboard/afgelopen-reizen.png) | Overview of completed group trips.  |

---

## ⭐ Reviews
Functionality to post, edit, and view reviews on group trips. Reviews are linked to a specific trip and user.

### Implemented features
- Post a review after a trip
- Edit your review
- Display review on a trip detail page
- Star rating + comment
- Instant update in the UI

### Used components
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
| Screenshot | Description |
|---|---|
| ![review-create](screenshots-functionaliteiten/review/review-create.png) | Post a review with stars and comments. Users can only post one review per trip. |
| ![review-edit](screenshots-functionaliteiten/review/review-edit.png) |  Edit existing review. |
| ![review-detailpage](screenshots-functionaliteiten/review/review-detailpage.png) |  Review visible on the trip detail page. When editing a review, it is automatically updated here. |

---

## 👩🏻‍🍼 Family members
Management of children linked to a parent account, including registrations for group trips.

### Implemented features
- Add children
- Edit children
- Delete children
- Register for trips
- Unregister from trips
- Manage medical info (allergies, medication)

### Used components
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
| Screenshot | Description |
|---|---|
| ![overview-of-children](screenshots-functionaliteiten/gezinsleden/overzicht-kinderen.png) | Overview of all children of a parent. |
| ![create-form-child](screenshots-functionaliteiten/gezinsleden/create-kind.png) |  Add new child with medical info. |
| ![new-child](screenshots-functionaliteiten/gezinsleden/nieuw-kind-overzicht.png) |  New child added at the bottom of the overview. |
| ![edit-form-child](screenshots-functionaliteiten/gezinsleden/edit-kind.png) | Edit details of an existing child, including medical information. |
| ![delete-alert-child](screenshots-functionaliteiten/gezinsleden/delete-kind.png) | Confirmation window for deleting children.|
| ![registered-child-trip-with-unregister](screenshots-functionaliteiten/gezinsleden/ingeschreven-kind.png) | Register/unregister a child for a trip. |