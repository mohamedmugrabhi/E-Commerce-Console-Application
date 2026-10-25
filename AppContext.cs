using Microsoft.EntityFrameworkCore;

namespace EcommerceApp
{
    public class EcommerceContext : DbContext
    {
        public DbSet<Product> products { get; set; }

        public DbSet<Category> categories { get; set; }

        public DbSet<Customer> customers { get; set; }

        public DbSet<Order> orders { get; set; }

        public DbSet<OrderDetails> orderDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(
        @"Data Source=localhost;Initial Catalog=EcommerceDB;Integrated Security=True;TrustServerCertificate=True;");
    }
}