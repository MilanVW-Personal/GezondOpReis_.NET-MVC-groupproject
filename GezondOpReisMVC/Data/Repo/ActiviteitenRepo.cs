using GezondOpReis.Models;

namespace GezondOpReis.Data.Repo
{
    public class ActiviteitenRepo : GenericRepository<Activiteit>, IActiviteitenRepo
    {
        public ActiviteitenRepo(GezondOpReisContext context) : base(context)
        {
            
        }

        public async Task<Activiteit> ZoekActiviteitMetProgramma(int id)
        {
            return await _context.Activiteiten.Include(p => p.Programmas).FirstOrDefaultAsync(a => a.Programmas.Any(p => p.ActiviteidId == id));
        }

    }
}
