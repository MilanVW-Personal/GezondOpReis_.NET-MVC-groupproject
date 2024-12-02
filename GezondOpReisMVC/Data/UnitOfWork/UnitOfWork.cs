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
        private IKindRepo kindRepo;
        private IGebruikerRepo gebruikerRepo;

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

        public IKindRepo KindRepo
        {
            get
            {
                return kindRepo ??= new KindRepo(_context);
            }
        }

        public IGebruikerRepo GebruikerRepo
        {
            get
            {
                return gebruikerRepo ??= new GebruikerRepo(_context);
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
