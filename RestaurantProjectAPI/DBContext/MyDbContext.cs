using Microsoft.EntityFrameworkCore;
using RestaurantProjectAPI.Models;

namespace RestaurantProjectAPI.DBContext
{
    public class MyDbContext: DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options): base(options)
        {

        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }
        public DbSet<Status> Status { get; set; }
    }
}
