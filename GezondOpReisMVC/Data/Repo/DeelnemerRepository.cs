using GezondOpReis.Data.Context;
using GezondOpReis.Models;
using Microsoft.EntityFrameworkCore;

namespace GezondOpReis.Data.Repo
{
    public class DeelnemerRepository : GenericRepository<Deelnemer>, IDeelnemerRepository
    {
        public DeelnemerRepository(GezondOpReisContext context) : base(context)
        {
        }

        public async Task<Deelnemer> GetDeelnemerByKindAndReisAsync(int kindId, int reisId)
        {
            return await _context.Set<Deelnemer>()
                .FirstOrDefaultAsync(d => d.KindId == kindId && d.GroepsreisId == reisId);
        }

    }
}
