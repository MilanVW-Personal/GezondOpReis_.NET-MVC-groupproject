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
    }
}
