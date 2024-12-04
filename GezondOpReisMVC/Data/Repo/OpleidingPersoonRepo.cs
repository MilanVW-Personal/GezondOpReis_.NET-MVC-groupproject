using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GezondOpReis.Models;
using Microsoft.EntityFrameworkCore;

namespace GezondOpReis.Data.Repo
{
    public class OpleidingPersoonRepo : GenericRepository<OpleidingPersoon>, IOpleidingPersoonRepo
    {
        private readonly GezondOpReisContext _context;

        public OpleidingPersoonRepo(GezondOpReisContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> IsUserInschrijvingBestaatAsync(string userId, int opleidingId)
        {
            return await _context.OpleidingPersonen.AnyAsync(op => op.PersoonId == userId && op.OpleidingId == opleidingId);
        }

        public async Task<OpleidingPersoon?> GetByUserIdAndOpleidingIdAsync(string userId, int opleidingId)
        {
            return await _context.OpleidingPersonen.FirstOrDefaultAsync(op => op.PersoonId == userId && op.OpleidingId == opleidingId);
        }
    }
}