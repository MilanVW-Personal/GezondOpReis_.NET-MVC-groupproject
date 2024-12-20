using GezondOpReis.Models;
using Microsoft.EntityFrameworkCore;

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
                .Include(rv => rv.Persoon)
                .Where(rv => rv.BestemmingId == bestemmingId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Review>> GetAlleReviewsVanUser(string userId)
        {
            return await _context.Reviews
                .Include(rv => rv.Persoon)
                .Where(rv => rv.PersoonId == userId)
                .ToListAsync();
        }

        public async Task<Review> GetAlleReviewsVanUserVoorBestemming(string userId, int bestemmingId)
        {
            return await _context.Reviews.SingleOrDefaultAsync(x => (x.BestemmingId == bestemmingId && x.PersoonId == userId));
        }
    }
}
