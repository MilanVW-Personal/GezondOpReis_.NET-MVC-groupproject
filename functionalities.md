# Functionalities
As I mentioned in the general README, these features will be those I worked on throughout the project.
This way, the file wouldn't be too long if I were to explain every feature.

## Destinations ('Bestemmingen')
All code for the functionalities below can be found in the files in the directories below.

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
- `Bestemming`

<table>
 <thead>
      <tr>
        <td style="text-align: center;"><b>Screenshot</b></td>
        <td style="text-align: center;"><b>Explanation</b></td>
      </tr>
  </thead>
  <tr>
    <td width="500">
      <a href="screenshots-functionaliteiten/bestemmingen/overzicht-bestemmingen.png">
        <img src="screenshots-functionaliteiten/bestemmingen/overzicht-bestemmingen.png" width="500" alt="overview-destinations">
      </a>
    </td>
    <td style="padding-block: 15px;">
        If you're logged in as an admin, you can manage destinations that can be linked to a trip. This screen displays an overview of all existing destinations, whether or not they're already linked to a trip. To add a destination, click the "+" button in the top right corner.
    </td>
  </tr>
  <tr>
    <td width="500">
      <a href="screenshots-functionaliteiten/bestemmingen/create-bestemming.png">
        <img src="screenshots-functionaliteiten/bestemmingen/create-bestemming.png" width="500" alt="create-destination">
      </a>
    </td>
    <td style="padding-block: 15px;">
        After pressing the "+" button, you'll arrive at this screen where you can create a destination by filling in the fields. When you're done, press the "Bestemming aanmaken" button on the left. If you decide not to add it, press the "Terug naar overzicht" button on the right. This, as the name suggests, takes you back to the overview of all destinations.
    </td>
  </tr>
  <tr>
    <td width="500">
      <a href="screenshots-functionaliteiten/bestemmingen/alert-succes.png">
        <img src="screenshots-functionaliteiten/bestemmingen/alert-succes.png" width="500" alt="create-destination-success">
      </a>
    </td>
    <td style="padding-block: 15px;">
        After adding the destination, if everything went well, you'll see this alert at the top. The new destination has been successfully added.
    </td>
  </tr>
  <tr>
    <td width="500">
      <a href="screenshots-functionaliteiten/bestemmingen/nieuwe-bestemming.png">
        <img src="screenshots-functionaliteiten/bestemmingen/nieuwe-bestemming.png" width="500" alt="new-destination-in-list">
      </a>
    </td>
    <td style="padding-block: 15px;">
        If you then scroll down, you will indeed see the new destination in the list.
    </td>
  </tr>
  <tr>
    <td width="500">
      <a href="screenshots-functionaliteiten/bestemmingen/bestemming-edit.png">
        <img src="screenshots-functionaliteiten/bestemmingen/bestemming-edit.png" width="500" alt="edit-destination">
      </a>
    </td>
    <td style="padding-block: 15px;">
        Besides adding new destinations, you can also edit them by clicking the "pencil" icon. Here you can change the name and description if desired. If you then click the green button labeled "Bestemming wijzigen", all changes will be implemented. You'll then see another alert, this time notifying you that the changes have been applied. If you don't want to change anything, you can always click the yellow button labeled "Terug naar overzicht".
    </td>
  </tr>
  <tr>
    <td width="500">
      <a href="screenshots-functionaliteiten/bestemmingen/bestemming-delete.png">
        <img src="screenshots-functionaliteiten/bestemmingen/bestemming-delete.png" width="500" alt="delete-destination">
      </a>
    </td>
    <td style="padding-block: 15px;">
        Finally, you can also delete certain destinations. You can do this by clicking the trash can icon. You'll then receive a confirmation message. If you were to click the "Delete" button on the left, it would be removed from the database. You'll also receive a success alert. The "Terug naar overzicht" button on the right is also available if you decide not to delete the selected destination.
    </td>
  </tr>
</table>


