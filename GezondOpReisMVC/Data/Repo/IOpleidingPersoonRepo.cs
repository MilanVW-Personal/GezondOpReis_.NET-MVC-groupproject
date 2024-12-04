using GezondOpReis.Models;

namespace GezondOpReis.Data.Repo
{
    public interface IOpleidingPersoonRepo : IGenericRepository<OpleidingPersoon>
    {
        Task<bool> IsUserInschrijvingBestaatAsync(string userId, int opleidingId);
        Task<OpleidingPersoon?> GetByUserIdAndOpleidingIdAsync(string userId, int opleidingId);
    }
}
