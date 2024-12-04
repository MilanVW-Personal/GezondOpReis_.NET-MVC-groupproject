using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using GezondOpReis.ViewModels;
using GezondOpReis.Data;
using GezondOpReis.Models;
using Microsoft.AspNetCore.Identity;

namespace GezondOpReis.Controllers
{
    public class OpleidingController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly UserManager<CustomUser> _userManager;

        public OpleidingController(IUnitOfWork context, UserManager<CustomUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Authorize(Roles = "Beheerder,Monitor")]
        public async Task<IActionResult> Index()
        {
            var opleidingen = await _context.OpleidingRepo.GetAllAsync();
            List<OpleidingViewModel> viewModel = new List<OpleidingViewModel>();
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            foreach (var opleiding in opleidingen)
            {
                var ingeschreven = await _context.OpleidingPersoonRepo.IsUserInschrijvingBestaatAsync(user.Id, opleiding.Id);
                OpleidingViewModel vm = new OpleidingViewModel
                {
                    Id = opleiding.Id,
                    Naam = opleiding.Naam,
                    Beschrijving = opleiding.Beschrijving,
                    StartDatum = opleiding.Begindatum,
                    EindDatum = opleiding.Einddatum,
                    AantalPlaatsen = opleiding.AantalPlaatsen,
                    IsIngeschreven = ingeschreven
                };
                viewModel.Add(vm);
            }
            OpleidingIndexViewModel vam = new OpleidingIndexViewModel
            {
                Opleidingen = viewModel
            };

            return View(vam);
        }

        [Authorize(Roles = "Beheerder")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Beheerder")]
        [HttpPost]
        public async Task<IActionResult> Create(OpleidingCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var opleiding = new Opleiding
                {
                    Naam = model.Naam,
                    Beschrijving = model.Beschrijving,
                    Begindatum = model.StartDatum,
                    Einddatum = model.EindDatum,
                    AantalPlaatsen = model.AantalPlaatsen
                };

                _context.OpleidingRepo.AddAsync(opleiding);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [Authorize(Roles = "Beheerder")]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var opleiding = await _context.OpleidingRepo.GetByIdAsync(id);
            if (opleiding == null)
            {
                return NotFound();
            }

            var inschrevenPersonen = await _context.OpleidingPersoonRepo.GetInschrevenPersonenByOpleidingIdAsync(id);

            var viewModel = new OpleidingDetailsViewModel
            {
                Id = opleiding.Id,
                Naam = opleiding.Naam,
                Beschrijving = opleiding.Beschrijving,
                StartDatum = opleiding.Begindatum,
                EindDatum = opleiding.Einddatum,
                AantalPlaatsen = opleiding.AantalPlaatsen,
                InschrevenPersonen = inschrevenPersonen
            };

            return View(viewModel);
        }

        [Authorize(Roles = "Beheerder")]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var opleiding = await _context.OpleidingRepo.GetByIdAsync(id);
            if (opleiding == null)
            {
                return NotFound();
            }

            var viewModel = new OpleidingEditViewModel
            {
                Id = opleiding.Id,
                Naam = opleiding.Naam,
                Beschrijving = opleiding.Beschrijving,
                StartDatum = opleiding.Begindatum,
                EindDatum = opleiding.Einddatum,
                AantalPlaatsen = opleiding.AantalPlaatsen
            };

            return View(viewModel);
        }

        [Authorize(Roles = "Beheerder")]
        [HttpPost]
        public async Task<IActionResult> Edit(int id, OpleidingEditViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var opleiding = await _context.OpleidingRepo.GetByIdAsync(id);
                if (opleiding == null)
                {
                    return NotFound();
                }

                opleiding.Naam = model.Naam;
                opleiding.Beschrijving = model.Beschrijving;
                opleiding.Begindatum = model.StartDatum;
                opleiding.Einddatum = model.EindDatum;
                opleiding.AantalPlaatsen = model.AantalPlaatsen;

                _context.OpleidingRepo.Update(opleiding);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [Authorize(Roles = "Beheerder")]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var opleiding = await _context.OpleidingRepo.GetByIdAsync(id);
            if (opleiding == null)
            {
                return NotFound();
            }

            var viewModel = new OpleidingDetailsViewModel
            {
                Id = opleiding.Id,
                Naam = opleiding.Naam,
                Beschrijving = opleiding.Beschrijving,
                StartDatum = opleiding.Begindatum,
                EindDatum = opleiding.Einddatum,
                AantalPlaatsen = opleiding.AantalPlaatsen
            };

            return View(viewModel);
        }

