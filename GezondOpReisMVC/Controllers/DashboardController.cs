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
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (user == null)
                return NotFound();

            var kinderen = await _unitOfWork.KindRepository.GetAllKinderenFromOuders(user.Id);
            var vorigeReizen = await _unitOfWork.GroepsReisRepository.GetVorigeReizen(user.Id); // Deze methode zal alle reizen, waarop je bent ingeschreven, ophalen waarvan de einddatum in het verleden ligt. 
            var ingeschrevenReizen = await _unitOfWork.GroepsReisRepository.GetIngeschrevenGroepsreizen(user.Id);

            var vm = new DashboardViewModel
            {
                VorigeReizen = vorigeReizen.ToList(),
                IngeschrevenReizen = ingeschrevenReizen.ToList(),
                Kinderen = kinderen.ToList()
            };
            

            return View(vm);
        }
    }
}
