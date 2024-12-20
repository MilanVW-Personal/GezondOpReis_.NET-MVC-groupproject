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
                .Include(gr => gr.Bestemming)
                    .ThenInclude(b => b.Reviews)
                        .ThenInclude(r => r.Persoon)
                .Include(gr => gr.Monitoren)
                    .ThenInclude(m => m.Persoon)
                .Include(gr => gr.Deelnemers)
                    .ThenInclude(d => d.Kind)
                        .ThenInclude(k => k.CustomUser)
                .Include(gr => gr.Programmas)
                    .ThenInclude(p => p.Activiteit)
                .ToListAsync();
        }

        public async Task<Groepsreis> GetGroepsReizenWithIdAsync(int id)
        {
            return await _context.Groepsreizen
                .Include(gr => gr.Bestemming)
                    .ThenInclude(b => b.Fotos)
                .Include(gr => gr.Bestemming)
                    .ThenInclude(b => b.Reviews)
                        .ThenInclude(r => r.Persoon)
                .Include(gr => gr.Monitoren)
                    .ThenInclude(m => m.Persoon)
                .Include(gr => gr.Deelnemers)
                    .ThenInclude(d => d.Kind)
                        .ThenInclude(k => k.CustomUser)
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

        public async Task<IEnumerable<Groepsreis>> GetIngeschrevenGroepsreizen(string persoonId)
        {
            return await _context.Groepsreizen
                .Include(gr => gr.Bestemming)
                    .ThenInclude(b => b.Fotos)
                .Include(gr => gr.Bestemming)
                    .ThenInclude(b => b.Reviews)
                .Include(gr => gr.Monitoren)
                    .ThenInclude(m => m.Persoon)
                .Include(gr => gr.Deelnemers)
                    .ThenInclude(d => d.Kind)
                .Include(gr => gr.Programmas)
                    .ThenInclude(p => p.Activiteit)
                 .Where(gr => (gr.Deelnemers.Any(dl => dl.Kind.PersoonId == persoonId) || gr.Monitoren.Any(m => m.PersoonId == persoonId))
                    && (DateTime.Now >= gr.BeginDatum && DateTime.Now <= gr.EindDatum))
                .ToListAsync();
        }

        public async Task<IEnumerable<Groepsreis>> GetVorigeReizen(string persoonId)
        {
            return await _context.Groepsreizen
                .Include(gr => gr.Bestemming)
                    .ThenInclude(b => b.Fotos)
                .Include(gr => gr.Bestemming)
                    .ThenInclude(b => b.Reviews)
                .Include(gr => gr.Monitoren)
                    .ThenInclude(m => m.Persoon)
                .Include(gr => gr.Deelnemers)
                    .ThenInclude(d => d.Kind)
                .Include(gr => gr.Programmas)
                    .ThenInclude(p => p.Activiteit)
                .Where(gr => (gr.Deelnemers.Any(dl => dl.Kind.PersoonId == persoonId) || gr.Monitoren.Any(m => m.PersoonId == persoonId))
        && DateTime.Now > gr.EindDatum)
                .ToListAsync();
        }

        public async Task<IEnumerable<Groepsreis>> GetAankomendeReizen(string persoonId)
        {
            return await _context.Groepsreizen
                .Include(gr => gr.Bestemming)
                    .ThenInclude(b => b.Fotos)
                .Include(gr => gr.Bestemming)
                    .ThenInclude(b => b.Reviews)
                .Include(gr => gr.Monitoren)
                    .ThenInclude(m => m.Persoon)
                .Include(gr => gr.Deelnemers)
                    .ThenInclude(d => d.Kind)
                .Include(gr => gr.Programmas)
                    .ThenInclude(p => p.Activiteit)
                .Where(gr => (gr.Deelnemers.Any(dl => dl.Kind.PersoonId == persoonId) || gr.Monitoren.Any(m => m.PersoonId == persoonId))
        && DateTime.Now < gr.BeginDatum)
                .ToListAsync();
        }

        public async Task<IEnumerable<Groepsreis>> GetAdminAankomendeReizen()
        {
            return await _context.Groepsreizen
               .Include(gr => gr.Bestemming)
                   .ThenInclude(b => b.Fotos)
               .Include(gr => gr.Bestemming)
                    .ThenInclude(b => b.Reviews)
               .Include(gr => gr.Monitoren)
                   .ThenInclude(m => m.Persoon)
               .Include(gr => gr.Deelnemers)
                   .ThenInclude(d => d.Kind)
               .Include(gr => gr.Programmas)
                   .ThenInclude(p => p.Activiteit)
               .Where(gr => (gr.Deelnemers.Count > 0 && gr.Monitoren.Count > 0)
                      && DateTime.Now < gr.BeginDatum)
               .ToListAsync();
        }
    }
}
