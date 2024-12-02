using System.Collections;
using GezondOpReis.Models;

namespace GezondOpReis.Data.Repo
{
    public interface IKindRepo : IGenericRepository<Kind>
    {
        Task<IEnumerable<Kind>> GetAllKinderenFromOuders(string id);
    }
}
