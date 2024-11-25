using GezondOpReis.Models;

namespace GezondOpReis.Data.Repo
{
    public interface IBestemmingRepo : IGenericRepository<Bestemming>
    {
        Task<Bestemming> ZoekBestemmingMetFotoEnGroepsReis(int id);
    }
}
