using GezondOpReis.ViewModels;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using GezondOpReis.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Monitor = GezondOpReis.Models.Monitor;

namespace GezondOpReis.Controllers
{
    public class GroepsReisController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;
        private readonly UserManager<CustomUser> _userManager;

        public GroepsReisController(IUnitOfWork context, IMapper mapper, UserManager<CustomUser> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var reizen = await _context.GroepsReisRepository.GetAllGroepsReizenAsync();
            GroepsReizenTonenViewModel model = new GroepsReizenTonenViewModel();

            model.GroepsReizen = _mapper.Map<List<GroepsReisDetailsViewModel>>(reizen);

            return View(model);
        }

        public async Task<IActionResult> ReisInfo(int id)
        {
            var reis = await _context.GroepsReisRepository.GetGroepsReizenWithIdAsync(id);
            
            if (reis == null)
            {
                return NotFound();
            }

            GroepsReisInfoViewModel model = _mapper.Map<GroepsReisInfoViewModel>(reis);
            return View(model);
        }

        [Authorize(Roles = "Beheerder")]
        public async Task<IActionResult> Create()
        {
            var bestemmingen = await _context.BestemmingRepo.GetAllAsync();
            var model = new GroepsReisCreateViewModel
            {
                Bestemmingen = _mapper.Map<List<BestemmingViewModel>>(bestemmingen),
                BeginDatum = DateTime.Today,
                EindDatum = DateTime.Today.AddDays(1)
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Beheerder")]
        public async Task<IActionResult> Create(GroepsReisCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.EindDatum <= model.BeginDatum)
                {
                    ModelState.AddModelError("EindDatum", "Einddatum moet na de begindatum liggen");
                    model.Bestemmingen = _mapper.Map<List<BestemmingViewModel>>(await _context.BestemmingRepo.GetAllAsync());
                    return View(model);
                }

                var groepsreis = new Models.Groepsreis
                {
                    BestemmingId = model.BestemmingId,
                    BeginDatum = model.BeginDatum,
                    EindDatum = model.EindDatum,
                    prijs = model.Prijs
                };

                await _context.GroepsReisRepository.AddAsync(groepsreis);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            model.Bestemmingen = _mapper.Map<List<BestemmingViewModel>>(await _context.BestemmingRepo.GetAllAsync());
            return View(model);
        }
        [HttpGet]
        [Authorize(Roles = "Beheerder")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groepsreis = await _context.GroepsReisRepository.GetGroepReizenForDelete(id);
            if (groepsreis == null)
            {
                return NotFound();
            }

            return Json(new { id = groepsreis.Id });
        }

        
        
        [Authorize(Roles = "Beheerder")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var groepsreis = await _context.GroepsReisRepository.GetGroepReizenForDelete(id);
            
            if (groepsreis != null)
            {
                // Delete all Onkosten
                if (groepsreis.Onkosten != null)
                {
                    foreach (var onkost in groepsreis.Onkosten.ToList())
                    {
                        _context.OnkostenRepository.Delete(onkost);
                    }
                }

                // Delete all Programmas
                if (groepsreis.Programmas != null)
                {
                    foreach (var programma in groepsreis.Programmas.ToList())
                    {
                        _context.ProgrammaRepository.Delete(programma);
                    }
                }


                // Finally delete the Groepsreis
                _context.GroepsReisRepository.Delete(groepsreis);
                
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Groepsreis verwijderd!";
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> GetInschrijvenModal(int id)
        {
            var userId = _userManager.GetUserId(User);
            if (userId == null)
            {
                return Json(new { redirect = Url.Action("Login", "Gebruiker") });
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return Json(new { redirect = Url.Action("Login", "Gebruiker") });
            }

            // Get the groepsreis with its bestemming to check age requirements
            var groepsreis = await _context.GroepsReisRepository.GetGroepsReizenWithIdAsync(id);
            if (groepsreis == null || groepsreis.Bestemming == null)
            {
                return NotFound();
            }

            var kinderen = await _context.KindRepository.GetKinderenByUserAsync(userId);
            if (!kinderen.Any())
            {
                return Json(new { redirect = Url.Action("Create", "Kind") });
            }

            // Filter children based on age requirements from bestemming
            var today = DateTime.Today;
            var minLeeftijd = groepsreis.Bestemming.MinLeeftijd;
            var maxLeeftijd = groepsreis.Bestemming.MaxLeeftijd;

            var eligibleKinderen = kinderen.Where(k => {
                var age = today.Year - k.GeboorteDatum.Year;
                // Adjust age if birthday hasn't occurred this year
                if (k.GeboorteDatum.Date > today.AddYears(-age)) age--;
                return age >= minLeeftijd && age <= maxLeeftijd;
            });

            var viewModel = new GroepsReisInschrijvenViewModel
            {
                GroepsReisId = id,
                Kinderen = eligibleKinderen.Select(k => new SelectListItem
                {
                    Value = k.Id.ToString(),
                    Text = k.Voornaam + " " + k.Naam
                }).ToList()
            };

            return PartialView("_InschrijvenModal", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InschrijvenOpReis(GroepsReisInschrijvenViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // Reload the children list if validation fails
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var kinderen = await _context.KindRepository.GetKinderenByUserAsync(userId);
                model.Kinderen = kinderen.Select(k => new SelectListItem
                {
                    Value = k.Id.ToString(),
                    Text = k.Voornaam + " " + k.Naam
                }).ToList();
                return PartialView("_InschrijvenModal", model);
            }

            // Check if the child is already registered
            var existingDeelnemer = await _context.DeelnemerRepository
                .GetDeelnemerByKindAndReisAsync(model.KindId, model.GroepsReisId);

            if (existingDeelnemer != null)
            {
                ModelState.AddModelError("", "Dit kind is al ingeschreven voor deze reis.");
                return PartialView("_InschrijvenModal", model);
            }

            // Create new deelnemer
            var deelnemer = new Deelnemer
            {
                KindId = model.KindId,
                GroepsreisId = model.GroepsReisId,
                Opmerkingen = model.Opmerkingen
            };

            try
            {
                await _context.DeelnemerRepository.AddAsync(deelnemer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ReisInfo), new { id = model.GroepsReisId });
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Er is een fout opgetreden bij het inschrijven. Probeer het opnieuw.");
                return PartialView("_InschrijvenModal", model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UitschrijvenVanReis(int kindId, int reisId)
        {
            // Zoek de deelnemer op basis van kind en reis ID
            var deelnemer = await _context.DeelnemerRepository.GetDeelnemerByKindAndReisAsync(kindId, reisId);

            if (deelnemer == null)
            {
                return NotFound();
            }

            try
            {
                // Verwijder de deelnemer
                _context.DeelnemerRepository.Delete(deelnemer);
                await _context.SaveChangesAsync();

                TempData["AlertMessage"] = "Kind succesvol uitgeschreven van de reis.";
                return RedirectToAction(nameof(ReisInfo), new { id = reisId });
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "Er is een fout opgetreden bij het uitschrijven. Probeer het opnieuw.";
                return RedirectToAction(nameof(ReisInfo), new { id = reisId });
            }
        }

        public async Task<IActionResult> MonitorInschrijvenOpReis(string persoonId, int groepsReisId, bool isHoofdMonitor)
        {
            // Check if the monitor is already registered
            var existingDeelnemer = await _context.MonitorRepository
                .GetDeelnemerByMonitorAndReisAsync(persoonId, groepsReisId);

            if (existingDeelnemer != null)
            {
                ModelState.AddModelError("", "De monitor is al ingeschreven voor deze reis.");
                return RedirectToAction(nameof(ReisInfo), new { id = groepsReisId });
            }

            // If trying to register as head monitor, check if one already exists
            if (isHoofdMonitor)
            {
                var reis = await _context.GroepsReisRepository.GetGroepsReizenWithIdAsync(groepsReisId);
                if (reis.Monitoren != null && reis.Monitoren.Any(m => m.isHoofdMonitor == true))
                {
                    TempData["ErrorMessage"] = "Er is al een hoofdmonitor voor deze reis.";
                    return RedirectToAction(nameof(ReisInfo), new { id = groepsReisId });
                }
            }

            // Create new monitor
            var monitor = new Monitor
            {
                PersoonId = persoonId,
                GroepsreisId = groepsReisId,
                isHoofdMonitor = isHoofdMonitor
            };

            try
            {
                await _context.MonitorRepository.AddAsync(monitor);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = isHoofdMonitor ? "Succesvol ingeschreven als hoofdmonitor!" : "Succesvol ingeschreven als monitor!";
                return RedirectToAction(nameof(ReisInfo), new { id = groepsReisId });
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Er is een fout opgetreden bij het inschrijven. Probeer het opnieuw.");
                return RedirectToAction(nameof(ReisInfo), new { id = groepsReisId });
            }
        }
        public async Task<IActionResult> MonitorUitschrijvenVanReis(string monitorId, int reisId)
        {
            // Zoek de deelnemer op basis van kind en reis ID
            var monitor = await _context.MonitorRepository.GetDeelnemerByMonitorAndReisAsync(monitorId, reisId);

            if (monitor == null)
            {
                TempData["ErrorMessage"] = "Er is een fout opgetreden bij het uitschrijven. Probeer het opnieuw.";
                return RedirectToAction(nameof(ReisInfo), new { id = reisId });
            }

            try
            {
                // Verwijder de deelnemer
                _context.MonitorRepository.Delete(monitor);
                await _context.SaveChangesAsync();

                TempData["AlertMessage"] = "Monitor succesvol uitgeschreven van de reis.";
                return RedirectToAction(nameof(ReisInfo), new { id = reisId });
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "Er is een fout opgetreden bij het uitschrijven. Probeer het opnieuw.";
                return RedirectToAction(nameof(ReisInfo), new { id = reisId });
            }
        }

        public async Task<IActionResult> DeelnemerDetails(int reisId)
        {
            var userId = _userManager.GetUserId(User);
            if (userId == null)
            {
                return RedirectToAction("Login", "Gebruiker");
            }

            // Get the groepsreis and check if the user is the head monitor
            var reis = await _context.GroepsReisRepository.GetGroepsReizenWithIdAsync(reisId);
            if (reis == null)
            {
                return NotFound();
            }

            var isHoofdMonitor = reis.Monitoren?.Any(m => m.PersoonId == userId && m.isHoofdMonitor == true) ?? false;
            if (!isHoofdMonitor)
            {
                return Forbid();
            }

            // Get all participants with their details
            var deelnemers = reis.Deelnemers?
                .Where(d => d.Kind != null)
                .Select(d => new DeelnemerDetailsViewModel
                {
                    Voornaam = d.Kind.Voornaam ?? "Niet opgegeven",
                    Naam = d.Kind.Naam ?? "Niet opgegeven",
                    Leeftijd = CalculateAge(d.Kind.GeboorteDatum),
                    OuderTelefoon = d.Kind.CustomUser?.TelefoonNummer ?? "Niet opgegeven",
                    Medicatie = d.Kind.Medicatie ?? "Geen",
                    Allergieen = d.Kind.Allergieen ?? "Geen",
                    Opmerkingen = d.Opmerkingen ?? "Geen"
                })
                .ToList() ?? new List<DeelnemerDetailsViewModel>();

            return View(deelnemers);
        }

        private int CalculateAge(DateTime birthDate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthDate.Year;
            if (birthDate.Date > today.AddYears(-age)) age--;
            return age;
        }
    }
}
