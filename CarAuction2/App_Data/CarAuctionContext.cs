using System.Data.Entity;
using CarAuction2.Models.Car;
using CarAuction2.Models.User;

namespace CarAuction2.App_Data
{
    public class CarAuctionContext : DbContext
    {
        public CarAuctionContext() : base("name=CarAuction")
        {
            
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
    }
}