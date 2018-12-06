using System.Data.Entity;
using CarAuction2.Models.Car;
using CarAuction2.Models.User;

namespace CarAuction2.App_Data
{
    public class CarAuctionContext : DbContext
    {
        public CarAuctionContext() : base("name=Database1")
        {
            Database.SetInitializer(new CarAuctionDbInitializer());
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}