using GezondOpReis.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GezondOpReis.Controllers
{
    public class OnkostenController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly UserManager<CustomUser> _userManager;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public OnkostenController(IUnitOfWork context, UserManager<CustomUser> userManager, IWebHostEnvironment env)
        {
            _context = context;
            _userManager = userManager;
            _webHostEnvironment = env;
        }
        public async Task<IActionResult> Index(int id)
        {
            var onkosten = await _context.OnkostenRepository.GetAllAsync();
            List<OnkostViewModel> viewmodel = new List<OnkostViewModel>();
            if (onkosten != null)
            {
                foreach (var onkost in onkosten)
                {
                    if (onkost.GroepsreisId == id)
                    {
                        OnkostViewModel vm = new OnkostViewModel
                        {
                            Id = onkost.Id,
                            Titel = onkost.Titel,
                            Beschrijving = onkost.Omschrijving,
                            Bedrag = onkost.Bedrag,
                            Datum = onkost.Datum,
                        };
                        viewmodel.Add(vm);
                    }
                }
                OnkostenIndexViewModel viewModel = new OnkostenIndexViewModel
                {
                    Onkosten = viewmodel,
                    GroepsreisId = id
                };
                return View(viewModel);
            }
            else
            {
                return View(new OnkostenIndexViewModel { GroepsreisId = id });
            }
        }
        [Authorize(Roles = "Beheerder,Verantwoordelijke")]
        [HttpGet]
        public IActionResult Create(int id)
        {
            var viewModel = new OnkostCreateViewModel
            {
                GroepsreisId = id
            };
            return View(viewModel);
        }

        [Authorize(Roles = "Beheerder,Verantwoordelijke")]
        [HttpPost]
        public async Task<IActionResult> Create(OnkostCreateViewModel model, IFormFile fotoFile)
        {
            if (ModelState.IsValid)
            {
                var onkost = new Onkosten
                {
                    Titel = model.Titel,
                    Omschrijving = model.Beschrijving,
                    Bedrag = model.Bedrag,
                    Datum = model.Datum,
                    Foto = fotoFile?.FileName,
                    GroepsreisId = model.GroepsreisId
                };

                _context.OnkostenRepository.AddAsync(onkost);
                await _context.SaveChangesAsync();

                if (fotoFile != null)
                {
                    var padNaarWwwRoot = Path.Combine(_webHostEnvironment.WebRootPath, "images"); // path naar de 'images' map in de 'wwwroot' folder

                    if (fotoFile.Length > 0)
                    {
                        var fileName = fotoFile.FileName;
                        var volledigPad = Path.Combine(padNaarWwwRoot, fileName);

                        using (var stream = new FileStream(volledigPad, FileMode.Create))
                        {
                            await fotoFile.CopyToAsync(stream); // content van de foto kopiëren naar de FileStream.
                        }
                    }
                }

                return RedirectToAction(nameof(Index), new { id = model.GroepsreisId });
            }

            return View(model);
        }
        [Authorize(Roles = "Beheerder,Verantwoordelijke")]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var onkost = await _context.OnkostenRepository.GetByIdAsync(id);
            if (onkost == null)
            {
                return NotFound(); // Of een andere foutafhandeling
            }

            OnkostDetailsViewModel model = new OnkostDetailsViewModel
            {
                Foto = onkost.Foto
            };

            ViewBag.GroepsreisId = onkost.GroepsreisId;

            return View(model);
        }
        [Authorize(Roles = "Beheerder,Verantwoordelijke")]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var onkost = await _context.OnkostenRepository.GetByIdAsync(id);
            if (onkost == null)
            {
                return NotFound();
            }

            var viewModel = new OnkostEditViewModel
            {
                Id = onkost.Id,
                Titel = onkost.Titel,
                Omschrijving = onkost.Omschrijving,
                Bedrag = onkost.Bedrag,
                Datum = onkost.Datum,
            };

            return View(viewModel);
        }

        [Authorize(Roles = "Beheerder,Verantwoordelijke")]
        [HttpPost]
        public async Task<IActionResult> Edit(int id, OnkostEditViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var onkost = await _context.OnkostenRepository.GetByIdAsync(id);
                if (onkost == null)
                {
                    return NotFound();
                }

                onkost.Titel = model.Titel;
                onkost.Datum = model.Datum;
                onkost.Bedrag = model.Bedrag;
                onkost.Omschrijving = model.Omschrijving;

                _context.OnkostenRepository.Update(onkost);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index), new {id = onkost.GroepsreisId});
            }

            return View(model);
        }
        [Authorize(Roles = "Beheerder,Verantwoordelijke")]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var onkost = await _context.OnkostenRepository.GetByIdAsync(id);
            if (onkost == null)
            {
                return NotFound();
            }

            var viewModel = new OnkostViewModel
            {
                Titel = onkost.Titel,
                Beschrijving = onkost.Omschrijving,
                Bedrag = onkost.Bedrag,
                Datum = onkost.Datum,
                Foto = onkost.Foto
            };

            return View(viewModel);
        }

        [Authorize(Roles = "Beheerder,Verantwoordelijke")]
        [HttpPost, ActionName("DeleteConfirmed")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var onkost = await _context.OnkostenRepository.GetByIdAsync(id);
            if (onkost == null)
            {
                return NotFound();
            }

            var viewModel = new OnkostViewModel
            {
                Titel = onkost.Titel,
                Beschrijving = onkost.Omschrijving,
                Bedrag = onkost.Bedrag,
                Datum = onkost.Datum,
                Foto = onkost.Foto
            };

            if(onkost.Foto != null) 
            {
                var padNaarFotoNaam = Path.Combine(_webHostEnvironment.WebRootPath, "images", onkost.Foto); // path naar de 'images' map in de 'wwwroot' folder


                if (System.IO.File.Exists(padNaarFotoNaam))
                    System.IO.File.Delete(padNaarFotoNaam);
            }

            

            _context.OnkostenRepository.Delete(onkost);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index), new {id = onkost.GroepsreisId});
        }
    }
}
