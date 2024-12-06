using GezondOpReis.Models;

namespace GezondOpReis.Data.Repo
{
    public interface IKindRepository : IGenericRepository<Kind>
    {
        Task<IEnumerable<Kind>> GetKinderenByUserAsync(string userId);
        Task<IEnumerable<Kind>> GetAllKinderenFromOuders(string id);
    }
}
