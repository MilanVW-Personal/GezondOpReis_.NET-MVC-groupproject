using GezondOpReis.Models;
using GezondOpReis.ViewModels;

namespace GezondOpReis.Controllers
{
    public class BestemmingController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;

        public BestemmingController(IUnitOfWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
            var bestemming = await _context.BestemmingRepo.GetByIdAsync(id);

            if (bestemming != null)
            {
                _context.BestemmingRepo.Delete(bestemming);
                TempData["AlertMessage"] = "Bestemming verwijderd!"; // TempData wordt hier gebruikt om de alert te kunnen tonen na het doen van een CRUD functie
            }

            await _context.SaveChangesAsync();
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
        public async Task<IActionResult> Create([Bind("Id,Code,Naam,Beschrijving,MinLeeftijd,MaxLeeftijd")] Bestemming bestemming)
        {
            if (ModelState.IsValid)
            {
                await _context.BestemmingRepo.AddAsync(bestemming);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Bestemming aangemaakt!"; // TempData wordt hier gebruikt om de alert te kunnen tonen na het doen van een CRUD functie
                return RedirectToAction(nameof(Index));
            }

            return View(bestemming);
        }
    }
}
