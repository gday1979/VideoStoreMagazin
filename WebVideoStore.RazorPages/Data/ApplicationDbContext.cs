﻿namespace WebVideoStore.RazorPages.Data
{
    using Microsoft.EntityFrameworkCore;
    using WebVideoStore.RazorPages.Models;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
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
        }
    } 
}
