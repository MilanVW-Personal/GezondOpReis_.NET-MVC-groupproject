namespace GezondOpReis.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        IBestemmingRepo BestemmingRepo { get; }
        IActiviteitenRepo ActiviteitenRepo { get; }

        public Task SaveChangesAsync();
    }
}
