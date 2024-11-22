using GezondOpReis.Models;

namespace GezondOpReis.Data.Repo
{
    public class ActiviteitenRepo : GenericRepository<Activiteit>, IActiviteitenRepo
    {
        public ActiviteitenRepo(GezondOpReisContext context) : base(context)
        {
            
        }


    }
}
