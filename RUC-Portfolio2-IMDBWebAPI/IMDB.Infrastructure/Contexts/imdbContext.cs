using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Context
{
    public partial class imdbContext : DbContext
    {
        public imdbContext()
        {
        }

        public imdbContext(DbContextOptions<imdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Director> Directors { get; set; } = null!;
        public virtual DbSet<Genre> Genres { get; set; } = null!;
        public virtual DbSet<Knownfortitle> Knownfortitles { get; set; } = null!;
        public virtual DbSet<NameBasic> NameBasics { get; set; } = null!;
        public virtual DbSet<NamesBookmarking> NamesBookmarkings { get; set; } = null!;
        public virtual DbSet<OmdbDatum> OmdbData { get; set; } = null!;
        public virtual DbSet<RatingsHistory> RatingsHistories { get; set; } = null!;
        public virtual DbSet<SearchDetail> SearchDetails { get; set; } = null!;
        public virtual DbSet<SearchHistory> SearchHistories { get; set; } = null!;
        public virtual DbSet<TitleAka> TitleAkas { get; set; } = null!;
        public virtual DbSet<TitleBasic> TitleBasics { get; set; } = null!;
        public virtual DbSet<TitleBookmarking> TitleBookmarkings { get; set; } = null!;
        public virtual DbSet<TitleCrew> TitleCrews { get; set; } = null!;
        public virtual DbSet<TitleEpisode> TitleEpisodes { get; set; } = null!;
        public virtual DbSet<TitlePrincipal> TitlePrincipals { get; set; } = null!;
        public virtual DbSet<TitleRating> TitleRatings { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Wi> Wis { get; set; } = null!;
        public virtual DbSet<Writer> Writers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Director>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("directors");

                entity.Property(e => e.Nconst)
                    .HasMaxLength(10)
                    .HasColumnName("nconst");

                entity.Property(e => e.Tconst)
                    .HasMaxLength(10)
                    .HasColumnName("tconst");

                entity.HasOne(d => d.NconstNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Nconst)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("directors_nconst_fkey");

                entity.HasOne(d => d.TconstNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Tconst)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("directors_tconst_fkey");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("genres");

                entity.Property(e => e.Genre1)
                    .HasMaxLength(256)
                    .HasColumnName("genre");

                entity.Property(e => e.Tconst)
                    .HasMaxLength(10)
                    .HasColumnName("tconst");

                entity.HasOne(d => d.TconstNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Tconst)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("genres_tconst_fkey");
            });

            modelBuilder.Entity<Knownfortitle>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("knownfortitles");

                entity.Property(e => e.Nconst)
                    .HasMaxLength(10)
                    .HasColumnName("nconst");

                entity.Property(e => e.Tconst)
                    .HasMaxLength(10)
                    .HasColumnName("tconst");

                entity.HasOne(d => d.NconstNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Nconst)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("knownfortitles_nconst_fkey");

                entity.HasOne(d => d.TconstNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Tconst)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("knownfortitles_tconst_fkey");
            });

            modelBuilder.Entity<NameBasic>(entity =>
            {
                entity.HasKey(e => e.Nconst)
                    .HasName("name_basics_pkey");

                entity.ToTable("name_basics");

                entity.Property(e => e.Nconst)
                    .HasMaxLength(10)
                    .HasColumnName("nconst")
                    .IsFixedLength();

                entity.Property(e => e.Birthyear)
                    .HasMaxLength(4)
                    .HasColumnName("birthyear")
                    .IsFixedLength();

                entity.Property(e => e.Deathyear)
                    .HasMaxLength(4)
                    .HasColumnName("deathyear")
                    .IsFixedLength();

                entity.Property(e => e.Primaryname)
                    .HasMaxLength(256)
                    .HasColumnName("primaryname");

                entity.Property(e => e.Primaryprofession)
                    .HasMaxLength(256)
                    .HasColumnName("primaryprofession");
            });

            modelBuilder.Entity<NamesBookmarking>(entity =>
            {
                entity.HasKey(e => e.Nconst)
                    .HasName("names_bookmarking_pkey");

                entity.ToTable("names_bookmarking");

                entity.Property(e => e.Nconst).HasColumnName("nconst");

                entity.Property(e => e.Namesdate).HasColumnName("namesdate");

                entity.Property(e => e.Uconst).HasColumnName("uconst");

                entity.HasOne(d => d.NconstNavigation)
                    .WithOne(p => p.NamesBookmarking)
                    .HasForeignKey<NamesBookmarking>(d => d.Nconst)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("names_bookmarking_nconst_fkey");

                entity.HasOne(d => d.UconstNavigation)
                    .WithMany(p => p.NamesBookmarkings)
                    .HasForeignKey(d => d.Uconst)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("names_bookmarking_uconst_fkey");
            });

            modelBuilder.Entity<OmdbDatum>(entity =>
            {
                entity.HasKey(e => e.Tconst)
                    .HasName("omdb_data_pkey");

                entity.ToTable("omdb_data");

                entity.Property(e => e.Tconst)
                    .HasMaxLength(10)
                    .HasColumnName("tconst")
                    .IsFixedLength();

                entity.Property(e => e.Awards).HasColumnName("awards");

                entity.Property(e => e.Plot).HasColumnName("plot");

                entity.Property(e => e.Poster)
                    .HasMaxLength(256)
                    .HasColumnName("poster");

                entity.HasOne(d => d.TconstNavigation)
                    .WithOne(p => p.OmdbDatum)
                    .HasForeignKey<OmdbDatum>(d => d.Tconst)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("omdb_data_tconst_fkey");
            });

            modelBuilder.Entity<RatingsHistory>(entity =>
            {
                entity.HasKey(e => e.Rconst)
                    .HasName("ratings_history_pkey");

                entity.ToTable("ratings_history");

                entity.Property(e => e.Rconst)
                    .HasColumnType("character varying")
                    .HasColumnName("rconst");

                entity.Property(e => e.Ratingsdate).HasColumnName("ratingsdate");

                entity.Property(e => e.Stars).HasColumnName("stars");

                entity.Property(e => e.Tconst)
                    .HasColumnType("character varying")
                    .HasColumnName("tconst");

                entity.Property(e => e.Uconst).HasColumnName("uconst");

                entity.HasOne(d => d.TconstNavigation)
                    .WithMany(p => p.RatingsHistories)
                    .HasForeignKey(d => d.Tconst)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ratings_history_tconst_fkey");

                entity.HasOne(d => d.UconstNavigation)
                    .WithMany(p => p.RatingsHistories)
                    .HasForeignKey(d => d.Uconst)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ratings_history_uconst_fkey");
            });

            modelBuilder.Entity<SearchDetail>(entity =>
            {
                entity.HasKey(e => e.Sconst)
                    .HasName("search_details_pkey");

                entity.ToTable("search_details");

                entity.Property(e => e.Sconst)
                    .HasColumnType("character varying")
                    .HasColumnName("sconst");

                entity.Property(e => e.ActorName)
                    .HasColumnType("character varying")
                    .HasColumnName("actor_name");

                entity.Property(e => e.Character)
                    .HasColumnType("character varying")
                    .HasColumnName("character");

                entity.Property(e => e.PlotText)
                    .HasColumnType("character varying")
                    .HasColumnName("plot_text");

                entity.Property(e => e.Title)
                    .HasColumnType("character varying")
                    .HasColumnName("title");

                entity.HasOne(d => d.SconstNavigation)
                    .WithOne(p => p.SearchDetail)
                    .HasForeignKey<SearchDetail>(d => d.Sconst)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("search_details_sconst_fkey");
            });

            modelBuilder.Entity<SearchHistory>(entity =>
            {
                entity.HasKey(e => e.Sconst)
                    .HasName("search_history_pkey");

                entity.ToTable("search_history");

                entity.Property(e => e.Sconst).HasColumnName("sconst");

                entity.Property(e => e.SearchText).HasColumnName("search_text");

                entity.Property(e => e.Searchdate).HasColumnName("searchdate");

                entity.Property(e => e.Uconst).HasColumnName("uconst");

                entity.HasOne(d => d.UconstNavigation)
                    .WithMany(p => p.SearchHistories)
                    .HasForeignKey(d => d.Uconst)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("search_history_uconst_fkey");
            });

            modelBuilder.Entity<TitleAka>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("title_akas");

                entity.Property(e => e.Attributes)
                    .HasMaxLength(256)
                    .HasColumnName("attributes");

                entity.Property(e => e.Isoriginaltitle).HasColumnName("isoriginaltitle");

                entity.Property(e => e.Language)
                    .HasMaxLength(10)
                    .HasColumnName("language");

                entity.Property(e => e.Ordering).HasColumnName("ordering");

                entity.Property(e => e.Region)
                    .HasMaxLength(10)
                    .HasColumnName("region");

                entity.Property(e => e.Title).HasColumnName("title");

                entity.Property(e => e.Titleid)
                    .HasMaxLength(10)
                    .HasColumnName("titleid")
                    .IsFixedLength();

                entity.Property(e => e.Types)
                    .HasMaxLength(256)
                    .HasColumnName("types");

                entity.HasOne(d => d.TitleNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Titleid)
                    .HasConstraintName("title_akas_titleid_fkey");
            });

            modelBuilder.Entity<TitleBasic>(entity =>
            {
                entity.HasKey(e => e.Tconst)
                    .HasName("title_basics_pkey");

                entity.ToTable("title_basics");

                entity.Property(e => e.Tconst)
                    .HasMaxLength(10)
                    .HasColumnName("tconst")
                    .IsFixedLength();

                entity.Property(e => e.Endyear)
                    .HasMaxLength(4)
                    .HasColumnName("endyear")
                    .IsFixedLength();

                entity.Property(e => e.Isadult).HasColumnName("isadult");

                entity.Property(e => e.Originaltitle).HasColumnName("originaltitle");

                entity.Property(e => e.Primarytitle).HasColumnName("primarytitle");

                entity.Property(e => e.Runtimeminutes).HasColumnName("runtimeminutes");

                entity.Property(e => e.Startyear)
                    .HasMaxLength(4)
                    .HasColumnName("startyear")
                    .IsFixedLength();

                entity.Property(e => e.Titletype)
                    .HasMaxLength(20)
                    .HasColumnName("titletype");
            });

            modelBuilder.Entity<TitleBookmarking>(entity =>
            {
                entity.HasKey(e => e.Tconst)
                    .HasName("title_bookmarkings_pkey");

                entity.ToTable("title_bookmarkings");

                entity.Property(e => e.Tconst).HasColumnName("tconst");

                entity.Property(e => e.Titledate).HasColumnName("titledate");

                entity.Property(e => e.Uconst).HasColumnName("uconst");

                entity.HasOne(d => d.TconstNavigation)
                    .WithOne(p => p.TitleBookmarking)
                    .HasForeignKey<TitleBookmarking>(d => d.Tconst)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("title_bookmarkings_tconst_fkey");

                entity.HasOne(d => d.UconstNavigation)
                    .WithMany(p => p.TitleBookmarkings)
                    .HasForeignKey(d => d.Uconst)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("title_bookmarkings_uconst_fkey");
            });

            modelBuilder.Entity<TitleCrew>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("title_crew");

                entity.Property(e => e.Directors).HasColumnName("directors");

                entity.Property(e => e.Tconst)
                    .HasMaxLength(10)
                    .HasColumnName("tconst")
                    .IsFixedLength();

                entity.Property(e => e.Writers).HasColumnName("writers");
            });

            modelBuilder.Entity<TitleEpisode>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("title_episode");

                entity.Property(e => e.Episodenumber).HasColumnName("episodenumber");

                entity.Property(e => e.Parenttconst)
                    .HasMaxLength(10)
                    .HasColumnName("parenttconst")
                    .IsFixedLength();

                entity.Property(e => e.Seasonnumber).HasColumnName("seasonnumber");

                entity.Property(e => e.Tconst)
                    .HasMaxLength(10)
                    .HasColumnName("tconst")
                    .IsFixedLength();

                entity.HasOne(d => d.TconstNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Tconst)
                    .HasConstraintName("title_episode_tconst_fkey");
            });

            modelBuilder.Entity<TitlePrincipal>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("title_principals");

                entity.Property(e => e.Category)
                    .HasMaxLength(50)
                    .HasColumnName("category");

                entity.Property(e => e.Characters).HasColumnName("characters");

                entity.Property(e => e.Job).HasColumnName("job");

                entity.Property(e => e.Nconst)
                    .HasMaxLength(10)
                    .HasColumnName("nconst")
                    .IsFixedLength();

                entity.Property(e => e.Ordering).HasColumnName("ordering");

                entity.Property(e => e.Tconst)
                    .HasMaxLength(10)
                    .HasColumnName("tconst")
                    .IsFixedLength();

                entity.HasOne(d => d.TconstNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Tconst)
                    .HasConstraintName("title_principals_tconst_fkey");
            });

            modelBuilder.Entity<TitleRating>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("title_ratings");

                entity.Property(e => e.Averagerating)
                    .HasPrecision(5, 1)
                    .HasColumnName("averagerating");

                entity.Property(e => e.Numvotes).HasColumnName("numvotes");

                entity.Property(e => e.Tconst)
                    .HasMaxLength(10)
                    .HasColumnName("tconst")
                    .IsFixedLength();

                entity.HasOne(d => d.TconstNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Tconst)
                    .HasConstraintName("title_ratings_tconst_fkey");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Uconst)
                    .HasName("users_pkey");

                entity.ToTable("users");

                entity.Property(e => e.Uconst).HasColumnName("uconst");

                entity.Property(e => e.Password).HasColumnName("password");

                entity.Property(e => e.Username).HasColumnName("username");
            });

            modelBuilder.Entity<Wi>(entity =>
            {
                entity.HasKey(e => new { e.Tconst, e.Word, e.Field })
                    .HasName("wi_pkey");

                entity.ToTable("wi");

                entity.Property(e => e.Tconst)
                    .HasMaxLength(10)
                    .HasColumnName("tconst")
                    .IsFixedLength();

                entity.Property(e => e.Word).HasColumnName("word");

                entity.Property(e => e.Field)
                    .HasMaxLength(1)
                    .HasColumnName("field");

                entity.Property(e => e.Lexeme).HasColumnName("lexeme");
            });

            modelBuilder.Entity<Writer>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("writers");

                entity.Property(e => e.Nconst)
                    .HasMaxLength(10)
                    .HasColumnName("nconst");

                entity.Property(e => e.Tconst)
                    .HasMaxLength(10)
                    .HasColumnName("tconst");

                entity.HasOne(d => d.NconstNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Nconst)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("writers_nconst_fkey");

                entity.HasOne(d => d.TconstNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Tconst)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("writers_tconst_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
