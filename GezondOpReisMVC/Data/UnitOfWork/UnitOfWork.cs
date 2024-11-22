namespace GezondOpReis.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GezondOpReisContext _context;

        //private IEventRepo eventRepo;
        //private IInschrijvingRepo inschrijvingRepo;
        //private ICommunityRepo communityRepo;
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


	  //  public ICommunityRepo CommunityRepo
	  //  {
	  //      get 
	  //      {
	  //          return communityRepo ??= new CommunityRepo(_context);
	  //}
	  //  }

			//  public IEventRepo EventRepo
			//  {
			//      get
			//      {
			//          return eventRepo ??= new EventRepo(_context);
			//      }
			//  }

			//  public IInschrijvingRepo InschrijvingRepo
			//  {
			//      get
			//      {
			//          return inschrijvingRepo ??= new InschrijvingRepo(_context);
			//      }
			//  }

		public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
