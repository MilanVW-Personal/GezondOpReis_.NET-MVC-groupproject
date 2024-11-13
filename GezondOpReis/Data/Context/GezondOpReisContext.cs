namespace GezondOpReis.Data.Context
{
    public class GezondOpReisContext : DbContext // Moet IdentityDbContext worden als identity gaat gebruikt worden
    {
        public GezondOpReisContext(DbContextOptions<GezondOpReisContext> options) : base(options) { }
    }
}

