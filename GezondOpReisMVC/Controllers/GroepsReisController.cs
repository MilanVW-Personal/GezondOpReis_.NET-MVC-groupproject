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
			var reizen = await _context.GroepsReisRepository.GetAllAsync();
			GroepsReizenTonenViewModel model = new GroepsReizenTonenViewModel();

			model.GroepsReizen = _mapper.Map<List<GroepsReisDetailsViewModel>>(reizen);

			return View(model);
		}


	}

}
