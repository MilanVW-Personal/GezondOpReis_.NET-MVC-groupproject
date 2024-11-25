using GezondOpReis.Models;
using GezondOpReis.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GezondOpReis.Controllers
{
    public class ActiviteitController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;

        public ActiviteitController(IUnitOfWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<IEnumerable<Activiteit>>> Index()
        {
            var activiteiten = await _context.ActiviteitenRepo.GetAllAsync(); // ophalen activiteiten uit repo

            List<ActiviteitViewModel> activiteitenVM = new();

            foreach(var activiteit in activiteiten)
            {
                //int aantalProgrammasInActiviteit = activiteit.Programmas.Count; // aantal programmas ophalen

                ActiviteitViewModel vm = _mapper.Map<ActiviteitViewModel>(activiteit); // mappen van de activiteit
                vm.Id = activiteit.Id; // id ook mee mappen
                activiteitenVM.Add(vm); // gemapt item toevoegen aan viewModel list
            }

            return View(activiteitenVM); // Return de viewModel list
        }

        // GET: Job/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activiteit = await _context.ActiviteitenRepo.GetByIdAsync(id);

            if (activiteit == null)
            {
                return NotFound();
            }

            ActiviteitEditViewModel vm = _mapper.Map<ActiviteitEditViewModel>(activiteit);

            return View(vm);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activiteit = await _context.ActiviteitenRepo.GetByIdAsync(id);

            ActiviteitDeleteViewModel vm = _mapper.Map<ActiviteitDeleteViewModel>(activiteit);

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
            var activiteit = await _context.ActiviteitenRepo.ZoekActiviteitMetProgramma(id);
            
            if (activiteit != null)
            {
                _context.ActiviteitenRepo.Delete(activiteit);
                await _context.SaveChangesAsync();
            }

            TempData["AlertMessage"] = "Activiteit verwijderd!"; // TempData wordt hier gebruikt om de alert te kunnen tonen na het doen van een CRUD functie
            return RedirectToAction(nameof(Index));
        }

        // POST: Job/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naam,Beschrijving")] Activiteit activiteit)
        {
            if (id != activiteit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.ActiviteitenRepo.Update(activiteit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await _context.ActiviteitenRepo.GetByIdAsync(id) != null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["AlertMessage"] = "Activiteit geupdatet!"; // TempData wordt hier gebruikt om de alert te kunnen tonen na het doen van een CRUD functie
                return RedirectToAction(nameof(Index));
            }
            return View(activiteit);
        }

        // POST: Job/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naam,Beschrijving")] Activiteit activiteit)
        {
            if (ModelState.IsValid)
            {

                await _context.ActiviteitenRepo.AddAsync(activiteit);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Activiteit aangemaakt!"; // TempData wordt hier gebruikt om de alert te kunnen tonen na het doen van een CRUD functie
                return RedirectToAction(nameof(Index));
            }

            return View(activiteit);
        }
    }
}