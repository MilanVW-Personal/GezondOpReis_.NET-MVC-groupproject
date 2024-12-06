using GezondOpReis.Data.Repo;

namespace GezondOpReis.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGroepsReisRepository GroepsReisRepository { get; }
        IBestemmingRepo BestemmingRepo { get; }
        IActiviteitenRepo ActiviteitenRepo { get; }
        IFotoRepo FotoRepo { get; }


        
        IGebruikerRepo GebruikerRepo { get; }


        IReviewRepo ReviewRepo { get; }
        IProgrammaRepository ProgrammaRepository { get; }
        IOnkostenRepository OnkostenRepository { get; }
        IDeelnemerRepository DeelnemerRepository { get; }
        IKindRepository KindRepository { get; }
        IOpleidingRepo OpleidingRepo { get; }
        IOpleidingPersoonRepo OpleidingPersoonRepo { get; }

        public Task SaveChangesAsync();

    }
}
