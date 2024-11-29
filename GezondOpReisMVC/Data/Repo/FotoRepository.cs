using GezondOpReis.Models;

namespace GezondOpReis.Data.Repo
{
    public class FotoRepository : GenericRepository<Foto>, IFotoRepo
    {
        public FotoRepository(GezondOpReisContext context) : base(context)
        {
            
        }
    }
}
