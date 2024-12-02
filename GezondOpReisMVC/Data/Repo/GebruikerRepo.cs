using GezondOpReis.Models;

namespace GezondOpReis.Data.Repo
{
    public class GebruikerRepo : GenericRepository<CustomUser>, IGebruikerRepo
    {
        public GebruikerRepo(GezondOpReisContext context) : base(context)
        {
            
        }

        public async Task<CustomUser> GetUserById(string id)
        { 
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
