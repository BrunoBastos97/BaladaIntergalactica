using BaladaIntergalactica.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace BaladaIntergalactica.API.Persistence
{
    public class IntergalacticBalladDbContext : DbContext
    {
        public IntergalacticBalladDbContext(DbContextOptions<IntergalacticBalladDbContext> options) : base (options)
        {
        }

        public DbSet<Alien> Aliens { get; set; }

        public DbSet<Ballad> Ballads { get; set; }

        public DbSet<ObjectNotAllowed> ObjectNotAllowed { get; set; }

        public DbSet<CheckInCheckOut> CheckInCheckOuts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alien>().ToTable("Alien");
            modelBuilder.Entity<Alien>().HasKey(e => e.Id);
            modelBuilder.Entity<Alien>().Property(e => e.Name).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Alien>().Property(e => e.DateOfBirth);
            modelBuilder.Entity<Alien>().Property(e => e.Banned);

            modelBuilder.Entity<Ballad>().ToTable("Balada");
            modelBuilder.Entity<Ballad>().HasKey(e => e.Id);
            modelBuilder.Entity<Ballad>().Property(e => e.Name).HasMaxLength(100).IsRequired();

            modelBuilder.Entity<ObjectNotAllowed>().ToTable("ObjetoProibido");
            modelBuilder.Entity<ObjectNotAllowed>().HasKey(e => e.Id);
            modelBuilder.Entity<ObjectNotAllowed>().Property(e => e.Name).HasMaxLength(100).IsRequired();

            modelBuilder.Entity<CheckInCheckOut>().ToTable("CheckinCheckout");
            modelBuilder.Entity<CheckInCheckOut>().HasKey(e => e.Id);
            modelBuilder.Entity<CheckInCheckOut>().HasOne(e => e.Alien).WithMany().HasForeignKey(e => e.IdAlien);
            modelBuilder.Entity<CheckInCheckOut>().HasOne(e => e.Ballad).WithMany().HasForeignKey(e => e.IdBallad);
            modelBuilder.Entity<CheckInCheckOut>().HasOne(e => e.ObjectNotAllowed).WithMany().HasForeignKey(e => e.IdObjectNotAllowed).IsRequired(false);
            modelBuilder.Entity<CheckInCheckOut>().Property(e => e.DateTimeEntry);
            modelBuilder.Entity<CheckInCheckOut>().Property(e => e.DateTimeExit).IsRequired(false);
        }
    }
}
