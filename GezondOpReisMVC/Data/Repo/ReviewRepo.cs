using GezondOpReis.Models;

namespace GezondOpReis.Data.Repo
{
    public class ReviewRepo : GenericRepository<Review>, IReviewRepo
    {
        public ReviewRepo(GezondOpReisContext context) : base(context)
        {
            
        }
    }
}
