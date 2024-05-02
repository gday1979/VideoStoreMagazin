﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebVideoStore.DataAccess.Data;

#nullable disable

namespace WebVideoStore.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebVideoStore.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayOrder = 1,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 2,
                            DisplayOrder = 2,
                            Name = "Comedy"
                        },
                        new
                        {
                            Id = 3,
                            DisplayOrder = 3,
                            Name = "Drama"
                        },
                        new
                        {
                            Id = 4,
                            DisplayOrder = 4,
                            Name = "Horror"
                        },
                        new
                        {
                            Id = 5,
                            DisplayOrder = 5,
                            Name = "Sci-Fi"
                        });
                });

            modelBuilder.Entity("WebVideoStore.Models.Models.VideoTape", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PriceBuy")
                        .HasColumnType("float");

                    b.Property<double>("PriceRent")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("VideoTapes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 5,
                            Director = "James Cameron",
                            ImageUrl = "",
                            PriceBuy = 85.0,
                            PriceRent = 6.0,
                            Title = "The Terminator",
                            Year = 1984
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 5,
                            Director = "The Wachowski Brothers",
                            ImageUrl = "",
                            PriceBuy = 74.0,
                            PriceRent = 4.0,
                            Title = "The Matrix",
                            Year = 1999
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Director = "Francis Ford Coppola",
                            ImageUrl = "",
                            PriceBuy = 95.0,
                            PriceRent = 6.0,
                            Title = "The Godfather",
                            Year = 1972
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 4,
                            Director = "Christopher Nolan",
                            ImageUrl = "",
                            PriceBuy = 75.0,
                            PriceRent = 5.0,
                            Title = "The Dark Knight",
                            Year = 2008
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 2,
                            Director = "Frank Darabont",
                            ImageUrl = "",
                            PriceBuy = 80.0,
                            PriceRent = 5.0,
                            Title = "The Shawshank Redemption",
                            Year = 1994
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 3,
                            Director = "Quentin Tarantino",
                            ImageUrl = "",
                            PriceBuy = 70.0,
                            PriceRent = 4.0,
                            Title = "Pulp Fiction",
                            Year = 1994
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 3,
                            Director = "Jonathan Demme",
                            ImageUrl = "",
                            PriceBuy = 70.0,
                            PriceRent = 4.0,
                            Title = "The Silence of the Lambs",
                            Year = 1991
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 4,
                            Director = "Stanley Kubrick",
                            ImageUrl = "",
                            PriceBuy = 70.0,
                            PriceRent = 4.0,
                            Title = "The Shining",
                            Year = 1980
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 4,
                            Director = "William Friedkin",
                            ImageUrl = "",
                            PriceBuy = 70.0,
                            PriceRent = 4.0,
                            Title = "The Exorcist",
                            Year = 1973
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 4,
                            Director = "M. Night Shyamalan",
                            ImageUrl = "",
                            PriceBuy = 70.0,
                            PriceRent = 4.0,
                            Title = "The Sixth Sense",
                            Year = 1999
                        });
                });

            modelBuilder.Entity("WebVideoStore.Models.Models.VideoTape", b =>
                {
                    b.HasOne("WebVideoStore.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
