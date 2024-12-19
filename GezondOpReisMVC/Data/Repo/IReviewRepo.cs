using GezondOpReis.Models;

namespace GezondOpReis.Data.Repo
{
    public interface IReviewRepo : IGenericRepository<Review>
    {
        Task<IEnumerable<Review>> GetAllReviewsVoorBestemming(int bestemmingId);
        Task<IEnumerable<Review>> GetAlleReviewsVanUser(string userId);
        Task<IEnumerable<Review>> GetAlleReviewsVanUserVoorBestemming(string userId, int bestemmingId);
    }
}