## Activities ('Activiteiten')
All code for the functionalities below can be found in the files in the directories below.

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
- `ActiviteitViewModel.cs`, 
- `ActiviteitEditViewModel.cs`, 
- `ActiviteitDeleteViewModel.cs`

#### Views
- `Activiteit`

<table>
  <thead>
      <tr>
        <td style="text-align: center;"><b>Screenshot</b></td>
        <td style="text-align: center;"><b>Explanation</b></td>
      </tr>
  </thead>
  <tr>
    <td width="500">
      <a href="screenshots-functionaliteiten/activiteiten/aanmaken-activiteit.png">
        <img src="screenshots-functionaliteiten/activiteiten/aanmaken-activiteit.png" width="500" alt="create-activity">
      </a>
    </td>
    <td style="padding-block: 15px;">
        If you're logged in as an admin, you can add a new activity, just like with destinations, by clicking the "+" on the overview page.
        The activity overview page is similar to that of the destinations.
        Here, you can enter a name for the activity along with a description.
        Just like with destinations, once you've entered these, click the left button labeled "Activiteit aanmaken", which will take you back to the overview of all activities. The right button, "Terug naar overzicht", does the same thing.
    </td>
  </tr>
  <tr>
    <td width="500">
      <a href="screenshots-functionaliteiten/activiteiten/alert-succes.png">
        <img src="screenshots-functionaliteiten/activiteiten/alert-succes.png" width="500" alt="create-activity-success">
      </a>
    </td>
    <td style="padding-block: 15px;">
         After adding the activity, if everything went well, you'll see this alert at the top. The new activity has been successfully added.
         The same confirmation logic is used here as with the destinations.
    </td>
  </tr>
  <tr>
    <td width="500">
      <a href="screenshots-functionaliteiten/activiteiten/nieuwe-activiteit-in-lijst.png">
        <img src="screenshots-functionaliteiten/activiteiten/nieuwe-activiteit-in-lijst.png" width="500" alt="new-activity-in-list">
      </a>
    </td>
    <td style="padding-block: 15px;">
        If you scroll down, you'll indeed see the new activity in the list.
        This is exactly the same as with the destinations.
    </td>
  </tr>
  <tr>
    <td width="500">
      <a href="screenshots-functionaliteiten/activiteiten/edit-activiteit.png">
        <img src="screenshots-functionaliteiten/activiteiten/edit-activiteit.png" width="500" alt="edit-activity">
      </a>
    </td>
    <td style="padding-block: 15px;">
        Besides adding new activities, you can also edit them by clicking the "pencil" icon. Here, you can change the name and description if desired. If you then click the green button labeled "Activiteit wijzigen", all changes will be implemented. You'll then see another alert, this time notifying you that the changes have been applied. If you don't want to change anything, you can always click the yellow button labeled "Terug naar overzicht".
        This functionality follows the same pattern as for destinations.
    </td>
  </tr>
  <tr>
    <td width="500">
      <a href="screenshots-functionaliteiten/activiteiten/delete-activiteit.png">
        <img src="screenshots-functionaliteiten/activiteiten/delete-activiteit.png" width="500" alt="delete-activity">
      </a>
    </td>
    <td style="padding-block: 15px;">
        You can also delete certain activities. You can do this by clicking the trash can icon. You'll then receive a confirmation message. If you click the "Verwijderen" button on the left, it will be removed from the database. You'll then receive a success alert. The "Terug naar overzicht" button on the right is also available if you decide not to delete the selected activity.
        The logic here is the same as for the destinations.
    </td>
  </tr>
</table>


## Dashboard
All code for the functionalities below can be found in the files in the directories below.

#### Controllers
- `DashboardController.cs`

#### ViewModels
- `DashboardViewModel.cs`

#### Views
- `Views/Dashboard`

