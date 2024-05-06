﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebVideoStore.DataAccess.Data;

#nullable disable

namespace WebVideoStore.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240504135058_createImageUrl")]
    partial class createImageUrl
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("WebVideoStore.Models.VideoTape", b =>
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
                            ImageUrl = "https://media.gettyimages.com/id/607392480/photo/actor-arnold-schwarzenegger-on-the-set-of-terminator.jpg?s=612x612&w=0&k=20&c=xAZepXUCji30y-KX2gsAzfGLsYjz58KYsngagBDiHZA=",
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
                            ImageUrl = "https://media.gettyimages.com/id/583900608/photo/keanu-reeves-and-hugo-weaving-face-each-other-in-a-scene-from-andy-and-larry-wachowskis-1999.jpg?s=612x612&w=0&k=20&c=sJib2GLxgb1bxuZKq153zP7gtBaCoNU6nyYHnD7zK4k=",
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
                            ImageUrl = "https://media.gettyimages.com/id/156477400/photo/al-pacino-marlon-brando-james-caan-and-john-cazale-publicity-portrait-for-the-film-the.jpg?s=612x612&w=0&k=20&c=zV3A2jNtTQ5fPLFnUCiAgIDP7PjAEg_7qe42u3M0mA0=",
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
                            ImageUrl = "https://media.gettyimages.com/id/81975737/photo/chicago-ruben-chavez-of-chicago-nathan-robbel-of-chicago-and-odin-cabal-of-kenosha-pose-during.jpg?s=612x612&w=0&k=20&c=LT63FVSH51esYfYK_-2y1mulA-Q4SlHfm-v_BQ6hYd0=",
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
                            ImageUrl = "https://media.gettyimages.com/id/159836292/photo/tim-robbins-in-a-scene-from-the-film-the-shawshank-redemption-1994.jpg?s=612x612&w=0&k=20&c=Dh6mgkr6sHke1wNtXIATUhHJ9CmzkEBRP5kHtYK5qpI=",
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
                            ImageUrl = "https://media.gettyimages.com/id/2147912066/photo/john-travolta-at-the-2024-tcm-classic-film-festival-opening-night-screening-of-pulp-fiction.jpg?s=612x612&w=0&k=20&c=L0p6p3MUqnjAObX1Ln0CBakxlV0v1800q2toryimjPs=",
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
                            ImageUrl = "https://media.gettyimages.com/id/1347822405/photo/hollywood-california-a-hannibal-lecter-jail-cell-from-silence-of-the-lambs-is-on-display-as.jpg?s=612x612&w=0&k=20&c=1zHh1lJmKj745H_cNTUHibfnKr6ft-26TGBDZ7VyB80=",
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
                            ImageUrl = "https://media.gettyimages.com/id/162734047/photo/jack-nicholson-peering-through-axed-in-door-in-lobby-card-for-the-film-the-shining-1980.jpg?s=612x612&w=0&k=20&c=JKmcBH7ifAC2_6ZRe2mIZTLXChjqQpzUsECNl5-Sz8I=",
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
                            ImageUrl = "https://media.gettyimages.com/id/607435710/photo/swedish-actor-max-von-sydow-and-american-actress-linda-blair-on-the-set-of-the-exorcist-based.jpg?s=612x612&w=0&k=20&c=xsv0DqutLgibuuBSTlohuFsDPKICnaK-9a2sZaZt2R8=",
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
                            ImageUrl = "https://media.gettyimages.com/id/51039710/photo/cole-plays-a-boy-posssesed-by-supernatural-visions-and-paranormal-powers-8-year-old-haley-joel.jpg?s=612x612&w=0&k=20&c=Tzw6U63nNDuxF3Ooa7zzTrDkkd-PXLWYuEuucB96xeQ=",
                            PriceBuy = 70.0,
                            PriceRent = 4.0,
                            Title = "The Sixth Sense",
                            Year = 1999
                        });
                });

            modelBuilder.Entity("WebVideoStore.Models.VideoTape", b =>
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