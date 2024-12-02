using GezondOpReis.Models;
using Microsoft.AspNetCore.Mvc;

namespace GezondOpReis.Controllers
{
    public class KindController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public KindController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("PersoonId,Naam,Voornaam,Geboortedatum,Allergieen,Medicatie")] Kind kind)
        //{

        //    var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    var huidigeGebruikerAlsOuder = await _unitOfWork.GebruikerRepo.GetUserById(userID);

        //    kind.PersoonId = userID;
        //    kind.CustomUser = huidigeGebruikerAlsOuder;

        //    if (ModelState.IsValid)
        //    {
        //        await _unitOfWork.KindRepo.AddAsync(kind);
        //        await _unitOfWork.SaveChangesAsync();

        //        TempData["AlertMessage"] = "Kind toegevoegd!";
        //    }

        //    return RedirectToAction(nameof(Index), new {id = userID});
        //}
    }
}
