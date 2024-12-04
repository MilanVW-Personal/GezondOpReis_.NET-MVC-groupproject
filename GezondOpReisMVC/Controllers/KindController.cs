using GezondOpReis.Models;
using Microsoft.AspNetCore.Mvc;

namespace GezondOpReis.Controllers
{
    public class KindController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<CustomUser> _userManager;

        public KindController(IUnitOfWork unitOfWork, IMapper mapper, UserManager<CustomUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<ActionResult<IEnumerable<Kind>>> Index(string id)
        {
            var kinderenVanOuders = await _unitOfWork.KindRepo.GetAllKinderenFromOuders(id);

            List<KindViewModel> kinderenMetOudersVM = new();

            foreach(var kvo in kinderenVanOuders)
            {
                KindViewModel vm = _mapper.Map<KindViewModel>(kvo);
                vm.Id = kvo.Id;
                kinderenMetOudersVM.Add(vm);
            }

            return View(kinderenMetOudersVM);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(KindCreateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);

                Kind newkind = new()
                {
                    PersoonId = user.Id,
                    Naam = vm.Naam,
                    Voornaam = vm.Voornaam,
                    GeboorteDatum = vm.GeboorteDatum,
                    Allergieen = vm.Allergieen,
                    Medicatie = vm.Medicatie,
                };

           
                    await _unitOfWork.KindRepo.AddAsync(newkind);
                    await _unitOfWork.SaveChangesAsync();

                    TempData["AlertMessage"] = "Kind toegevoegd!";
                    return RedirectToAction(nameof(Index), new { id = user.Id });
            }

            return View(vm);
        }




    }
}
