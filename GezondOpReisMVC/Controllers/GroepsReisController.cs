using GezondOpReis.ViewModels;

namespace GezondOpReis.Controllers
{
    public class GroepsReisController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;

        public GroepsReisController(IUnitOfWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
    }
}