<table>
   <thead>
      <tr>
        <td style="text-align: center;"><b>Screenshot</b></td>
        <td style="text-align: center;"><b>Explanation</b></td>
      </tr>
  </thead>
  <tr>
    <td width="500">
      <a href="screenshots-functionaliteiten/dashboard/aankomende-groepsreizen.png">
        <img src="screenshots-functionaliteiten/dashboard/aankomende-groepsreizen.png" width="500" alt="upcoming-trips">
      </a>
    </td>
    <td style="padding-block: 15px;">
        Once logged in, you can view your dashboard by clicking the logo in the top left corner. Your dashboard is divided into three sections: upcoming trips, current trips, and past trips. 
        If the trip start date is in the future, the trip for which you've registered your child will be displayed this way. 
        From this view, you can also directly manage your family members and your account. 
        You can do this by clicking the left and right buttons, respectively, on both this and the other screens.    
    </td>
  </tr>
  <tr>
    <td width="500">
      <a href="screenshots-functionaliteiten/dashboard/current-reizen.png">
        <img src="screenshots-functionaliteiten/dashboard/current-reizen.png" width="500" alt="current-trips">
      </a>
    </td>
    <td style="padding-block: 15px;">
        If the start date of a registered trip is in the past but the end date is still in the future, the trip will be displayed this way. 
        These trips change categories dynamically, so they don't need to be manually moved by the admin. 
        If your child isn't registered for any other trips or isn't listed in any other categories, you'll also receive the appropriate message, as you can see on this and the other two screens.
    </td>
  </tr>
  <tr>
    <td width="500">
      <a href="screenshots-functionaliteiten/dashboard/afgelopen-reizen.png">
        <img src="screenshots-functionaliteiten/dashboard/afgelopen-reizen.png" width="500" alt="past-trips">
      </a>
    </td>
    <td style="padding-block: 15px;">
        Finally, if the end date of the registered trip is in the past, it will be displayed this way on the dashboard. 
        These trips will remain visible for a total of one month. 
        After that, they will disappear from the dashboard. Besides the two management buttons, you can also leave a review here once the trip has ended. 
        The button at the bottom, labeled "Geef review", will let you add a review to the trip.
    </td>
  </tr>
</table>

## Reviews
All code for the functionalities below can be found in the files in the directories below.

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
- `Review`

<table>
  <thead>
      <tr>
        <td style="text-align: center;"><b>Screenshot</b></td>
        <td style="text-align: center;"><b>Explanation</b></td>
      </tr>
  </thead>
  <tr>
    <td width="500">
      <a href="screenshots-functionaliteiten/review/review-create.png">
        <img src="screenshots-functionaliteiten/review/review-create.png" width="500" alt="create-review">
      </a>
    </td>
    <td style="padding-block: 15px;">
        By clicking the "Geef review" button on the previous screen, you'll arrive at this screen. 
        Here, as you can see, you can give the star rating and your accompanying comment. 
        If you're satisfied with your review, click the left button labeled "Plaats review". 
        This will take you back to the dashboard and simultaneously add the review to the trip. 
        If you don't want to leave a review, use the right button, "Terug naar dashboard", to return to your dashboard.    
    </td>
  </tr>
  <tr>
    <td width="500">
      <a href="screenshots-functionaliteiten/review/review-edit.png">
        <img src="screenshots-functionaliteiten/review/review-edit.png" width="500" alt="edit-review">
      </a>
    </td>
    <td style="padding-block: 15px;">
        If you'd like to edit your review, you can. Simply click the left button again for the trip where you posted your review. 
        Since your review already exists, you can adjust the star rating or your comment yourself. 
        When you're done, click the left "Wijzig review" button to save the changes. Like the previous screen, you can also return to the dashboard if you don't want to make any changes.    
    </td>
  </tr>
  <tr>
    <td width="500">
      <a href="screenshots-functionaliteiten/review/review-detailpage.png">
        <img src="screenshots-functionaliteiten/review/review-detailpage.png" width="500" alt="detailpage-review">
      </a>
    </td>
    <td style="padding-block: 15px;">
        Whether you've added a review to a trip or edited it, the review will appear on the group trip's details page. 
        Changes are implemented immediately and will be updated here as well.    
    </td>
  </tr>
</table>



