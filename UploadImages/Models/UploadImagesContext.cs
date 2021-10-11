using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using UploadImages.Settings;
using EntityFramework.Exceptions.SqlServer;

#nullable disable

namespace UploadImages.Models
{
    public partial class UploadImagesContext : DbContext
    {
        private readonly UploadImagesSettings _settings;
        private readonly IConfiguration _configuration; 
        public UploadImagesContext(DbContextOptions<UploadImagesContext> options,
            IOptions<UploadImagesSettings> settings, IConfiguration configuration) : base(options)
        {
            _settings = settings.Value;
            _configuration = configuration;
        }

        public UploadImagesContext(DbContextOptions<UploadImagesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies()
                     .UseSqlServer(
                         _configuration.GetConnectionString("UploadImagesDb"),
                         options => options.CommandTimeout(_settings.CommandTimeout)
                     )
                     .UseExceptionProcessor();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.HasIndex(e => new { e.Id, e.Name }, "Idx_Account")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.Content).IsUnicode(false);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatorName)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.CreatorId)
                    .HasConstraintName("FK__Comments__Creato__73BA3083");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("FK__Comments__PostId__72C60C4A");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.Property(e => e.Caption)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatorName)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Image).IsRequired();

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.CreatorId)
                    .HasConstraintName("FK__Posts__CreatorId__6FE99F9F");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
