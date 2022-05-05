using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context, UserManager<AppUser> userManager)
        {


         if (!userManager.Users.Any())
            {
                var users = new List<AppUser>
                {
            new AppUser()
            { UserId = Guid.NewGuid(),
             Email = "abel_fernandes@yahoo.com", UserName="abel_fernandes@yahoo.com",
             FirstName = "Abel", LastName = "Fernandes",    CreateDateTime = DateTime.Now,
             LastUpdateDateTime = DateTime.Now,
             IsAdmin  =true, Active = true, 
            //  ClientId = client.ClientId
            ClientId =Guid.Parse("ea8ff81c-a42c-4f7a-8cc3-a842c8f1a10e")
             },
             new AppUser()
             {
                 UserId = Guid.NewGuid(),
             Email = "abel9865@gmail.com", UserName = "abel9865@gmail.com",
             FirstName = "Abel", LastName = "Fernandes",    CreateDateTime = DateTime.Now,
             LastUpdateDateTime = DateTime.Now,
             IsAdmin  =true, Active = true, 
            //  ClientId = client.ClientId
            ClientId =Guid.Parse("ea8ff81c-a42c-4f7a-8cc3-a842c8f1a10e")
             }
                };


                foreach (var appUser in users)     
                {
                        await userManager.CreateAsync(appUser, "Sw33tt34!");
                }
            }




            if (context.Clients.Any() ||
             context.PMPAUsers.Any() ||
             context.ClientProjects.Any() || context.ClientServices.Any()) return;

            var client = new Client() { ClientId = Guid.NewGuid(), ClientName = "ACME", ClientCode = "ACME" };

            var user = new User()
            {
                UserId = Guid.NewGuid(),
                Email = "abel_fernandes@yahoo.com",
                FirstName = "Abel",
                LastName = "Fernandes",
                Password = "AQAAAAIAAYagAAAAEGHyoK3FiDQ3ZbdiHkgJ+WrDP+bvxliN4BzOhxlGqCuGjH2a95GODjV7fjlGLNvuUQ==",
                CompanyName = "Not Needed",
                CompanyCode = "Not Needed",
                IncludeinMailings = false,
                CreateDateTime = DateTime.Now,
                LastUpdateDateTime = DateTime.Now,
                QryGroup1 = "N",
                QryGroup2 = "N",
                QryGroup3 = "N",
                QryGroup4 = "N",
                QryGroup5 = "N",
                QryGroup6 = "N",
                QryGroup7 = "N",
                QryGroup8 = "N",
                QryGroup9 = "N",
                QryGroup10 = "N",
                QryGroup11 = "N",
                QryGroup12 = "N",
                QryGroup13 = "N",
                QryGroup14 = "N",
                QryGroup15 = "N",
                QryGroup16 = "N",
                QryGroup17 = "N",
                QryGroup18 = "N",
                QryGroup19 = "N",
                QryGroup20 = "N",
                QryGroup21 = "N",
                QryGroup22 = "N",
                QryGroup23 = "N",
                QryGroup24 = "N",
                QryGroup25 = "N",
                QryGroup26 = "N",
                QryGroup27 = "N",
                QryGroup28 = "N",
                QryGroup29 = "N",
                QryGroup30 = "N"
            ,
                QryGroup31 = "N",
                QryGroup32 = "N",
                QryGroup33 = "N",
                QryGroup34 = "N",
                QryGroup35 = "N",
                QryGroup36 = "N",
                QryGroup37 = "N",
                QryGroup38 = "N",
                QryGroup39 = "N",
                QryGroup40 = "N"
            ,
                QryGroup41 = "N",
                QryGroup42 = "N",
                QryGroup43 = "N",
                QryGroup44 = "N",
                QryGroup45 = "N",
                QryGroup46 = "N",
                QryGroup47 = "N",
                QryGroup48 = "N",
                QryGroup49 = "N",
                QryGroup50 = "N"
            ,
                QryGroup51 = "N",
                QryGroup52 = "N",
                QryGroup53 = "N",
                QryGroup54 = "N",
                QryGroup55 = "N",
                QryGroup56 = "N",
                QryGroup57 = "N",
                QryGroup58 = "N",
                QryGroup59 = "N",
                QryGroup60 = "N"
            ,
                QryGroup61 = "N",
                QryGroup62 = "N",
                QryGroup63 = "N",
                QryGroup64 = "N"
            ,
                HasAdmin = true,
                Active = true,
                ClientId = client.ClientId
            };

            var clientService = new ClientService() { ClientServiceId = Guid.NewGuid(), ClientId = client.ClientId, Pm = true, Pa = true, CreatedBy = user.UserId, CreatedDate = DateTime.Now, LastUpdatedBy = user.UserId, LastUpdatedDate = DateTime.Now };

            var clientProjects = new List<ClientProject>{
                new ClientProject{ProjectId = Guid.NewGuid(), ClientId = client.ClientId, ProjectTitle = "HR Employee Management", ProjectDescription="This application is used to managed everything HR related at ACME INC", ProjectStatus = true, CreatedBy = user.UserId, CreatedDate = DateTime.Now, LastUpdatedBy = user.UserId, LastUpdatedDate = DateTime.Now},
                new ClientProject{ProjectId = Guid.NewGuid(), ClientId = client.ClientId, ProjectTitle = "ACME CRM", ProjectDescription="This application is used to managed everything CRM related at ACME INC", ProjectStatus = true, CreatedBy = user.UserId, CreatedDate = DateTime.Now, LastUpdatedBy = user.UserId, LastUpdatedDate = DateTime.Now},
                new ClientProject{ProjectId = Guid.NewGuid(), ClientId = client.ClientId, ProjectTitle = "Support Desk", ProjectDescription="This application is used to managed everything Support Desk related at ACME INC" , ProjectStatus = true, CreatedBy = user.UserId, CreatedDate = DateTime.Now, LastUpdatedBy = user.UserId, LastUpdatedDate = DateTime.Now}

            };

            //             var activities = new List<Activity>
            //             {
            //                 new Activity
            //                 {
            //                     Title = "Past Activity 1",
            //                     Date = DateTime.Now.AddMonths(-2),
            //                     Description = "Activity 2 months ago",
            //                     Category = "drinks",
            //                     City = "London",
            //                     Venue = "Pub",
            //                 },
            //                 new Activity
            //                 {
            //                     Title = "Past Activity 2",
            //                     Date = DateTime.Now.AddMonths(-1),
            //                     Description = "Activity 1 month ago",
            //                     Category = "culture",
            //                     City = "Paris",
            //                     Venue = "Louvre",
            //                 },
            //                 new Activity
            //                 {
            //                     Title = "Future Activity 1",
            //                     Date = DateTime.Now.AddMonths(1),
            //                     Description = "Activity 1 month in future",
            //                     Category = "culture",
            //                     City = "London",
            //                     Venue = "Natural History Museum",
            //                 },
            //                 new Activity
            //                 {
            //                     Title = "Future Activity 2",
            //                     Date = DateTime.Now.AddMonths(2),
            //                     Description = "Activity 2 months in future",
            //                     Category = "music",
            //                     City = "London",
            //                     Venue = "O2 Arena",
            //                 },
            //                 new Activity
            //                 {
            //                     Title = "Future Activity 3",
            //                     Date = DateTime.Now.AddMonths(3),
            //                     Description = "Activity 3 months in future",
            //                     Category = "drinks",
            //                     City = "London",
            //                     Venue = "Another pub",
            //                 },
            //                 new Activity
            //                 {
            //                     Title = "Future Activity 4",
            //                     Date = DateTime.Now.AddMonths(4),
            //                     Description = "Activity 4 months in future",
            //                     Category = "drinks",
            //                     City = "London",
            //                     Venue = "Yet another pub",
            //                 },
            //                 new Activity
            //                 {
            //                     Title = "Future Activity 5",
            //                     Date = DateTime.Now.AddMonths(5),
            //                     Description = "Activity 5 months in future",
            //                     Category = "drinks",
            //                     City = "London",
            //                     Venue = "Just another pub",
            //                 },
            //                 new Activity
            //                 {
            //                     Title = "Future Activity 6",
            //                     Date = DateTime.Now.AddMonths(6),
            //                     Description = "Activity 6 months in future",
            //                     Category = "music",
            //                     City = "London",
            //                     Venue = "Roundhouse Camden",
            //                 },
            //                 new Activity
            //                 {
            //                     Title = "Future Activity 7",
            //                     Date = DateTime.Now.AddMonths(7),
            //                     Description = "Activity 2 months ago",
            //                     Category = "travel",
            //                     City = "London",
            //                     Venue = "Somewhere on the Thames",
            //                 },
            //                 new Activity
            //                 {
            //                     Title = "Future Activity 8",
            //                     Date = DateTime.Now.AddMonths(8),
            //                     Description = "Activity 8 months in future",
            //                     Category = "film",
            //                     City = "London",
            //                     Venue = "Cinema",
            //                 }
            //             };

            //await context.Activities.AddRangeAsync(activities);
            await context.Clients.AddAsync(client);
            await context.PMPAUsers.AddAsync(user);
            await context.ClientServices.AddAsync(clientService);
            await context.ClientProjects.AddRangeAsync(clientProjects);
            await context.SaveChangesAsync();
        }
    }
}