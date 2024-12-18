using GezondOpReis.Models;

namespace GezondOpReis.Data.Repo
{
    public interface IReviewRepo : IGenericRepository<Review>
    {
        Task<IEnumerable<Review>> GetAllReviewsVoorBestemmingVanUser(string persoonId, int bestemmingId);
    }
}
