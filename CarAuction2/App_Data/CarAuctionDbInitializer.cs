using System.Collections.Generic;
using System.Data.Entity;
using CarAuction2.Models.User;

namespace CarAuction2.App_Data
{
    public class CarAuctionDbInitializer : DropCreateDatabaseAlways<CarAuctionContext>
    {
        protected override void Seed(CarAuctionContext context)
        {
            IList<UserRole> defaultRoles = new List<UserRole>();

            defaultRoles.Add(new UserRole { RoleName = "User"});
            defaultRoles.Add(new UserRole { RoleName = "Admin"});
            context.UserRoles.AddRange(defaultRoles);
            
            IList<User> defaultUsers = new List<User>();
            defaultUsers.Add(new User {Email = "user@carauction.com", Password = "usercarauc", FirstName = "John", LastName = "Smith"});
            defaultUsers.Add(new User {Email = "admin@carauction.com", Password = "admincarauc", FirstName = "Mark", LastName = "Hill"});
            context.Users.AddRange(defaultUsers);
            
            base.Seed(context);
        }
    }
}