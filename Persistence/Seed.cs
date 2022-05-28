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


        //  if (!userManager.Users.Any())
        //     {
        //         var users = new List<AppUser>
        //         {
        //     new AppUser()
        //     { UserId = Guid.NewGuid(),
        //      Email = "abel_fernandes@yahoo.com", UserName="abel_fernandes@yahoo.com",
        //      FirstName = "Abel", LastName = "Fernandes",    CreateDateTime = DateTime.Now,
        //      LastUpdateDateTime = DateTime.Now,
        //      IsAdmin  =true, Active = true, 
        //     //  ClientId = client.ClientId
        //     ClientId =Guid.Parse("ea8ff81c-a42c-4f7a-8cc3-a842c8f1a10e")
        //      },
        //      new AppUser()
        //      {
        //          UserId = Guid.NewGuid(),
        //      Email = "abel9865@gmail.com", UserName = "abel9865@gmail.com",
        //      FirstName = "Abel", LastName = "Fernandes",    CreateDateTime = DateTime.Now,
        //      LastUpdateDateTime = DateTime.Now,
        //      IsAdmin  =true, Active = true, 
        //     //  ClientId = client.ClientId
        //     ClientId =Guid.Parse("ea8ff81c-a42c-4f7a-8cc3-a842c8f1a10e")
        //      }
        //         };


        //         foreach (var appUser in users)     
        //         {
        //                 await userManager.CreateAsync(appUser, "Sw33tt34!");
        //         }
        //     }




            // if (context.Clients.Any() ||
            // // context.PMPAUsers.Any() ||
            // userManager.Users.Any() ||
            //  context.ClientProjects.Any() || context.ClientServices.Any()) return;

            var client = new Client() { ClientId = Guid.NewGuid(), ClientName = "ACME", ClientCode = "ACME" };




//    var users = new List<AppUser>
//                 {
//             new AppUser()
//             { Id = Guid.NewGuid().ToString(),
//              Email = "abel_fernandes@yahoo.com", UserName="abel_fernandes@yahoo.com",
//              FirstName = "Abel", LastName = "Fernandes",    CreateDateTime = DateTime.Now,
//              LastUpdateDateTime = DateTime.Now,
//              IsAdmin  =true, Active = true, 
//              ClientId = client.ClientId
//             //ClientId =Guid.Parse("ea8ff81c-a42c-4f7a-8cc3-a842c8f1a10e")
//              },
//              new AppUser()
//              {
//                  Id = Guid.NewGuid().ToString(),
//              Email = "abel9865@gmail.com", UserName = "abel9865@gmail.com",
//              FirstName = "Abel", LastName = "Fernandes",    CreateDateTime = DateTime.Now,
//              LastUpdateDateTime = DateTime.Now,
//              IsAdmin  =true, Active = true, 
//              ClientId = client.ClientId
//             //ClientId =Guid.Parse("ea8ff81c-a42c-4f7a-8cc3-a842c8f1a10e")
//              }
//                 };


//                 foreach (var appUser in users)     
//                 {
//                         await userManager.CreateAsync(appUser, "Sw33tt34!");
//                 }


          

//             var clientService = new ClientService() { ClientServiceId = Guid.NewGuid(), ClientId = client.ClientId, Pm = true, Pa = true, CreatedBy = users[0].Id, CreatedDate = DateTime.Now, LastUpdatedBy = users[0].Id, LastUpdatedDate = DateTime.Now };

//             var clientProjects = new List<ClientProject>{
//                 new ClientProject{ProjectId = Guid.NewGuid(), ClientId = client.ClientId, ProjectTitle = "HR Employee Management", ProjectDescription="This application is used to managed everything HR related at ACME INC", ProjectStatus = true, CreatedBy = users[0].Id, CreatedDate = DateTime.Now, LastUpdatedBy = users[0].Id, LastUpdatedDate = DateTime.Now},
//                 new ClientProject{ProjectId = Guid.NewGuid(), ClientId = client.ClientId, ProjectTitle = "ACME CRM", ProjectDescription="This application is used to managed everything CRM related at ACME INC", ProjectStatus = true, CreatedBy = users[0].Id, CreatedDate = DateTime.Now, LastUpdatedBy = users[0].Id, LastUpdatedDate = DateTime.Now},
//                 new ClientProject{ProjectId = Guid.NewGuid(), ClientId = client.ClientId, ProjectTitle = "Support Desk", ProjectDescription="This application is used to managed everything Support Desk related at ACME INC" , ProjectStatus = true, CreatedBy = users[0].Id, CreatedDate = DateTime.Now, LastUpdatedBy = users[0].Id, LastUpdatedDate = DateTime.Now}

//             };

            
            await context.Clients.AddAsync(client);
           // await context.PMPAUsers.AddAsync(user);
           
           
           
           // await context.ClientServices.AddAsync(clientService);
           // await context.ClientProjects.AddRangeAsync(clientProjects);
           // await context.SaveChangesAsync();
        }
    }
}