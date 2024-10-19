﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PoopyPoApi.Data;

#nullable disable

namespace PoopyPoApi.Migrations
{
    [DbContext(typeof(PoopyDbContext))]
    partial class PoopyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PoopyPoApi.Models.Domain.PoopInteractions", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("InteractionType")
                        .HasColumnType("int");

                    b.Property<Guid>("PoopLocationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("PoopLocationId");

                    b.HasIndex("UserId");

                    b.ToTable("PoopInteractions");
                });

            modelBuilder.Entity("PoopyPoApi.Models.Domain.PoopLocation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("Anonymous")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<DateOnly>("PoopDate")
                        .HasColumnType("date");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Votes")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("PoopLocations");
                });

            modelBuilder.Entity("PoopyPoApi.Models.Domain.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("PoopyScore")
                        .HasColumnType("bigint");

                    b.Property<DateOnly>("SignupDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PoopyPoApi.Models.Domain.PoopInteractions", b =>
                {
                    b.HasOne("PoopyPoApi.Models.Domain.PoopLocation", "PoopLocation")
                        .WithMany()
                        .HasForeignKey("PoopLocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PoopyPoApi.Models.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("PoopLocation");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PoopyPoApi.Models.Domain.PoopLocation", b =>
                {
                    b.HasOne("PoopyPoApi.Models.Domain.User", "User")
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
