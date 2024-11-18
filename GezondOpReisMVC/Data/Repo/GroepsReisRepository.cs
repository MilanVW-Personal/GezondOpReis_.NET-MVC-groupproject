using GezondOpReis.Models;

namespace GezondOpReis.Data.Repo
{
	public class GroepsReisRepository : GenericRepository<Groepsreis> ,IGroepsReisRepository
	{
		public GroepsReisRepository(GezondOpReisContext context) : base(context){ }

		public async Task<IEnumerable<Groepsreis>> GetAllGroepsReizenAsync()
		{
			return await _context.Groepsreizen
				.Include(gr => gr.Bestemming)
				.Include(gr => gr.Monitoren)
					.ThenInclude(m => m.Persoon)
				.Include(gr => gr.Deelnemers)
					.ThenInclude(d => d.Kind)
				.Include(gr => gr.Programmas)
					.ThenInclude(p => p.Activiteit)
				.ToListAsync();
		}

	}
}
