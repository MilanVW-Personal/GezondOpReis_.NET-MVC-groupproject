using GezondOpReis.Models;

namespace GezondOpReis.Data.Repo
{
    public class GroepsReisRepository : GenericRepository<Groepsreis>, IGroepsReisRepository
    {
        public GroepsReisRepository(GezondOpReisContext context) : base(context) { }

        public async Task<IEnumerable<Groepsreis>> GetAllGroepsReizenAsync()
        {
            return await _context.Groepsreizen
                .Include(gr => gr.Bestemming)
                    .ThenInclude(b => b.Fotos)
                .Include(gr => gr.Monitoren)
                    .ThenInclude(m => m.Persoon)
                .Include(gr => gr.Deelnemers)
                    .ThenInclude(d => d.Kind)
                .Include(gr => gr.Programmas)
                    .ThenInclude(p => p.Activiteit)
                .ToListAsync();
        }

        public async Task<Groepsreis> GetGroepsReizenWithIdAsync(int id)
        {
            return await _context.Groepsreizen
                .Include(gr => gr.Bestemming)
                    .ThenInclude(b => b.Fotos)
                .Include(gr => gr.Monitoren)
                    .ThenInclude(m => m.Persoon)
                .Include(gr => gr.Deelnemers)
                    .ThenInclude(d => d.Kind)
                .Include(gr => gr.Programmas)
                    .ThenInclude(p => p.Activiteit)
                .SingleOrDefaultAsync(gr => gr.Id == id);
        }

        public async Task<Groepsreis> GetGroepReizenForDelete(int id)
        {
            return await _context.Groepsreizen
                .Include(gr => gr.Onkosten)
                .Include(gr => gr.Bestemming)
                .Include(gr => gr.Programmas)
                .Include(gr => gr.Monitoren)
                .Include(gr => gr.Deelnemers)
                .SingleOrDefaultAsync(gr => gr.Id == id);

        }
    }
}
