using GezondOpReis.Models;
using Monitor = GezondOpReis.Models.Monitor;

namespace GezondOpReis.Data.Repo
{
    public interface IMonitorRepository : IGenericRepository<Monitor>
    {
     Task<Monitor> GetDeelnemerByMonitorAndReisAsync(string monitorId, int reisId);
    }
}
