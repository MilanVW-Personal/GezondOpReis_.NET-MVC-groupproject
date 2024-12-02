namespace GezondOpReis.Data.UnitOfWork
{
    public interface IUnitOfWork
    {

        IBestemmingRepo BestemmingRepo { get; }
        IActiviteitenRepo ActiviteitenRepo { get; }
        IGroepsReisRepository GroepsReisRepository { get; }
        IFotoRepo FotoRepo { get; }
        IReviewRepo ReviewRepo { get;}

        IKindRepo KindRepo { get; }
        IGebruikerRepo GebruikerRepo { get; }

		public Task SaveChangesAsync();
    }
}
