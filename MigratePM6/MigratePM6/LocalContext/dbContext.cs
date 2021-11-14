using Microsoft.EntityFrameworkCore;

namespace MigratePM6
{
    public partial class dbContext : DbContext
    {
        private string _connectionString;
        public dbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public dbContext(DbContextOptions<dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pm6optChon300nosalt> Pm6optChon300nosalts { get; set; } = null!;
        public virtual DbSet<Test> Tests { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("dblink");

            modelBuilder.Entity<Pm6optChon300nosalt>(entity =>
            {
                entity.HasKey(e => new { e.Cid, e.State })
                    .HasName("pm6opt_chon300nosalt_pkey");

                entity.ToTable("pm6opt_chon300nosalt");

                entity.Property(e => e.Cid).HasColumnName("cid");

                entity.Property(e => e.State).HasColumnName("state");

                entity.Property(e => e.Data)
                    .HasColumnType("jsonb")
                    .HasColumnName("data");
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.HasKey(e => new { e.Cid, e.State })
                    .HasName("test_chon300nosalt_pkey");

                entity.ToTable("test");

                entity.Property(e => e.Cid).HasColumnName("cid");

                entity.Property(e => e.State).HasColumnName("state");

                entity.Property(e => e.Data)
                    .HasColumnType("jsonb")
                    .HasColumnName("data");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
