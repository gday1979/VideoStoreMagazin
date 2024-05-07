namespace WebVideoStore.DataAccess.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using WebVideoStore.Models;
    using WebVideoStore.Models.ViewModels;

    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
            public DbSet<Category> Categories { get; set; }
            public DbSet<VideoTape>VideoTapes { get; set; }

            public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>()
                .HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                    new Category { Id = 2, Name = "Comedy", DisplayOrder = 2 },
                    new Category { Id = 3, Name = "Drama", DisplayOrder = 3 },
                    new Category { Id = 4, Name = "Horror", DisplayOrder = 4 },
                    new Category { Id = 5, Name = "Sci-Fi", DisplayOrder = 5 }
                );
            modelBuilder.Entity<VideoTape>()
                .HasData(
                   new VideoTape { Id = 1,
                       Title = "The Terminator",
                       Year = 1984,
                       Director = "James Cameron",                
                       PriceRent = 6,
                       PriceBuy = 85,
                        CategoryId=5,
                        ImageUrl= "https://media.gettyimages.com/id/607392480/photo/actor-arnold-schwarzenegger-on-the-set-of-terminator.jpg?s=612x612&w=0&k=20&c=xAZepXUCji30y-KX2gsAzfGLsYjz58KYsngagBDiHZA="
                   },
                   new VideoTape { Id = 2,
                       Title = "The Matrix",
                       Year = 1999,
                       Director = "The Wachowski Brothers",
                       PriceRent = 4,
                       PriceBuy = 74,
                       CategoryId=5,
                       ImageUrl= "https://media.gettyimages.com/id/583900608/photo/keanu-reeves-and-hugo-weaving-face-each-other-in-a-scene-from-andy-and-larry-wachowskis-1999.jpg?s=612x612&w=0&k=20&c=sJib2GLxgb1bxuZKq153zP7gtBaCoNU6nyYHnD7zK4k="
                   },
                   new VideoTape { Id = 3,
                       Title = "The Godfather",
                       Year = 1972,
                       Director = "Francis Ford Coppola",
                       PriceRent = 6,
                       PriceBuy = 95,
                       CategoryId=1,
                       ImageUrl= "https://media.gettyimages.com/id/156477400/photo/al-pacino-marlon-brando-james-caan-and-john-cazale-publicity-portrait-for-the-film-the.jpg?s=612x612&w=0&k=20&c=zV3A2jNtTQ5fPLFnUCiAgIDP7PjAEg_7qe42u3M0mA0="
                   },
                   new VideoTape { Id = 4,
                       Title = "The Dark Knight",
                       Year = 2008,
                       Director = "Christopher Nolan",
                       PriceRent = 5,
                       PriceBuy = 75,
                   CategoryId=4,
                   ImageUrl= "https://media.gettyimages.com/id/81975737/photo/chicago-ruben-chavez-of-chicago-nathan-robbel-of-chicago-and-odin-cabal-of-kenosha-pose-during.jpg?s=612x612&w=0&k=20&c=LT63FVSH51esYfYK_-2y1mulA-Q4SlHfm-v_BQ6hYd0="
                   },
                   new VideoTape { Id = 5,
                       Title = "The Shawshank Redemption",
                       Year = 1994,
                       Director = "Frank Darabont",
                       PriceRent = 5,
                       PriceBuy = 80,
                       CategoryId=2,
                       ImageUrl= "https://media.gettyimages.com/id/159836292/photo/tim-robbins-in-a-scene-from-the-film-the-shawshank-redemption-1994.jpg?s=612x612&w=0&k=20&c=Dh6mgkr6sHke1wNtXIATUhHJ9CmzkEBRP5kHtYK5qpI="
                   },
                   new VideoTape
                   { Id = 6,
                     Title = "Pulp Fiction",
                     Year = 1994,
                     Director = "Quentin Tarantino",
                     PriceRent = 4,
                     PriceBuy = 70,
                     CategoryId=3,
                     ImageUrl= "https://media.gettyimages.com/id/2147912066/photo/john-travolta-at-the-2024-tcm-classic-film-festival-opening-night-screening-of-pulp-fiction.jpg?s=612x612&w=0&k=20&c=L0p6p3MUqnjAObX1Ln0CBakxlV0v1800q2toryimjPs="
                   },
                   new VideoTape 
                   { 
                     Id = 7,
                     Title = "The Silence of the Lambs",
                     Year = 1991,
                     Director = "Jonathan Demme",
                     PriceRent = 4,
                     PriceBuy = 70,
                     CategoryId=3,
                     ImageUrl= "https://media.gettyimages.com/id/1347822405/photo/hollywood-california-a-hannibal-lecter-jail-cell-from-silence-of-the-lambs-is-on-display-as.jpg?s=612x612&w=0&k=20&c=1zHh1lJmKj745H_cNTUHibfnKr6ft-26TGBDZ7VyB80="
                   },
                   new VideoTape
                   {
                       Id = 8,
                       Title = "The Shining",
                       Year = 1980,
                       Director = "Stanley Kubrick",
                       PriceRent = 4,
                       PriceBuy = 70,
                       CategoryId=4,
                       ImageUrl= "https://media.gettyimages.com/id/162734047/photo/jack-nicholson-peering-through-axed-in-door-in-lobby-card-for-the-film-the-shining-1980.jpg?s=612x612&w=0&k=20&c=JKmcBH7ifAC2_6ZRe2mIZTLXChjqQpzUsECNl5-Sz8I="
                   },                   
                   new VideoTape
                   { Id = 9,
                     Title = "The Exorcist",
                     Year = 1973,
                     Director = "William Friedkin",
                     PriceRent = 4,
                     PriceBuy = 70,
                     CategoryId=4,
                     ImageUrl= "https://media.gettyimages.com/id/607435710/photo/swedish-actor-max-von-sydow-and-american-actress-linda-blair-on-the-set-of-the-exorcist-based.jpg?s=612x612&w=0&k=20&c=xsv0DqutLgibuuBSTlohuFsDPKICnaK-9a2sZaZt2R8="
                   },
                   new VideoTape { 
                    Id = 10,
                    Title = "The Sixth Sense",
                    Year = 1999,
                    Director = "M. Night Shyamalan",
                    PriceRent = 4,
                    PriceBuy = 70,
                    CategoryId=4,
                    ImageUrl= "https://media.gettyimages.com/id/51039710/photo/cole-plays-a-boy-posssesed-by-supernatural-visions-and-paranormal-powers-8-year-old-haley-joel.jpg?s=612x612&w=0&k=20&c=Tzw6U63nNDuxF3Ooa7zzTrDkkd-PXLWYuEuucB96xeQ="
                   }
                   );
        }
    
    }
    
}
