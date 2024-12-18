using GezondOpReis.Models;

namespace GezondOpReis.Data.Repo
{
    public class ReviewRepo : GenericRepository<Review>, IReviewRepo
    {
        public ReviewRepo(GezondOpReisContext context) : base(context)
        {
            
        }

        public async Task<IEnumerable<Review>> GetAllReviewsVoorBestemmingVanUser(string persoonId, int bestemmingId)
        {
           return await _context.Reviews
                .Where(rv => rv.PersoonId == persoonId && rv.BestemmingId == bestemmingId)
                .ToListAsync();
        }
    }
}
