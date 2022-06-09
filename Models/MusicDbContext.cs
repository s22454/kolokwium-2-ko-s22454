using Microsoft.EntityFrameworkCore;

namespace kolokwium_2_ko_s22454.Models
{
    public class MusicDbContext : DbContext
    {
        public DbSet<Musican> Musicans { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<MusicLabel> MusicLabels { get; set; }
        public DbSet<Musican_Track> MusicanTracks { get; set; }

        public MusicDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Musican>(e =>
            {
                e.HasKey(e => e.IdMusican);
                e.Property(e => e.FirstName).HasMaxLength(30).IsRequired();
                e.Property(e => e.LastName).HasMaxLength(50).IsRequired();
                e.Property(e => e.NickName).HasMaxLength(20).IsRequired();
                
                e.ToTable("Musican");
            });
            
            modelBuilder.Entity<Musican_Track>(e =>
            {
                e.HasKey(e => new {e.IdMusician, e.IdTrack});

                e.HasOne(e => e.Musican)
                    .WithMany(e => e.MusicanTracks)
                    .HasForeignKey(e => e.IdMusician)
                    .OnDelete(DeleteBehavior.Cascade);

                e.HasOne(e => e.Track)
                    .WithMany(e => e.MusicanTracks)
                    .HasForeignKey(e => e.IdTrack)
                    .OnDelete(DeleteBehavior.Cascade);

                e.ToTable("Musican_Track");
            });
            
            modelBuilder.Entity<Track>(e =>
            {
                e.HasKey(e => e.IdTrack);
                e.Property(e => e.TrackName).HasMaxLength(20).IsRequired();
                e.Property(e => e.Duraturation).IsRequired();
                
                e.ToTable("Track");
            });
            
            modelBuilder.Entity<Album>(e =>
            {
                e.HasKey(e => e.IdAlbum);
                e.Property(e => e.AlbumName).HasMaxLength(30).IsRequired();
                e.Property(e => e.PublishDate).IsRequired();
                e.Property(e => e.IdMusicLabel).IsRequired();
                
                e.ToTable("Album");
            });
            
            modelBuilder.Entity<MusicLabel>(e =>
            {
                e.HasKey(e => e.IdMusicLabel);
                e.Property(e => e.Name).HasMaxLength(50).IsRequired();
                
                e.ToTable("MusicLabel");
            });
        }
    }
}