using GezondOpReis.Models;

namespace GezondOpReis.Data.Repo
{
    public class OpleidingRepo : GenericRepository<Opleiding>, IOpleidingRepo
    {
        public OpleidingRepo(GezondOpReisContext context) : base(context)
        {
            
        }
    }
}
