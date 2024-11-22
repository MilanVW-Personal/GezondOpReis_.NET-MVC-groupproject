namespace GezondOpReis.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
		// ICommunityRepo CommunityRepo { get; }
		// IEventRepo EventRepo { get; }
		// IInschrijvingRepo InschrijvingRepo { get; }
		IGroepsReisRepository GroepsReisRepository { get; }

		public Task SaveChangesAsync();
    }
}
