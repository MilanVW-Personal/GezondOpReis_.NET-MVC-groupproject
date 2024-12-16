using GezondOpReis.Models;
using GezondOpReis.ViewModels;

namespace GezondOpReis.Controllers
{
    public class DashboardController : Controller
    {
        private readonly UserManager<CustomUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;

        public DashboardController(UserManager<CustomUser> userManager, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            // Als user niet is ingelogd, redirecten naar inlog pagina
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Gebruiker");


            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var userName = user.Voornaam + " " + user.Naam; // naam van de gebruiker tonen op het dashboard ipv VoornaamNaam1234556...
            TempData["Username"] = userName; // naam opslaan in tempdata

            if (user == null)
                return NotFound();

            var kinderen = await _unitOfWork.KindRepository.GetAllKinderenFromOuders(user.Id);
            var vorigeReizen = await _unitOfWork.GroepsReisRepository.GetVorigeReizen(user.Id); // Deze methode zal alle reizen, waarop je bent ingeschreven, ophalen waarvan de einddatum in het verleden ligt. 
            var ingeschrevenReizen = await _unitOfWork.GroepsReisRepository.GetIngeschrevenGroepsreizen(user.Id);

            var reizenInVerleden = vorigeReizen.Where(r => !(DateTime.Now > r.EindDatum.AddMonths(1))); // de reizen in het verleden zijn de vorige ingeschreven reizen, waarvan de huidige datum niet groter is dan de einddatum, een maand later.
            var aankomendeReizen = await _unitOfWork.GroepsReisRepository.GetAankomendeReizen(user.Id); // aankomende reizen ophalen (waar huidige datum kleiner is dan de begindatum)

            /* Opleidingen van de monitoren ophalen */
            var opleidingen = await _unitOfWork.OpleidingRepo.GetAllAsync();
            var opleidingenVM = new List<OpleidingViewModel>();
            
            foreach (var opleiding in opleidingen)
            {
                var ingeschrevenOpOpleiding = await _unitOfWork.OpleidingPersoonRepo.IsUserInschrijvingBestaatAsync(user.Id, opleiding.Id);
                if (ingeschrevenOpOpleiding)
                {
                    opleidingenVM.Add(new OpleidingViewModel
                    {
                        Id = opleiding.Id,
                        Naam = opleiding.Naam,
                        Beschrijving = opleiding.Beschrijving,
                        StartDatum = opleiding.Begindatum,
                        EindDatum = opleiding.Einddatum,
                        AantalPlaatsen = opleiding.AantalPlaatsen,
                        IsIngeschreven = ingeschrevenOpOpleiding
                    });
                }
            }


            var vm = new DashboardViewModel
            {
                ReizenInVerleden = reizenInVerleden.ToList(),
                IngeschrevenReizen = ingeschrevenReizen.Where(r => DateTime.Now <= r.EindDatum).ToList(),
                Kinderen = kinderen.ToList(),
                AankomendeReizen = aankomendeReizen.ToList(),
                OpleidingenVanMonitoren = opleidingenVM
            };

            return View(vm);
        }
    }
}
