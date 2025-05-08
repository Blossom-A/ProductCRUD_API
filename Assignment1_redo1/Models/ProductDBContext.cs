using Microsoft.EntityFrameworkCore;

namespace Assignment1_redo1.Models //2
{
    public class ProductDBContext : DbContext //Adding the DbContext (this class is inheriting from the parent class - DbContext) will convert this currently normal class into a dbcontext class
    {
        //We need to add a constuctor for this class
        //right click on ProductDBContext > Quick actions and refactoring > Generate constructor ProductDBContext(options)
        public ProductDBContext(DbContextOptions dbContextoptions) : base(dbContextoptions)
        {
            //This constructor has the parameter of the type db context options - dbContextoptions
            //2 things must pass through it, first: for the db provider to determine whether we want to use SQL Sever, MS SQL, etc
            //Second: We have to pass the corresponding physical db connection string - that will be pass from the program.cs file through dependency injection
        }
        //adding a property for this class
        public DbSet<Product> Products { get; set; } //we add this here to tell the db context that we need it corresponding to the product model

        protected override void OnModelCreating(ModelBuilder modelBuilder)//the seed data
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 1,
                    Name = "Baseball Cap",
                    Description = "A classic baseball cap...",
                    Price = 19.99M
                },
                new Product
                {
                    ProductId = 2,
                    Name = "Maxi Dress",
                    Description = "Flowing, floor-length maxi dress...",
                    Price = 59.99M
                },
                new Product
                {
                    ProductId = 3,
                    Name = "Slim Fit Chinos",
                    Description = "A pair of slim-fit chinos...",
                    Price = 44.95M
                },
                new Product
                {
                    ProductId = 4,
                    Name = "Hoodie",
                    Description = "Cozy hoodie with a bold graphic...",
                    Price = 49.99M
                },
                new Product
                {
                    ProductId = 5,
                    Name = "Jogger Sweatpants",
                    Description = "Comfortable and stylish...",
                    Price = 39.99M
                },
                new Product
                {
                    ProductId = 6,
                    Name = "Running Shoes",
                    Description = "High-performance running shoes...",
                    Price = 89.99M
                }
            );
        }
    }
}