        [Authorize(Roles = "Beheerder")]
        [HttpPost, ActionName("DeleteConfirmed")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var opleiding = await _context.OpleidingRepo.GetByIdAsync(id);
            if (opleiding == null)
            {
                return NotFound();
            }

            var opleidingMetPersoon = await _context.OpleidingPersoonRepo.GetAllAsync();
            bool heeftInschrijvingen = opleidingMetPersoon.Any(op => op.OpleidingId == id);

            if (heeftInschrijvingen)
            {
                var viewModel = new OpleidingDetailsViewModel
                {
                    Id = opleiding.Id,
                    Naam = opleiding.Naam,
                    Beschrijving = opleiding.Beschrijving,
                    StartDatum = opleiding.Begindatum,
                    EindDatum = opleiding.Einddatum,
                    AantalPlaatsen = opleiding.AantalPlaatsen,
                    ErrorMessage = "Je kunt deze opleiding niet verwijderen omdat er nog inschrijvingen aanwezig zijn."
                };

                return View("Delete", viewModel);
            }

            _context.OpleidingRepo.Delete(opleiding);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }



        [Authorize(Roles = "Monitor")]
        [HttpGet]
        public async Task<IActionResult> Inschrijven(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var opleiding = await _context.OpleidingRepo.GetByIdAsync(id);
            if (opleiding == null)
            {
                return NotFound();
            }

            var userId = _userManager.GetUserId(User);
            var isGeschrevenIn = await _context.OpleidingPersoonRepo.IsUserInschrijvingBestaatAsync(userId, id);

            if (isGeschrevenIn)
            {
                return RedirectToAction(nameof(Uitschrijven), new { id = id });
            }
            
            

            if (opleiding.AantalPlaatsen > 0)
            {
                opleiding.AantalPlaatsen = opleiding.AantalPlaatsen - 1;
            }
            else
            {
                opleiding.AantalPlaatsen = 0;
            }
            _context.OpleidingRepo.Update(opleiding);

            var opleidingPersoon = new OpleidingPersoon
            {
                OpleidingId = id,
                PersoonId = userId,
            };

            _context.OpleidingPersoonRepo.AddAsync(opleidingPersoon);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Monitor")]
        [HttpGet]
        public async Task<IActionResult> Uitschrijven(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var opleiding = await _context.OpleidingRepo.GetByIdAsync(id);
            if (opleiding == null)
            {
                return NotFound();
            }
           

            var userId = _userManager.GetUserId(User);
            var opleidingPersoon = await _context.OpleidingPersoonRepo.GetByUserIdAndOpleidingIdAsync(userId, id);

            if (opleidingPersoon != null)
            {
                _context.OpleidingPersoonRepo.Delete(opleidingPersoon);
                opleiding.AantalPlaatsen++;
                _context.OpleidingRepo.Update(opleiding);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "Beheerder")]

        [Authorize(Roles = "Beheerder")]
        [HttpPost]
        public async Task<IActionResult> DeleteUsers(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var opleiding = await _context.OpleidingRepo.GetByIdAsync(id);
            if (opleiding == null)
            {
                return NotFound();
            }

            var inschrevenPersonen = await _context.OpleidingPersoonRepo.GetInschrevenPersonenByOpleidingAsync(id);
            foreach (var persoon in inschrevenPersonen)
            {
                _context.OpleidingPersoonRepo.Delete(persoon);
                opleiding.AantalPlaatsen++;
            }

            _context.OpleidingRepo.Update(opleiding);
            await _context.SaveChangesAsync();

            return Json(new { success = true });
        }
    }
}