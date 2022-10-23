﻿// <auto-generated />
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(FamilyDbContext))]
    [Migration("20221022190740_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Entities.Family", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(20,0)");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("Id"), 1L, 1);

                    b.Property<decimal>("FounderId")
                        .HasColumnType("decimal(20,0)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Families");
                });

            modelBuilder.Entity("Domain.Entities.FamilyRole", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(20,0)");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FamilyRoles");

                    b.HasData(
                        new
                        {
                            Id = 1m,
                            Name = "Main administrator"
                        },
                        new
                        {
                            Id = 2m,
                            Name = "Parent"
                        },
                        new
                        {
                            Id = 3m,
                            Name = "Child"
                        });
                });

            modelBuilder.Entity("Domain.Entities.UserFamilyRole", b =>
                {
                    b.Property<decimal>("UserId")
                        .HasColumnType("decimal(20,0)");

                    b.Property<decimal>("FamilyId")
                        .HasColumnType("decimal(20,0)");

                    b.Property<decimal>("FamilyRoleId")
                        .HasColumnType("decimal(20,0)");

                    b.HasKey("UserId", "FamilyId");

                    b.HasIndex("FamilyId");

                    b.HasIndex("FamilyRoleId");

                    b.ToTable("UserFamilyRoles");
                });

            modelBuilder.Entity("Domain.Entities.UserFamilyRole", b =>
                {
                    b.HasOne("Domain.Entities.Family", "Family")
                        .WithMany()
                        .HasForeignKey("FamilyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.FamilyRole", "FamilyRole")
                        .WithMany()
                        .HasForeignKey("FamilyRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Family");

                    b.Navigation("FamilyRole");
                });
#pragma warning restore 612, 618
        }
    }
}