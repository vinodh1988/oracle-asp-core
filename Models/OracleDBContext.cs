using Microsoft.EntityFrameworkCore;

namespace OracleAPI.Models
{
    public class OracleDBContext : DbContext
    {
        public OracleDBContext() { }

        public OracleDBContext(DbContextOptions<OracleDBContext> options) : base(options) { }

        public DbSet<Person> people { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.HasDefaultSchema("HR");
            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.Sno).HasName("Pk_sno"); 
                entity.ToTable("PEOPLE","HR");
                entity.Property(e => e.Sno)
                .HasColumnName("sno")
                .HasColumnType("NUMBER(5)")
                .ValueGeneratedNever();

                entity.Property(e => e.Name)
               .HasColumnName("name")
               .HasMaxLength(30)
               .IsRequired();

                entity.Property(e => e.City)
               .HasColumnName("city")
               .HasMaxLength(30)
               .IsRequired();
            }
            )
            ;
        }
    }
}