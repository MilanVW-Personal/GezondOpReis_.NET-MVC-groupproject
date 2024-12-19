using GezondOpReis.Models;

namespace GezondOpReis.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<CustomUser> _userManager;

        public ReviewController(IUnitOfWork unitOfWork, IMapper mapper, UserManager<CustomUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }

        public IActionResult Create(int bestemmingId)
        {
            ViewData["bestemming"] = bestemmingId; // nodig om create te laten werken
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReviewCreateViewModel vm, int bestemmingId)
        {
            // zonder modelstate werkt deze te goei.
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var review = new Review
            {
                PersoonId = user.Id,
                BestemmingId = bestemmingId,
                Tekst = vm.Tekst,
                Score = vm.Score,
            };

            await _unitOfWork.ReviewRepo.AddAsync(review);
            await _unitOfWork.SaveChangesAsync();
           
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
