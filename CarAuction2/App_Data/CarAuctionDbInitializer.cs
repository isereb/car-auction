using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using CarAuction2.Models.Car;
using CarAuction2.Models.User;
using CarAuction2.Security;
using WebGrease.Css.Extensions;

namespace CarAuction2.App_Data
{
    [AuthFilter]
    public class CarAuctionDbInitializer : DropCreateDatabaseAlways<CarAuctionContext>
    {
        protected override void Seed(CarAuctionContext context)
        {
            IList<User> defaultUsers = new List<User>();
            defaultUsers.Add(
                new User
                {
                    Email = "user@carauction.com",
                    Password = "usercarauc",
                    FirstName = "John",
                    LastName = "Smith",
                    UserRole = new UserRole
                    {
                        RoleName = "User"
                    }
                }
            );
            defaultUsers.Add(
                new User
                {
                    Email = "admin@carauction.com",
                    Password = "admincarauc",
                    FirstName = "Mark",
                    LastName = "Hill",
                    UserRole = new UserRole
                    {
                        RoleName = "Admin"
                    }
                });
            context.Users.AddRange(defaultUsers);

            Mark toyota = new Mark {MarkId = 1, Name = "Toyota"};
            Mark honda = new Mark {MarkId = 2, Name = "Honda"};
            Mark bmw = new Mark {MarkId = 3, Name = "BMW"};
            Mark audi = new Mark {MarkId = 4, Name = "Audi"};
            Mark mercedes = new Mark {MarkId = 5, Name = "Mercedes"};
            
            IList<Model> defaultModels = new List<Model>();
            defaultModels.Add(new Model { Mark = toyota, Name = "Accord", });
            defaultModels.Add(new Model { Mark = toyota, Name = "Camry"});
            defaultModels.Add(new Model { Mark = honda, Name = "Accord" });
            defaultModels.Add(new Model { Mark = honda, Name = "Civic" });
            defaultModels.Add(new Model { Mark = bmw, Name = "X1" });
            defaultModels.Add(new Model { Mark = bmw, Name = "X3" });
            defaultModels.Add(new Model { Mark = bmw, Name = "X5" });
            defaultModels.Add(new Model { Mark = bmw, Name = "Z4" });
            defaultModels.Add(new Model { Mark = audi, Name = "A3" });
            defaultModels.Add(new Model { Mark = audi, Name = "A4" });
            defaultModels.Add(new Model { Mark = audi, Name = "Q3" });
            defaultModels.Add(new Model { Mark = audi, Name = "Q5" });
            defaultModels.Add(new Model { Mark = audi, Name = "Q7" });
            defaultModels.Add(new Model { Mark = mercedes, Name = "C300"});
            defaultModels.Add(new Model { Mark = mercedes, Name = "E300" });
            defaultModels.Add(new Model { Mark = mercedes, Name = "GL63" });
            defaultModels.ForEach(m => context.Models.AddOrUpdate(m));

//            IList<Car> defaultCars = new List<Car>();
//            defaultCars.Add(new Car()
//            {
//                
//            });
            
            base.Seed(context);
        }
    }
}