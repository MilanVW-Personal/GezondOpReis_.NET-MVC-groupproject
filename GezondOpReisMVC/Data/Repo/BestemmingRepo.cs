using GezondOpReis.Models;

namespace GezondOpReis.Data.Repo
{
    public class BestemmingRepo : GenericRepository<Bestemming>, IBestemmingRepo
    {
        public BestemmingRepo(GezondOpReisContext context) : base(context)
        {
            
        }

        public async Task<Bestemming> ZoekBestemmingMetFotoEnGroepsReisEnReviews(int id)
        {
            var lijst = await _context.Bestemmingen
                        .Include(b => b.Fotos)
                        .Include(b => b.Groepsreizen)
                        .Include(b => b.Reviews)
                        .FirstOrDefaultAsync(b => b.Id == id);

            return lijst;
        }
    }
}
