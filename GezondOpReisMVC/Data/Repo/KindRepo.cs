using GezondOpReis.Models;

namespace GezondOpReis.Data.Repo
{
    public class KindRepo : GenericRepository<Kind>, IKindRepo
    {
        public KindRepo(GezondOpReisContext context) : base(context)
        {

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
