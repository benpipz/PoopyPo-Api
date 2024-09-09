﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PoopyPoApi.Data;

#nullable disable

namespace PoopyPoApi.Migrations
{
    [DbContext(typeof(PoopyDbContext))]
    [Migration("20240706144118_initial migration")]
    partial class initialmigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PoopyPoApi.Models.Domain.PoopLocations", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<DateOnly>("PoopDate")
                        .HasColumnType("date");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Votes")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("PoopLocations");
                });

            modelBuilder.Entity("PoopyPoApi.Models.Domain.Users", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FamilyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("PoopyScore")
                        .HasColumnType("bigint");

                    b.Property<string>("PrivateName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("SignupDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PoopyPoApi.Models.Domain.PoopLocations", b =>
                {
                    b.HasOne("PoopyPoApi.Models.Domain.Users", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
