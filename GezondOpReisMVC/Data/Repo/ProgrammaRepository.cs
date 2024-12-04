using GezondOpReis.Models;

namespace GezondOpReis.Data.Repo
{
    public class ProgrammaRepository : GenericRepository<Programma>, IProgrammaRepository
    {
        public ProgrammaRepository(GezondOpReisContext context) : base(context)
        {

        }
    }
}
