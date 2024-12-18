using GezondOpReis.Models;

namespace GezondOpReis.Data.Repo
{
    public class ReviewRepo : GenericRepository<Review>, IReviewRepo
    {
        public ReviewRepo(GezondOpReisContext context) : base(context)
        {
            
        }

        public async Task<IEnumerable<Review>> GetAllReviewsVoorBestemming( int bestemmingId)
        {
           return await _context.Reviews
                .Where(rv => rv.BestemmingId == bestemmingId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Review>> GetAlleReviewsVanUser(string userId)
        {
            return await _context.Reviews
                 .Where(rv => rv.PersoonId == userId)
                 .ToListAsync();
        }
    }
}
