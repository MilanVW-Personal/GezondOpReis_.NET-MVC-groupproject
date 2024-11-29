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

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
