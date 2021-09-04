﻿// <auto-generated />
using System;
using JWS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace JWS.Data.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("JWS.Data.Entities.AssetEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double>("Amount")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("At")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<string>("Note")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Assets");
                });

            modelBuilder.Entity("JWS.Data.Entities.FundCriteriaEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<Guid>("FundId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("FundId");

                    b.ToTable("FundCriterias");
                });

            modelBuilder.Entity("JWS.Data.Entities.FundEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Funds");
                });

            modelBuilder.Entity("JWS.Data.Entities.FundHistoryEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double>("Amount")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("At")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<Guid>("FundId")
                        .HasColumnType("uuid");

                    b.Property<string>("Note")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("FundId");

                    b.ToTable("FundHistories");
                });

            modelBuilder.Entity("JWS.Data.Entities.FundInvestmentEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Amount")
                        .HasColumnType("integer");

                    b.Property<double>("BuyFeePercent")
                        .HasColumnType("double precision");

                    b.Property<double>("CapitalPrice")
                        .HasColumnType("double precision");

                    b.Property<DateTime?>("CompletedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<double>("FinalProfit")
                        .HasColumnType("double precision");

                    b.Property<double>("FinalProfitPercent")
                        .HasColumnType("double precision");

                    b.Property<DateTime?>("FollowedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("FundId")
                        .HasColumnType("uuid");

                    b.Property<double>("HighestPrice")
                        .HasColumnType("double precision");

                    b.Property<DateTime?>("InvestedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<double>("MarketPrice")
                        .HasColumnType("double precision");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Note")
                        .HasColumnType("text");

                    b.Property<string>("RevenueCycle")
                        .HasColumnType("text");

                    b.Property<double?>("RevenuePercent")
                        .HasColumnType("double precision");

                    b.Property<double>("SellFeePercent")
                        .HasColumnType("double precision");

                    b.Property<double>("SellPrice")
                        .HasColumnType("double precision");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double?>("StopLossPercent")
                        .HasColumnType("double precision");

                    b.Property<double?>("TakeProfitPercent")
                        .HasColumnType("double precision");

                    b.Property<double>("TotalCapital")
                        .HasColumnType("double precision");

                    b.Property<double?>("TrailingStopLossPercent")
                        .HasColumnType("double precision");

                    b.Property<string>("UpdateType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("FundId");

                    b.ToTable("FundInvestments");
                });

            modelBuilder.Entity("JWS.Data.Entities.FundInvestmentFundCriteriaEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<Guid>("CriteriaId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("InvestmentId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("InvestmentId");

                    b.HasIndex("CriteriaId", "InvestmentId");

                    b.ToTable("FundInvestmentsFundCriterias");
                });

            modelBuilder.Entity("JWS.Data.Entities.PostEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AvaterUrl")
                        .HasColumnType("text");

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("JWS.Data.Entities.PostTagEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uuid");

                    b.Property<string>("Tag")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PostId", "Tag");

                    b.ToTable("PostTags");
                });

            modelBuilder.Entity("JWS.Data.Entities.TaskEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("At")
                        .HasColumnType("text");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsPriority")
                        .HasColumnType("boolean");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("JWS.Data.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<double?>("Income")
                        .HasColumnType("double precision");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("JWS.Data.Entities.FundCriteriaEntity", b =>
                {
                    b.HasOne("JWS.Data.Entities.FundEntity", "Fund")
                        .WithMany("Criterias")
                        .HasForeignKey("FundId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fund");
                });

            modelBuilder.Entity("JWS.Data.Entities.FundHistoryEntity", b =>
                {
                    b.HasOne("JWS.Data.Entities.FundEntity", "Fund")
                        .WithMany("Histories")
                        .HasForeignKey("FundId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fund");
                });

            modelBuilder.Entity("JWS.Data.Entities.FundInvestmentEntity", b =>
                {
                    b.HasOne("JWS.Data.Entities.FundEntity", "Fund")
                        .WithMany("Investments")
                        .HasForeignKey("FundId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fund");
                });

            modelBuilder.Entity("JWS.Data.Entities.FundInvestmentFundCriteriaEntity", b =>
                {
                    b.HasOne("JWS.Data.Entities.FundCriteriaEntity", "Criteria")
                        .WithMany("InvestmentCriterias")
                        .HasForeignKey("CriteriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JWS.Data.Entities.FundInvestmentEntity", "Investment")
                        .WithMany("InvestmentCriterias")
                        .HasForeignKey("InvestmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Criteria");

                    b.Navigation("Investment");
                });

            modelBuilder.Entity("JWS.Data.Entities.PostEntity", b =>
                {
                    b.HasOne("JWS.Data.Entities.PostEntity", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("JWS.Data.Entities.PostTagEntity", b =>
                {
                    b.HasOne("JWS.Data.Entities.PostEntity", "Post")
                        .WithMany("Tags")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");
                });

            modelBuilder.Entity("JWS.Data.Entities.FundCriteriaEntity", b =>
                {
                    b.Navigation("InvestmentCriterias");
                });

            modelBuilder.Entity("JWS.Data.Entities.FundEntity", b =>
                {
                    b.Navigation("Criterias");

                    b.Navigation("Histories");

                    b.Navigation("Investments");
                });

            modelBuilder.Entity("JWS.Data.Entities.FundInvestmentEntity", b =>
                {
                    b.Navigation("InvestmentCriterias");
                });

            modelBuilder.Entity("JWS.Data.Entities.PostEntity", b =>
                {
                    b.Navigation("Children");

                    b.Navigation("Tags");
                });
#pragma warning restore 612, 618
        }
    }
}
