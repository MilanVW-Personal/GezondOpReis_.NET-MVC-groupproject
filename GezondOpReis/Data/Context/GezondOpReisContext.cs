using GezondOpReis.Models;

namespace GezondOpReis.Data.Context
{
    public class GezondOpReisContext : IdentityDbContext<CustomUser>
	{
		public GezondOpReisContext(DbContextOptions<GezondOpReisContext> options): base(options) {}

		public DbSet<Activiteit> Activiteiten { get; set; }
		public DbSet<Onkosten> Onkosten { get; set; }
		public DbSet<Programma> Programma { get; set; }
		public DbSet<Bestemming> Bestemmingen { get; set; }
		public DbSet<Foto> Foto { get; set; }
		public DbSet<Groepsreis> Groepsreizen { get; set; }
		public DbSet<Deelnemer> Deelnemers { get; set; }
		public DbSet<Models.Monitor> Monitors { get; set; }
		public DbSet<Kind> Kinderen { get; set; }
		public DbSet<Review> Reviews { get; set; }
		public DbSet<Opleiding> Opleidingen { get; set; }
		public DbSet<OpleidingPersoon> OpleidingPersonen { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Activiteit>().ToTable("Activiteit");
			modelBuilder.Entity<Onkosten>().ToTable("Onkosten");
			modelBuilder.Entity<Programma>().ToTable("Programma");
			modelBuilder.Entity<Bestemming>().ToTable("Bestemming");
			modelBuilder.Entity<Foto>().ToTable("Foto");
			modelBuilder.Entity<Groepsreis>().ToTable("Groepsreis");
			modelBuilder.Entity<Deelnemer>().ToTable("Deelnemer");
			modelBuilder.Entity<Models.Monitor>().ToTable("Monitor");
			modelBuilder.Entity<Kind>().ToTable("Kind");
			modelBuilder.Entity<Review>().ToTable("Review");
			modelBuilder.Entity<Opleiding>().ToTable("Opleiding");
			modelBuilder.Entity<OpleidingPersoon>().ToTable("OpleidingPersoon");

			// Relations
			modelBuilder.Entity<Programma>()
				.HasOne(p => p.Activiteit)
				.WithMany(a => a.Programmas)
				.HasForeignKey(p => p.ActiviteidId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Programma>()
				.HasOne(p => p.Groepsreis)
				.WithMany(gr => gr.Programmas)
				.HasForeignKey(p => p.GroepsreisId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Groepsreis>()
				.HasOne(gr => gr.Bestemming)
				.WithMany(b => b.Groepsreizen)
				.HasForeignKey(gr => gr.BestemmingId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Foto>()
				.HasOne(f => f.Bestemming)
				.WithMany(b => b.Fotos)
				.HasForeignKey(f => f.BestemmingId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Deelnemer>()
				.HasOne(d => d.Kind)
				.WithMany(k => k.Deelnemers)
				.HasForeignKey(d => d.KindId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Deelnemer>()
				.HasOne(d => d.Groepsreis)
				.WithMany(gr => gr.Deelnemers)
				.HasForeignKey(d => d.GroepsreisId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity< Models.Monitor> ()
				.HasOne(m => m.Groepsreis)
				.WithMany(gr => gr.Monitoren)
				.HasForeignKey(m => m.GroepsreisId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Review>()
				.HasOne(r => r.Bestemming)
				.WithMany(b => b.Reviews)
				.HasForeignKey(r => r.BestemmingId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Review>()
				.HasOne(r => r.Persoon)
				.WithMany(u => u.Reviews)
				.HasForeignKey(r => r.PersoonId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<OpleidingPersoon>()
				.HasKey(op => new { op.OpleidingId, op.PersoonId });

			modelBuilder.Entity<OpleidingPersoon>()
				.HasOne(op => op.Opleiding)
				.WithMany(o => o.OpleidingPersonen)
				.HasForeignKey(op => op.OpleidingId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<OpleidingPersoon>()
				.HasOne(op => op.Persoon)
				.WithMany(u => u.OpleidingPersonen)
				.HasForeignKey(op => op.PersoonId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}


