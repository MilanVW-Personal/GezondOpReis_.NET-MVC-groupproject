using GezondOpReis.Models;

namespace GezondOpReis.Data.Repo
{
    public interface IGebruikerRepo : IGenericRepository<CustomUser>
    {
        Task<CustomUser> GetUserById(string id);
    }
}
