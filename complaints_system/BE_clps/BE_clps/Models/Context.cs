using Microsoft.EntityFrameworkCore;

namespace BE_clps.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Complainant> Complainants { get; set; }
        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<Subjct> Subjcts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Complainant>()
                .HasKey(cnant => new { cnant.ComplainatId });

            modelBuilder.Entity<Complaint>()
                .HasKey(c => new { c.ComplaintId });

            modelBuilder.Entity<Subjct>()
                .HasKey(s => new { s.SubjctId });

            modelBuilder.Entity<Complainant>()
                .HasMany(cnant => cnant.Complaints)
                .WithOne(c => c.Complainant)
                .HasForeignKey(c => c.CnantRIF);

            modelBuilder.Entity<Subjct>()
                .HasMany(cnant => cnant.Complaints)
                .WithOne(c => c.Subject)
                .HasForeignKey(s => s.SubRIF);
        }
    }
}
