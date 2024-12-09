using GezondOpReis.Models;

namespace GezondOpReis.Data.Repo
{
    public interface IGroepsReisRepository: IGenericRepository<Groepsreis>
    {
        Task<IEnumerable<Groepsreis>> GetAllGroepsReizenAsync();

        Task<Groepsreis> GetGroepsReizenWithIdAsync(int id);
        Task<Groepsreis> GetGroepReizenForDelete(int id);
        Task<IEnumerable<Groepsreis>> GetIngeschrevenGroepsreizen(string persoonId);

    }
}
