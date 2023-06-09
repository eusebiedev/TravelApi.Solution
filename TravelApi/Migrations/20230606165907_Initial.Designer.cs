﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelApi.Models;

#nullable disable

namespace TravelApi.Migrations
{
    [DbContext(typeof(TravelApiContext))]
    [Migration("20230606165907_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TravelApi.Models.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Climate")
                        .HasColumnType("longtext");

                    b.Property<string>("Language")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int>("Population")
                        .HasColumnType("int");

                    b.HasKey("CountryId");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            CountryId = 1,
                            Climate = "Shady and Sandy",
                            Language = "Shade",
                            Name = "Striped Umbrella",
                            Population = 4999999
                        },
                        new
                        {
                            CountryId = 2,
                            Climate = "Cool and Sweet",
                            Language = "Peppermint",
                            Name = "Mint",
                            Population = 46001
                        },
                        new
                        {
                            CountryId = 3,
                            Climate = "Harsh",
                            Language = "Chomp",
                            Name = "Agitated Badger",
                            Population = 450
                        },
                        new
                        {
                            CountryId = 4,
                            Climate = "Sweltering and Lava",
                            Language = "Dragonian",
                            Name = "Western Democratic Coalition of Dragons",
                            Population = 3
                        },
                        new
                        {
                            CountryId = 5,
                            Climate = "Gooey",
                            Language = "Swiss",
                            Name = "Cheese Island",
                            Population = 72
                        },
                        new
                        {
                            CountryId = 6,
                            Climate = "Subtropical",
                            Language = "Flubber",
                            Name = "Pants",
                            Population = 7200
                        },
                        new
                        {
                            CountryId = 7,
                            Climate = "Hot and Damp",
                            Language = "Sporkian",
                            Name = "Sporkonia",
                            Population = 840
                        });
                });

            modelBuilder.Entity("TravelApi.Models.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ReviewId");

                    b.HasIndex("CountryId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("TravelApi.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TravelApi.Models.Review", b =>
                {
                    b.HasOne("TravelApi.Models.Country", null)
                        .WithMany("Reviews")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelApi.Models.User", null)
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TravelApi.Models.Country", b =>
                {
                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("TravelApi.Models.User", b =>
                {
                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
