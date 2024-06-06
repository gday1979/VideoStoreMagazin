﻿// <auto-generated />
using System;
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
    [Migration("20240603161830_AddOrderHeaderUserId")]
    partial class AddOrderHeaderUserId
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("nvarchar(21)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

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

            modelBuilder.Entity("WebVideoStore.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Los Angeles",
                            Name = "20 Century Pictures",
                            PhoneNumber = "001245858963",
                            PostalCode = "90210",
                            State = "California",
                            StreetAddress = "Park Avenue"
                        },
                        new
                        {
                            Id = 2,
                            City = "Los Angeles",
                            Name = "Warner Bros",
                            PhoneNumber = "001359326589",
                            PostalCode = "90210",
                            State = "California",
                            StreetAddress = "Warner Blvd"
                        },
                        new
                        {
                            Id = 3,
                            City = "Universal City",
                            Name = "Universal Pictures",
                            PhoneNumber = "001895689958",
                            PostalCode = "91608",
                            State = "California",
                            StreetAddress = "Universal City Plaza"
                        },
                        new
                        {
                            Id = 4,
                            City = "Los Angeles",
                            Name = "Paramount Pictures",
                            PhoneNumber = "001359326589",
                            PostalCode = "90038",
                            State = "California",
                            StreetAddress = "Melrose Ave"
                        },
                        new
                        {
                            Id = 5,
                            City = "Los Angeles",
                            Name = "New Line Cinema",
                            PhoneNumber = "0012582589659",
                            PostalCode = "90038",
                            State = "California",
                            StreetAddress = "New Line Cinema"
                        });
                });

            modelBuilder.Entity("WebVideoStore.Models.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("OrderHeaderId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("VideoTapeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderHeaderId");

                    b.HasIndex("VideoTapeId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("WebVideoStore.Models.OrderHeader", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Carrier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrderTotal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<DateOnly>("PaymentDueDate")
                        .HasColumnType("date");

                    b.Property<string>("PaymentIntentId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SessionId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ShippingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrackingNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("OrderHeaders");
                });

            modelBuilder.Entity("WebVideoStore.Models.ShoppingCart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("VideoTapeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("VideoTapeId");

                    b.ToTable("ShoppingCarts");
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

            modelBuilder.Entity("WebVideoStore.Models.ViewModels.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("CompanyId");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebVideoStore.Models.OrderDetail", b =>
                {
                    b.HasOne("WebVideoStore.Models.OrderHeader", "OrderHeader")
                        .WithMany()
                        .HasForeignKey("OrderHeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebVideoStore.Models.VideoTape", "VideoTape")
                        .WithMany()
                        .HasForeignKey("VideoTapeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrderHeader");

                    b.Navigation("VideoTape");
                });

            modelBuilder.Entity("WebVideoStore.Models.OrderHeader", b =>
                {
                    b.HasOne("WebVideoStore.Models.ViewModels.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("WebVideoStore.Models.ShoppingCart", b =>
                {
                    b.HasOne("WebVideoStore.Models.ViewModels.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebVideoStore.Models.VideoTape", "VideoTape")
                        .WithMany()
                        .HasForeignKey("VideoTapeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("VideoTape");
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

            modelBuilder.Entity("WebVideoStore.Models.ViewModels.ApplicationUser", b =>
                {
                    b.HasOne("WebVideoStore.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.Navigation("Company");
                });
#pragma warning restore 612, 618
        }
    }
}
