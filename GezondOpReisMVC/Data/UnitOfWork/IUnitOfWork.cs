namespace GezondOpReis.Data.UnitOfWork
{
    public interface IUnitOfWork
    {

        IBestemmingRepo BestemmingRepo { get; }
        IActiviteitenRepo ActiviteitenRepo { get; }
        IGroepsReisRepository GroepsReisRepository { get; }
        IFotoRepo FotoRepo { get; }
        IReviewRepo ReviewRepo { get;}

		public Task SaveChangesAsync();
    }
}