## Family members ('Gezinsleden')
All code for the functionalities below can be found in the files in the directories below.

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
        <td style="text-align: center;"><b>Explanation</b></td>
      </tr>
  </thead>
  <tr>
    <td width="500">
      <a href="screenshots-functionaliteiten/gezinsleden/overzicht-kinderen.png">
        <img src="screenshots-functionaliteiten/gezinsleden/overzicht-kinderen.png" width="500" alt="overview-children">
      </a>
    </td>
    <td style="padding-block: 15px;">
        If you're logged in as a parent and you click the "Gezinsleden beheren" button, you'll arrive at this screen. 
        Here you'll see an overview of all the children you've added. To add a new child to the list, click the "+" in the top right corner.    
    </td>
  </tr>
  <tr>
   <td width="500">
      <a href="screenshots-functionaliteiten/gezinsleden/create-kind.png">
        <img src="screenshots-functionaliteiten/gezinsleden/create-kind.png" width="500" alt="create-child">
      </a>
    </td>
    <td style="padding-block: 15px;">
        Clicking the "+" button will take you to this screen, where you can add a child. 
        If your child doesn't have any allergies or medications, you can leave these fields blank, as they will automatically be filled in with "Geen" when the child is added. 
        You can also use the right button to return to the children overview. To add your child, click the "Kind toevoegen" button on the left.    
    </td>
  </tr>
  <tr>
    <td width="500">
      <a href="screenshots-functionaliteiten/gezinsleden/nieuw-kind-overzicht.png">
        <img src="screenshots-functionaliteiten/gezinsleden/nieuw-kind-overzicht.png" width="500" alt="new-child-overview">
      </a>
    </td>
    <td style="padding-block: 15px;">
        If everything went well, you'll return to this screen after clicking the submit button, this time with the new child added to the bottom of the list. 
        You'll also see an alert indicating the action was successful. 
    </td>
  </tr>
  <tr>
    <td width="500">
      <a href="screenshots-functionaliteiten/gezinsleden/edit-kind.png">
        <img src="screenshots-functionaliteiten/gezinsleden/edit-kind.png" width="500" alt="edit-child">
      </a>
    </td>
    <td style="padding-block: 15px;">
        If you want to change any of your child's details, click the "pencil" icon to make changes on this screen. 
        If you'd like to add any medications or allergies, simply change them in the text field. 
        The "Geen" field will only be filled in if nothing is entered. To apply your changes, click the green button. 
        This will take you back to the overview, with another alert indicating that the action was successful. 
        The changes will then be visible in the list. The yellow button, again, is the button to return to the overview if you decide not to make any changes.
    </td>
  </tr>
  <tr>
    <td width="500">
      <a href="screenshots-functionaliteiten/gezinsleden/delete-kind.png">
        <img src="screenshots-functionaliteiten/gezinsleden/delete-kind.png" width="500" alt="delete-child">
      </a>
    </td>
    <td style="padding-block: 15px;">
        Like all delete actions, you'll receive a confirmation message asking whether or not you want to delete the selected child. To delete a child, click the trash can icon, as with other actions. Clicking the "Delete" button will remove the child from the list. The "Terug naar overzicht" button will also return you to the overview.
    </td>
  </tr>
  <tr>
    <td width="500">
      <a href="screenshots-functionaliteiten/gezinsleden/ingeschreven-kind.png">
        <img src="screenshots-functionaliteiten/gezinsleden/ingeschreven-kind.png" width="500" alt="registered-child-detailpage">
      </a>
    </td>
    <td style="padding-block: 15px;">
        If you've added children and would like to register them for a trip, you can do so via the group trip details page, which you can access by clicking the "Meer informatie" button on the homepage. 
        All active and upcoming trips are displayed there. Clicking the yellow "Kind inschrijven" button will open a pop-up window. In this pop-up window, you can select the child you'd like to register and provide any comments. 
        If you click the "Submit" button there, the child will be displayed this way. 
        If you want to remove your child from the list, click the red "Uitschrijven" button. You'll then receive a confirmation pop-up window. 
        Depending on your response, your child will be removed from the trip and removed from the list.    
    </td>
  </tr>
</table>