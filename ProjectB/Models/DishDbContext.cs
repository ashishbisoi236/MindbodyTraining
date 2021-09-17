using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectB.Models;

namespace ProjectB.Models
{
    public class DishDbContext : DbContext
    {
        public DishDbContext(DbContextOptions<DishDbContext> options) : base(options)
        {

        }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //seeding the db
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 1, CategoryName = "Punjabi", Description = "Punjabi cuisine is famous all over the country for its delicious flavor." });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 2, CategoryName = "Rajasthani", Description = "The state of Rajasthan is widely known for its distinct variety of dishes." });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 3, CategoryName = "Bengali", Description = "Bengali food is a combination of fish, rice, and lentils." });

            modelBuilder.Entity<Dish>().HasData(
                 new Dish
                 {
                     DishId = 1,
                     DishName = "Aloo Posto",
                     Price = 230,
                     Description = "lorem ipsum",
                     ImageUrl = "/img/b1.jpg",
                     ImageThumbnailUrl = "/img/b1.jpg",
                     IsBestSeller = false,
                     CategoryId = 3,
                 });

            modelBuilder.Entity<Dish>().HasData(
                new Dish
                {
                    DishId = 2,
                    DishName = "Doi Maach",
                    Price = 330,
                    Description = "lorem ipsum",
                    ImageUrl = "/img/b1.jpg",
                    ImageThumbnailUrl = "/img/b1.jpg",
                    IsBestSeller = true,
                    CategoryId = 3,
                }); 
            modelBuilder.Entity<Dish>().HasData(
                new Dish
                {
                    DishId = 3,
                    DishName = "Rasmalai",
                    Price = 100,
                    Description = "lorem ipsum",
                    ImageUrl = "/img/b1.jpg",
                    ImageThumbnailUrl = "/img/b1.jpg",
                    IsBestSeller = false,
                    CategoryId = 3,
                });

            modelBuilder.Entity<Dish>().HasData(
               new Dish
               {
                   DishId = 4,
                   DishName = "Aloo Paratha",
                   Price = 200,
                   Description = "lorem ipsum",
                   ImageUrl = "/img/p1.jpg",
                   ImageThumbnailUrl = "/img/p1.jpg",
                   IsBestSeller = true,
                   CategoryId = 1,
               });

            modelBuilder.Entity<Dish>().HasData(new Dish
            {
                DishId = 5,
                DishName = "Makki Roti",
                Price = 300,
                Description = "lorem ipsum",
                ImageUrl = "/img/p1.jpg",
                ImageThumbnailUrl = "/img/p1.jpg",
                IsBestSeller = true,
                CategoryId = 1,
            });
            modelBuilder.Entity<Dish>().HasData(new Dish
            {
                DishId = 6,
                DishName = "Mawa Kachori",
                Price = 350,
                Description = "lorem ipsum",
                ImageUrl = "/img/r1.jpg",
                ImageThumbnailUrl = "/img/r1.jpg",
                IsBestSeller = false,
                CategoryId = 2,
            });
            modelBuilder.Entity<Dish>().HasData(new Dish
            {
                DishId = 7,
                DishName = "Mirchi Bada",
                Price = 150,
                Description = "lorem ipsum",
                ImageUrl = "/img/r1.jpg",
                ImageThumbnailUrl = "/img/r1.jpg",
                IsBestSeller = true,
                CategoryId = 2,
            });
        }

        public DbSet<ProjectB.Models.Order> Order { get; set; }
    }
}
