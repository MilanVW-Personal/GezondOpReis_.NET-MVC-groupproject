using GezondOpReis.Models;

namespace GezondOpReis.Data.Repo
{
    public interface IDeelnemerRepository : IGenericRepository<Deelnemer>
    {
        Task<Deelnemer> GetDeelnemerByKindAndReisAsync(int kindId, int reisId);
        Task<IEnumerable<Deelnemer>> GetAllDeelnemersAsync();
    }
}
