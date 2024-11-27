using GezondOpReis.Models;

namespace GezondOpReis.Data.Repo
{
    public interface IBestemmingRepo : IGenericRepository<Bestemming>
    {
        Task<Bestemming> ZoekBestemmingMetFotoEnGroepsReisEnReviews(int id);
    }
}
