namespace GezondOpReis.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GezondOpReisContext _context;


    private IBestemmingRepo bestemmingRepo;
    private IActiviteitenRepo activiteitenRepo;
		private IGroepsReisRepository groepsReisRepository;

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


		public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
