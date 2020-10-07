
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FreshProduceShop.Models
{
    public class ProduceDbContext : IdentityDbContext<IdentityUser>
    {
        public ProduceDbContext(DbContextOptions<ProduceDbContext> options) : base(options)
        {

        }
        //entities that DbContext will manage
        public DbSet<Produce> Produces { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }


         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed categories
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 1, CategoryName = "Vegetable"});
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 2, CategoryName = "Fruit"});

            //seed pies

            modelBuilder.Entity<Produce>().HasData(new Produce
            {
                ProduceId = 1,
                Name = "Apple",
                Price = 12.95M,
                ShortDescription = "Red",
                CategoryId = 2,
                ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/applepie.jpg",
                InStock = true,
                IsProduceOfTheWeek = true,
                ImageThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/applepiesmall.jpg"
                 
            });

            modelBuilder.Entity<Produce>().HasData(new Produce
            {
                ProduceId = 2,
                Name = "Apple",
                Price = 18.95M,
                ShortDescription = "Green",
                CategoryId = 2,
                ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/blueberrycheesecake.jpg",
                InStock = true,
                IsProduceOfTheWeek = true,
                 ImageThumbnailUrl ="https://gillcleerenpluralsight.blob.core.windows.net/files/blueberrycheesecakesmall.jpg"
            });

            modelBuilder.Entity<Produce>().HasData(new Produce
            {
                ProduceId = 3,
                Name = "Kale",
                Price = 18.95M,
                ShortDescription = "Leafy curly vegetable",
                CategoryId = 1,
                ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/cheesecake.jpg",
                InStock = true,
                IsProduceOfTheWeek = false,
                ImageThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/cheesecakesmall.jpg"
                
            });
        }
    }
}