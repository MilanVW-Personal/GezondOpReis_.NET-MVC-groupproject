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
            var opleidingViewModels = opleidingen.Select(o => new OpleidingViewModel
            {
                Id = o.Id,
                Naam = o.Naam,
                Beschrijving = o.Beschrijving,
                StartDatum = o.Begindatum,
                EindDatum = o.Einddatum,
                AantalPlaatsen = o.AantalPlaatsen
            }).ToList();

            var viewModel = new OpleidingIndexViewModel
            {
                Opleidingen = opleidingViewModels
            };

            return View(viewModel);
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

            if(opleiding.AantalPlaatsen > 0)
            {
                opleiding.AantalPlaatsen = opleiding.AantalPlaatsen - 1;
            }
            else
            {
                opleiding.AantalPlaatsen = 0;
            }
            _context.OpleidingRepo.Update(opleiding);

            // Get the currently logged-in user's ID
            var userId = _userManager.GetUserId(User);


            
            var opleidingPersoon = new OpleidingPersoon
            {
                OpleidingId = id,
                PersoonId = userId,
            };

            // Add the entry to the repository
            _context.OpleidingPersoonRepo.AddAsync(opleidingPersoon);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}