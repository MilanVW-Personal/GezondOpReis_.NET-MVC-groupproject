using GezondOpReis.Models;
using GezondOpReis.Models;
namespace GezondOpReis.Data.Repo
{
    public class OpleidingPersoonRepo : GenericRepository<OpleidingPersoon>, IOpleidingPersoonRepo
    {
        public OpleidingPersoonRepo(GezondOpReisContext context) : base(context)
        {
            
        }
    }
}
