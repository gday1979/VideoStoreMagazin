namespace WebVideoStore.DataAccess.Data
{
    using Microsoft.EntityFrameworkCore;
    using WebVideoStore.Models;
    using WebVideoStore.Models.Models;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
            public DbSet<Category> Categories { get; set; }
            public DbSet<VideoTape>VideoTapes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
                        ImageUrl=""},
                   new VideoTape { Id = 2,
                       Title = "The Matrix",
                       Year = 1999,
                       Director = "The Wachowski Brothers",
                       PriceRent = 4,
                       PriceBuy = 74,
                       CategoryId=5,
                       ImageUrl=""},
                   new VideoTape { Id = 3,
                       Title = "The Godfather",
                       Year = 1972,
                       Director = "Francis Ford Coppola",
                       PriceRent = 6,
                       PriceBuy = 95,
                       CategoryId=1,
                       ImageUrl=""},
                   new VideoTape { Id = 4,
                       Title = "The Dark Knight",
                       Year = 2008,
                       Director = "Christopher Nolan",
                       PriceRent = 5,
                       PriceBuy = 75,
                   CategoryId=4,
                   ImageUrl=""},
                   new VideoTape { Id = 5,
                       Title = "The Shawshank Redemption",
                       Year = 1994,
                       Director = "Frank Darabont",
                       PriceRent = 5,
                       PriceBuy = 80,
                       CategoryId=2,
                       ImageUrl=""},
                   new VideoTape
                   { Id = 6,
                     Title = "Pulp Fiction",
                     Year = 1994,
                     Director = "Quentin Tarantino",
                     PriceRent = 4,
                     PriceBuy = 70,
                     CategoryId=3,
                     ImageUrl=""},
                   new VideoTape 
                   { 
                     Id = 7,
                     Title = "The Silence of the Lambs",
                     Year = 1991,
                     Director = "Jonathan Demme",
                     PriceRent = 4,
                     PriceBuy = 70,
                     CategoryId=3,
                     ImageUrl=""},
                   new VideoTape
                   {
                       Id = 8,
                       Title = "The Shining",
                       Year = 1980,
                       Director = "Stanley Kubrick",
                       PriceRent = 4,
                       PriceBuy = 70,
                       CategoryId=4,
                       ImageUrl=""
                   },                   
                   new VideoTape
                   { Id = 9,
                     Title = "The Exorcist",
                     Year = 1973,
                     Director = "William Friedkin",
                     PriceRent = 4,
                     PriceBuy = 70,
                     CategoryId=4,
                     ImageUrl=""
                    },
                   new VideoTape { 
                    Id = 10,
                    Title = "The Sixth Sense",
                    Year = 1999,
                    Director = "M. Night Shyamalan",
                    PriceRent = 4,
                    PriceBuy = 70,
                    CategoryId=4,
                    ImageUrl=""
                    }
                   );
        }
    
    }
    
}
