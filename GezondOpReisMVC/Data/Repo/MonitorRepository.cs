using GezondOpReis.Models;
using Monitor = GezondOpReis.Models.Monitor;

namespace GezondOpReis.Data.Repo
{
    public class MonitorRepository: GenericRepository<Monitor>, IMonitorRepository
    {
       
        public MonitorRepository(GezondOpReisContext context) : base(context)
        {
        }
        public async Task<Monitor> GetDeelnemerByMonitorAndReisAsync(string monitorId, int reisId)
        {
            return await _context.Set<Monitor>()
                .FirstOrDefaultAsync(d => d.PersoonId == monitorId && d.GroepsreisId == reisId);
        }
    }
}
