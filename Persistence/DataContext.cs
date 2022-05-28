using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    // public class DataContext: DbContext
    public class DataContext: IdentityDbContext<AppUser>
    {

        public DataContext()
{            
    
}
        public DataContext(DbContextOptions options): base(options)
        {
            Database.EnsureCreated();
           
        }
         public virtual DbSet<Client> Clients{ get; set; }
        public virtual DbSet<ClientProject> ClientProjects { get; set; }
        public virtual DbSet<ClientService> ClientServices { get; set; }
        //public virtual DbSet<GlobalFilter> GlobalFilter { get; set; }
       
// public virtual DbSet<AppUser> AppUsers{ get; set; }
        public virtual DbSet<Role> AppRoles{ get; set; }
        public virtual DbSet<UserRole> AppUserRoles { get; set; }
       
          protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder )
               {
                   if ( !optionsBuilder.IsConfigured )
                   {
        #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                       optionsBuilder.UseSqlServer("Server=localhost;Database=pmpa;User Id=sa;Password=Sw33tt34;ConnectRetryCount=0;MultipleActiveResultSets=true");
                   }
               }

// protected override void OnModelCreating(ModelBuilder modelBuilder)
//     {
//         modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
//     }


 protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
           base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

 //modelBuilder.ApplyConfiguration( new AppUserMapping() );

            modelBuilder.ApplyConfiguration( new ClientMapping() );

            modelBuilder.ApplyConfiguration( new ClientProjectMapping() );

            modelBuilder.ApplyConfiguration( new ClientServiceMapping() );

           

            modelBuilder.ApplyConfiguration( new RoleMapping() );

            modelBuilder.ApplyConfiguration( new UserRoleMapping() );
          
         

        }


    }
}