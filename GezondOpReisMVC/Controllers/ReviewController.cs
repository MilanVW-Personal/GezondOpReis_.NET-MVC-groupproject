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

        public IActionResult Edit(int bestemmingId)
        {
            ViewData["bestemming"] = bestemmingId; // nodig om create te laten werken
            return View();
        }

        public async Task<IActionResult> Create(int bestemmingId)
        {
            ViewData["bestemming"] = bestemmingId; // nodig om create te laten werken

            /* Hier wordt gecheckt of dat er al een review van de user voor de bestemming bestaat, 
             * als dit niet zo is, dan zal deze naar de create pagina, gaan anders naar de edit pagina. */
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var reviewVanUser = await _unitOfWork.ReviewRepo.GetAlleReviewsVanUserVoorBestemming(user.Id, bestemmingId);

            if (reviewVanUser != null)
            {
                return RedirectToAction(nameof(Edit), new { bestemmingId = bestemmingId }); // BestemmingId kan hier ook gebruikt worden, Id, gaat hier niet.
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReviewCreateViewModel vm, int bestemmingId)
        {
            // zonder modelstate werkt deze create.
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int bestemmingId, ReviewEditViewModel vm)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var review = await _unitOfWork.ReviewRepo.GetAlleReviewsVanUserVoorBestemming(user.Id, bestemmingId);

            if (bestemmingId != review.BestemmingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    review.Score = vm.Score;
                    review.Tekst = vm.Tekst;

                    _unitOfWork.ReviewRepo.Update(review);
                    await _unitOfWork.SaveChangesAsync();

                    return RedirectToAction("Index", "Dashboard");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await _unitOfWork.ReviewRepo.GetAlleReviewsVanUserVoorBestemming(user.Id, bestemmingId) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return View(vm);
        }
    }
}
