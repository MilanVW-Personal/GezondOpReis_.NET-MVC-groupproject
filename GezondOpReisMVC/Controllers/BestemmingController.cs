using GezondOpReis.Models;
using GezondOpReis.ViewModels;
using Microsoft.AspNetCore.Hosting;

namespace GezondOpReis.Controllers
{
    public class BestemmingController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BestemmingController(IUnitOfWork context, IMapper mapper, IWebHostEnvironment env)
        {
            _context = context;
            _mapper = mapper;
            _webHostEnvironment = env; // nodig om de 'wwwroot' map te kunnen vinden
        }

        public async Task<ActionResult<IEnumerable<Bestemming>>> Index()
        {
            var bestemmingen = await _context.BestemmingRepo.GetAllAsync(); // ophalen bestemmingen uit repo

            List<BestemmingViewModel> bestemmingVM = new();

            foreach (var bestemming in bestemmingen)
            {
                BestemmingViewModel vm = _mapper.Map<BestemmingViewModel>(bestemming); // mappen van de activiteit
                vm.Id = bestemming.Id; // id ook mee mappen
                bestemmingVM.Add(vm); // gemapt item toevoegen aan viewModel list
            }

            return View(bestemmingVM); // Return de viewModel list
        }

        public async Task<ActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bestemming = await _context.BestemmingRepo.GetByIdAsync(id);

            if (bestemming == null)
            {
                return NotFound();
            }

            BestemmingEditViewModel vm = _mapper.Map<BestemmingEditViewModel>(bestemming);

            return View(vm);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bestemming = await _context.BestemmingRepo.GetByIdAsync(id);

            BestemmingDeleteViewModel vm = _mapper.Map<BestemmingDeleteViewModel>(bestemming);

            return View(vm);
        }

        public IActionResult Create()
        {
            return View();
        }


        /* ==== CRUD Functions uitwerken \/ ==== */
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bestemmingMetReisEnFoto = await _context.BestemmingRepo.ZoekBestemmingMetFotoEnGroepsReisEnReviews(id);

            if (bestemmingMetReisEnFoto != null)
            {
                if (bestemmingMetReisEnFoto.Groepsreizen.Any()) // Als er records in de groepsreizen zitten, dan zal je deze niet kunnen verwijderen
                {
                   TempData["AlertMessage"] = "Bestemming kan niet worden verwijderd!";
                }
                else // Als er geen reizen aan de bestemmingen gekoppeld zijn, dan verwijder je de Reviews en de Foto's die aan de bestemming gelinkt zijn.
                {
                    foreach (var review in bestemmingMetReisEnFoto.Reviews.ToList())
                    {
                        // review(s), die aan de bestemming zijn gekoppeld, verwijderen
                        _context.ReviewRepo.Delete(review);
                    }

                    foreach (var foto in bestemmingMetReisEnFoto.Fotos.ToList())
                    {
                        /* Foto verwijderen */
                        var padNaarFotoNaam = Path.Combine(_webHostEnvironment.WebRootPath, "images", foto.Naam); // path naar de 'images' map in de 'wwwroot' folder
                        _context.FotoRepo.Delete(foto); // de foto verwijderen uit de db

                        if (System.IO.File.Exists(padNaarFotoNaam))
                            System.IO.File.Delete(padNaarFotoNaam); // Als de file bestaat in de map 'images', deze verwijderen

                    }

                }
                
                // Nadat foto en review(s) verwijderd zijn, bestemming verwijderen.
                _context.BestemmingRepo.Delete(bestemmingMetReisEnFoto);
                TempData["AlertMessage"] = "Bestemming verwijderd!"; // TempData wordt hier gebruikt om de alert te kunnen tonen na het doen van een CRUD functie
                await _context.SaveChangesAsync();
            }
            else
                TempData["AlertMessage"] = "Bestemming heeft geen gekoppelde groepsreis";

            return RedirectToAction(nameof(Index));
        }

        // POST: Job/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Code,Naam,Beschrijving,MinLeeftijd,MaxLeeftijd")] Bestemming bestemming)
        {
            if (id != bestemming.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.BestemmingRepo.Update(bestemming);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await _context.BestemmingRepo.GetByIdAsync(id) != null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
              
                TempData["AlertMessage"] = "Bestemming geupdatet!"; // TempData wordt hier gebruikt om de alert te kunnen tonen na het doen van een CRUD functie
                return RedirectToAction(nameof(Index));
            }

            return View(bestemming);
        }

        //// POST: Job/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Code,Naam,Beschrijving,MinLeeftijd,MaxLeeftijd")] Bestemming bestemming, IFormFile fotoFile)
        {
            if (ModelState.IsValid)
            {
                /* Bestemming aanmaken voordat de foto wordt toegevoegd */
                // Deze lijn zal éérst de bestemming toevoegen aan de database, als dit niet het geval is (bv. onderaan staat), dan zal dit niet lukken omdat men probeert een foto toe te voegen, omdat de bestemming nog niet bestaat.
                await _context.BestemmingRepo.AddAsync(bestemming); 
                // De veranderingen opslaan.
                await _context.SaveChangesAsync();

                /* Foto toevoegen aan bestemming en /images folder */
                var padNaarWwwRoot = Path.Combine(_webHostEnvironment.WebRootPath, "images"); // path naar de 'images' map in de 'wwwroot' folder
                var fileName = fotoFile.FileName;
                var volledigPad = Path.Combine(padNaarWwwRoot, fileName);

                using (var stream = new FileStream(volledigPad, FileMode.Create))
                {
                    await fotoFile.CopyToAsync(stream); // content van de foto kopiëren naar de foto.
                }

                Foto newFoto = new() { Naam = fileName, BestemmingId = bestemming.Id }; // nieuwe foto aanmaken
                await _context.FotoRepo.AddAsync(newFoto); // deze nieuwe foto toevoegen

                TempData["AlertMessage"] = "Bestemming aangemaakt!"; // TempData wordt hier gebruikt om de alert te kunnen tonen na het doen van een CRUD functie
                return RedirectToAction(nameof(Index));
            }

            return View(bestemming);
        }
    }
}
