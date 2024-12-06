using GezondOpReis.Data.Context;
using GezondOpReis.Models;
using Microsoft.EntityFrameworkCore;

namespace GezondOpReis.Data.Repo
{
    public class KindRepository : GenericRepository<Kind>, IKindRepository
    {
        public KindRepository(GezondOpReisContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Kind>> GetKinderenByUserAsync(string userId)
        {
            return await _context.Set<Kind>()
                .Where(k => k.PersoonId == userId)
                .ToListAsync();
        }
        public async Task<IEnumerable<Kind>> GetAllKinderenFromOuders(string id)
        {
            return await _context.Kinderen
                .Include(o => o.CustomUser)
                .Where(k => k.PersoonId == id)
                .ToListAsync();
        }
    }
}
