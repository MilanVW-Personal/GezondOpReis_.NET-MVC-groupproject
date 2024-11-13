using Microsoft.EntityFrameworkCore;

namespace GezondOpReis.Data.Context
{
    public class GezondOpReisContext : DbContext
    {
        public GezondOpReisContext(DbContextOptions<GezondOpReisContext> options) : base(options) { }
    }
}

