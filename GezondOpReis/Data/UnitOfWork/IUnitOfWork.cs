namespace StartspelerAPI.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICommunityRepo CommunityRepo { get; }
	    IEventRepo EventRepo { get; }
        IInschrijvingRepo InschrijvingRepo { get; }

	    public Task SaveChangesAsync();
    }
}
