﻿using JWS.Data.Entities;
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
        public virtual DbSet<FundCriteriaEntity> FundCriterias { get; set; }
        public virtual DbSet<FundEntity> Funds { get; set; }
        public virtual DbSet<FundHistoryEntity> FundHistories { get; set; }
        public virtual DbSet<FundInvestmentEntity> FundInvestments { get; set; }
        public virtual DbSet<FundInvestmentFundCriteriaEntity> FundInvestmentsFundCriterias { get; set; }
        public virtual DbSet<PostEntity> Posts { get; set; }
        public virtual DbSet<PostTagEntity> PostTags { get; set; }
        public virtual DbSet<TaskEntity> Tasks { get; set; }
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

            builder.Entity<FundCriteriaEntity>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(e => e.Fund)
                      .WithMany(e => e.Criterias)
                      .HasForeignKey(e => e.FundId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<FundEntity>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(p => p.Type).HasConversion(new EnumToStringConverter<FundType>());
            });

            builder.Entity<FundHistoryEntity>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(p => p.Type).HasConversion(new EnumToStringConverter<FundHistoryType>());

                entity.HasOne(e => e.Fund)
                      .WithMany(e => e.Histories)
                      .HasForeignKey(e => e.FundId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<FundInvestmentEntity>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(p => p.Status).HasConversion(new EnumToStringConverter<FundInvestmentStatus>());

                entity.Property(p => p.UpdateType).HasConversion(new EnumToStringConverter<FundInvestmentUpdateType>());

                entity.Property(p => p.RevenueCycle).HasConversion(new EnumToStringConverter<FundInvestmentRevenueCycle>());

                entity.HasOne(e => e.Fund)
                      .WithMany(e => e.Investments)
                      .HasForeignKey(e => e.FundId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<FundInvestmentFundCriteriaEntity>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasIndex(e => new { e.CriteriaId, e.InvestmentId });

                entity.HasOne(e => e.Criteria)
                      .WithMany(e => e.InvestmentCriterias)
                      .HasForeignKey(e => e.CriteriaId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Investment)
                      .WithMany(e => e.InvestmentCriterias)
                      .HasForeignKey(e => e.InvestmentId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<PostEntity>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(e => e.Parent)
                      .WithMany(e => e.Children)
                      .HasForeignKey(e => e.ParentId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<PostTagEntity>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasIndex(e => new { e.PostId, e.Tag });

                entity.HasOne(e => e.Post)
                      .WithMany(e => e.Tags)
                      .HasForeignKey(e => e.PostId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<TaskEntity>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            builder.Entity<UserEntity>(entity =>
            {
                entity.HasKey(e => e.Id);
            });
        }
    }
}
