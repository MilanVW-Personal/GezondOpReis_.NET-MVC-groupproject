namespace GezondOpReis.Data.UnitOfWork
{
    public interface IUnitOfWork
    {

    IBestemmingRepo BestemmingRepo { get; }
    IActiviteitenRepo ActiviteitenRepo { get; }
		IGroepsReisRepository GroepsReisRepository { get; }

		public Task SaveChangesAsync();
    }
}
