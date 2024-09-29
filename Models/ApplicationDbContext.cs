using Microsoft.EntityFrameworkCore;
using ProductDosageApp.Models;

namespace ProductDosageApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Produkt> Produkts { get; set; }
        public DbSet<Dosage> Dosages { get; set; }
        public DbSet<Bestandteil> Bestandteile { get; set; }
        public DbSet<ProduktDosage> ProduktDosages { get; set; }
        public DbSet<DosageBestandteil> DosageBestandteile { get; set; }

        public DbSet<ProduktConfiguration> ProduktConfigurations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProduktDosage>()
                .HasOne(pd => pd.Produkt)
                .WithMany(p => p.ProduktDosages)
                .HasForeignKey(pd => pd.ProduktID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProduktDosage>()
                .HasOne(pd => pd.Dosage)
                .WithMany(d => d.ProduktDosages)
                .HasForeignKey(pd => pd.DosageID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DosageBestandteil>()
                .HasOne(db => db.Dosage)
                .WithMany(d => d.DosageBestandteile)
                .HasForeignKey(db => db.DosageID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DosageBestandteil>()
                .HasOne(db => db.Bestandteil)
                .WithMany()
                .HasForeignKey(db => db.BestandteilID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

