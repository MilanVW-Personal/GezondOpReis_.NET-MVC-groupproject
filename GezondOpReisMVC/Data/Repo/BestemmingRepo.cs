using GezondOpReis.Models;

namespace GezondOpReis.Data.Repo
{
    public class BestemmingRepo : GenericRepository<Bestemming>, IBestemmingRepo
    {
        public BestemmingRepo(GezondOpReisContext context) : base(context)
        {
            
        }

        public async Task<Bestemming> ZoekBestemmingMetFotoEnGroepsReis(int id)
        {
            var lijst = await _context.Bestemmingen
                        .Include(b => b.Fotos)
                        .Include(b => b.Groepsreizen)
                        .FirstOrDefaultAsync(b => b.Id == id && b.Fotos.Any() && b.Groepsreizen.Any());

            return lijst;
        }
    }
}
