using GezondOpReis.Models;

namespace GezondOpReis.Data.Repo
{
	public interface IGroepsReisRepository: IGenericRepository<Groepsreis>
	{
		Task<IEnumerable<Groepsreis>> GetAllGroepsReizenAsync();
	}
}
