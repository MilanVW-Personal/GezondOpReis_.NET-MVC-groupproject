using GezondOpReis.Models;

namespace GezondOpReis.Data.Repo
{
    public class OnkostenRepository: GenericRepository<Onkosten>, IOnkostenRepository
    {
        public OnkostenRepository(GezondOpReisContext context) : base(context)
        {

        }
    }
}
