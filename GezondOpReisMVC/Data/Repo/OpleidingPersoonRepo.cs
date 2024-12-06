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
        public async Task<List<string>> GetInschrevenPersonenByOpleidingIdAsync(int opleidingId)
        {
            var inschrijvingen = await _context.OpleidingPersonen.Where(op => op.OpleidingId == opleidingId).ToListAsync();
            var personenIds = inschrijvingen.Select(op => op.PersoonId).ToList();
            var personen = await _context.Users.Where(u => personenIds.Contains(u.Id)).ToListAsync();
            return personen.Select(u => u.Voornaam + " " + u.Naam).ToList();
        }
        public async Task<List<OpleidingPersoon>> GetInschrevenPersonenByOpleidingAsync(int opleidingId)
        {
            return await _context.OpleidingPersonen
                .Include(op => op.Persoon)
                .Where(op => op.OpleidingId == opleidingId)
                .ToListAsync();
        }
    }
}