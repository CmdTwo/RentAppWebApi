﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RentAppWebApi.Data;

#nullable disable

namespace RentAppWebApi.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("RentAppWebApi.Model.Advertisement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("Cost")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Header")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsActual")
                        .HasColumnType("boolean");

                    b.Property<int>("LandLordId")
                        .HasColumnType("integer");

                    b.Property<int>("RealEstateId")
                        .HasColumnType("integer");

                    b.Property<int>("TermInMonths")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("LandLordId");

                    b.HasIndex("RealEstateId");

                    b.ToTable("Advertisements");
                });

            modelBuilder.Entity("RentAppWebApi.Model.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CountryId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("RentAppWebApi.Model.Contract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsActual")
                        .HasColumnType("boolean");

                    b.Property<int>("LandLordId")
                        .HasColumnType("integer");

                    b.Property<int>("RealEstateId")
                        .HasColumnType("integer");

                    b.Property<int>("RenterId")
                        .HasColumnType("integer");

                    b.Property<int>("TermInMonths")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("LandLordId");

                    b.HasIndex("RealEstateId");

                    b.HasIndex("RenterId");

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("RentAppWebApi.Model.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("RentAppWebApi.Model.PhotoOfRealEstate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RealEstateId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RealEstateId");

                    b.ToTable("PhotoOfRealEstates");
                });

            modelBuilder.Entity("RentAppWebApi.Model.RealEstate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CityId")
                        .HasColumnType("integer");

                    b.Property<int>("CountryId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("LandLordId")
                        .HasColumnType("integer");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("CountryId");

                    b.HasIndex("LandLordId");

                    b.ToTable("RealEstates");
                });

            modelBuilder.Entity("RentAppWebApi.Model.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ContractId")
                        .HasColumnType("integer");

                    b.Property<int>("Rate")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ContractId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("RentAppWebApi.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhotoPath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RentAppWebApi.Model.Advertisement", b =>
                {
                    b.HasOne("RentAppWebApi.Model.User", "LandLord")
                        .WithMany("Advertisements")
                        .HasForeignKey("LandLordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentAppWebApi.Model.RealEstate", "RealEstate")
                        .WithMany("Advertisements")
                        .HasForeignKey("RealEstateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LandLord");

                    b.Navigation("RealEstate");
                });

            modelBuilder.Entity("RentAppWebApi.Model.City", b =>
                {
                    b.HasOne("RentAppWebApi.Model.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("RentAppWebApi.Model.Contract", b =>
                {
                    b.HasOne("RentAppWebApi.Model.User", "LandLord")
                        .WithMany("ContractsAsLandLord")
                        .HasForeignKey("LandLordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentAppWebApi.Model.RealEstate", "RealEstate")
                        .WithMany("Contracts")
                        .HasForeignKey("RealEstateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentAppWebApi.Model.User", "Renter")
                        .WithMany("ContractsAsRenter")
                        .HasForeignKey("RenterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LandLord");

                    b.Navigation("RealEstate");

                    b.Navigation("Renter");
                });

            modelBuilder.Entity("RentAppWebApi.Model.PhotoOfRealEstate", b =>
                {
                    b.HasOne("RentAppWebApi.Model.RealEstate", "RealEstate")
                        .WithMany("Photos")
                        .HasForeignKey("RealEstateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RealEstate");
                });

            modelBuilder.Entity("RentAppWebApi.Model.RealEstate", b =>
                {
                    b.HasOne("RentAppWebApi.Model.City", "City")
                        .WithMany("RealEstates")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentAppWebApi.Model.Country", "Country")
                        .WithMany("RealEstates")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentAppWebApi.Model.User", "LandLord")
                        .WithMany("RealEstates")
                        .HasForeignKey("LandLordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Country");

                    b.Navigation("LandLord");
                });

            modelBuilder.Entity("RentAppWebApi.Model.Review", b =>
                {
                    b.HasOne("RentAppWebApi.Model.Contract", "Contract")
                        .WithMany("Reviews")
                        .HasForeignKey("ContractId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentAppWebApi.Model.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contract");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RentAppWebApi.Model.City", b =>
                {
                    b.Navigation("RealEstates");
                });

            modelBuilder.Entity("RentAppWebApi.Model.Contract", b =>
                {
                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("RentAppWebApi.Model.Country", b =>
                {
                    b.Navigation("Cities");

                    b.Navigation("RealEstates");
                });

            modelBuilder.Entity("RentAppWebApi.Model.RealEstate", b =>
                {
                    b.Navigation("Advertisements");

                    b.Navigation("Contracts");

                    b.Navigation("Photos");
                });

            modelBuilder.Entity("RentAppWebApi.Model.User", b =>
                {
                    b.Navigation("Advertisements");

                    b.Navigation("ContractsAsLandLord");

                    b.Navigation("ContractsAsRenter");

                    b.Navigation("RealEstates");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
