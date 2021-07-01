using JWS.Data.Entities;
using JWS.EntityFramework.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JWS.Data
{
    public class ApplicationContext : DbContext, IApplicationDbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        #region Tables
        public virtual DbSet<AssetEntity> Assets { get; set; }
        public virtual DbSet<FundEntity> Funds { get; set; }
        public virtual DbSet<FundHistoryEntity> FundHistories { get; set; }
        public virtual DbSet<UserEntity> Users { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AssetEntity>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(p => p.Type).HasConversion(new EnumToStringConverter<AssetType>());
            });

            builder.Entity<FundEntity>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            builder.Entity<FundHistoryEntity>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(e => e.Fund)
                      .WithMany(e => e.FundHistories)
                      .HasForeignKey(e => e.FundId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<UserEntity>(entity =>
            {
                entity.HasKey(e => e.Id);
            });
        }
    }
}
