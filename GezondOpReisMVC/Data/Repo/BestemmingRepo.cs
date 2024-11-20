using GezondOpReis.Models;

namespace GezondOpReis.Data.Repo
{
    public class BestemmingRepo : GenericRepository<Bestemming>, IBestemmingRepo
    {
        public BestemmingRepo(GezondOpReisContext context) : base(context)
        {
            
        }
    }
}
