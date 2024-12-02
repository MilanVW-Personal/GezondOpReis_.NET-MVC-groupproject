using GezondOpReis.Models;

namespace GezondOpReis.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GezondOpReisContext _context;


    private IBestemmingRepo bestemmingRepo;
    private IActiviteitenRepo activiteitenRepo;
		private IGroepsReisRepository groepsReisRepository;
        private IFotoRepo fotoRepo;
        private IReviewRepo reviewRepo;
        private IOpleidingRepo opleidingRepo;
        private IOpleidingPersoonRepo opleidingPersoonRepo;

		public UnitOfWork(GezondOpReisContext context)

        {
            _context = context;
        }
        public IGroepsReisRepository GroepsReisRepository
		{
			get
			{
				return groepsReisRepository ??= new GroepsReisRepository(_context);
			}
		}


    public IBestemmingRepo BestemmingRepo
        {
            get
            {
                return bestemmingRepo ??= new BestemmingRepo(_context);
            }
        }

        public IActiviteitenRepo ActiviteitenRepo
        {
            get
            {
                return activiteitenRepo ??= new ActiviteitenRepo(_context);
            }
        }

        public IFotoRepo FotoRepo
        {
            get
            {
                return fotoRepo ??= new FotoRepository(_context);
            }
        }

        public IReviewRepo ReviewRepo
        {
            get
            {
                return reviewRepo ??= new ReviewRepo(_context);
            }
        }
        public IOpleidingRepo OpleidingRepo
        {
            get
            {
                return opleidingRepo ??= new OpleidingRepo(_context);
            }
        }
        public IOpleidingPersoonRepo OpleidingPersoonRepo
        {
            get
            {
                return opleidingPersoonRepo ??= new OpleidingPersoonRepo(_context);
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
