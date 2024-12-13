using GezondOpReis.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var kinderenVanOuders = await _unitOfWork.KindRepository.GetAllKinderenFromOuders(id);

            List<KindViewModel> kinderenMetOudersVM = new();

            foreach (var kvo in kinderenVanOuders)
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

        public async Task<ActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kind = await _unitOfWork.KindRepository.GetByIdAsync(id);

            if (kind == null)
            {
                return NotFound();
            }

            KindEditViewModel vm = _mapper.Map<KindEditViewModel>(kind);

            return View(vm);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kind = await _unitOfWork.KindRepository.GetByIdAsync(id);

            KindDeleteViewModel vm = _mapper.Map<KindDeleteViewModel>(kind);

            return View(vm);
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
                    CustomUser = user,
                    Naam = vm.Naam,
                    Voornaam = vm.Voornaam,
                    GeboorteDatum = vm.GeboorteDatum,
                    Allergieen = vm.Allergieen,
                    Medicatie = vm.Medicatie,
                };


                await _unitOfWork.KindRepository.AddAsync(newkind);
                await _unitOfWork.SaveChangesAsync();

                TempData["AlertMessage"] = "Kind toegevoegd!";
                return RedirectToAction(nameof(Index), new { id = user.Id });
            }

            return View(vm);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, KindEditViewModel vm)
        {

            var kind = await _unitOfWork.KindRepository.GetByIdAsync(id);

            if (id != kind.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    kind.Naam = vm.Naam;
                    kind.Voornaam = vm.Voornaam;
                    kind.GeboorteDatum = vm.GeboorteDatum;
                    kind.Allergieen = vm.Allergieen;
                    kind.Medicatie = vm.Medicatie;

                    _unitOfWork.KindRepository.Update(kind);
                    await _unitOfWork.SaveChangesAsync();

                    TempData["AlertMessage"] = "Gegevens van kind gewijzigd!";
                    return RedirectToAction(nameof(Index), new { id = kind.PersoonId });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await _unitOfWork.KindRepository.GetByIdAsync(id) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return View(vm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kind = await _unitOfWork.KindRepository.GetByIdAsync(id);

            if (kind != null)
            {
                _unitOfWork.KindRepository.Delete(kind);
                await _unitOfWork.SaveChangesAsync();
            }

            TempData["AlertMessage"] = "Kind verwijderd!";
            return RedirectToAction(nameof(Index), new {id = kind.PersoonId});
        }
    }
}
