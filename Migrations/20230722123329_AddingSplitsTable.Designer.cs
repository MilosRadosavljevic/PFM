﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PFM.Database;

#nullable disable

namespace PFM.Migrations
{
    [DbContext(typeof(PfmDbContext))]
    [Migration("20230722123329_AddingSplitsTable")]
    partial class AddingSplitsTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PFM.Database.Entities.CategoryEntity", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<string>("ParentCode")
                        .HasColumnType("text");

                    b.HasKey("Code");

                    b.ToTable("categories", (string)null);
                });

            modelBuilder.Entity("PFM.Database.Entities.TransactionEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<double>("Amount")
                        .HasColumnType("double precision");

                    b.Property<string>("BeneficiaryName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("character varying(1024)");

                    b.Property<string>("Direction")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Kind")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MccCode")
                        .HasColumnType("text");

                    b.Property<string>("catCode")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("catCode");

                    b.ToTable("transactions", (string)null);
                });

            modelBuilder.Entity("PFM.Database.Entities.TransactionSplitEntity", b =>
                {
                    b.Property<string>("TransactionId")
                        .HasColumnType("text");

                    b.Property<string>("CategoryCode")
                        .HasColumnType("text");

                    b.Property<double>("Amount")
                        .HasColumnType("double precision");

                    b.HasKey("TransactionId", "CategoryCode");

                    b.HasIndex("CategoryCode");

                    b.ToTable("transaction-splits", (string)null);
                });

            modelBuilder.Entity("PFM.Database.Entities.TransactionEntity", b =>
                {
                    b.HasOne("PFM.Database.Entities.CategoryEntity", "Category")
                        .WithMany()
                        .HasForeignKey("catCode");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("PFM.Database.Entities.TransactionSplitEntity", b =>
                {
                    b.HasOne("PFM.Database.Entities.CategoryEntity", "Category")
                        .WithMany("Splits")
                        .HasForeignKey("CategoryCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PFM.Database.Entities.TransactionEntity", "Transaction")
                        .WithMany("Splits")
                        .HasForeignKey("TransactionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Transaction");
                });

            modelBuilder.Entity("PFM.Database.Entities.CategoryEntity", b =>
                {
                    b.Navigation("Splits");
                });

            modelBuilder.Entity("PFM.Database.Entities.TransactionEntity", b =>
                {
                    b.Navigation("Splits");
                });
#pragma warning restore 612, 618
        }
    }
}
