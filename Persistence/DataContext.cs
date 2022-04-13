using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext: DbContext
    {

        public DataContext()
{            
}
        public DataContext(DbContextOptions options): base(options)
        {
            Database.EnsureCreated();
        }
         public virtual DbSet<Client> Client{ get; set; }
        public virtual DbSet<ClientProject> ClientProject { get; set; }
        public virtual DbSet<ClientService> ClientService { get; set; }
        //public virtual DbSet<GlobalFilter> GlobalFilter { get; set; }
        public virtual DbSet<User> PMPAUser { get; set; }

         public virtual DbSet<GlobalFilter> GlobalFilter { get; set; }
        public virtual DbSet<UserGlobalFilter> UserGlobalFilter { get; set; }
        public virtual DbSet<UserProject> UserProject{ get; set; }
        public virtual DbSet<UserDetail> UserDetail { get; set; }
        public virtual DbSet<Role> Role{ get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<UserProfile> UserProfile { get; set; }

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
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");


            modelBuilder.ApplyConfiguration( new ClientMapping() );

            modelBuilder.ApplyConfiguration( new ClientProjectMapping() );

            modelBuilder.ApplyConfiguration( new ClientServiceMapping() );

            modelBuilder.ApplyConfiguration( new PMPAUserMapping() );

            modelBuilder.ApplyConfiguration( new GlobalFilterMapping() );



            modelBuilder.ApplyConfiguration( new UserGlobalFilterMapping() );

            modelBuilder.ApplyConfiguration( new UserProjectMapping() );

            modelBuilder.ApplyConfiguration( new UserDetailMapping() );

            modelBuilder.ApplyConfiguration( new RoleMapping() );

            modelBuilder.ApplyConfiguration( new UserRoleMapping() );
             modelBuilder.ApplyConfiguration( new UserProfileMapping() );
            //////////////////////////////////////////////////////////////



            //modelBuilder.ApplyConfiguration( new RoleModelMapping() );
            
            //modelBuilder.ApplyConfiguration( new UserModelMapping() );
            
          //  modelBuilder.ApplyConfiguration( new UserRoleModelMapping() );

            //modelBuilder.ApplyConfiguration( new UserProfileModelMapping() );
            
            


        //     modelBuilder.ApplyConfiguration( new UserProfileMapping() );

        //     modelBuilder.ApplyConfiguration( new ReportMasterModelMapping() );
            
        //     modelBuilder.ApplyConfiguration( new FormMasterModelMapping() );
            
        //     modelBuilder.ApplyConfiguration( new DashboardMasterModelMapping() );
            
        //     modelBuilder.ApplyConfiguration( new TargetRoleModelMapping() );
            
        //     modelBuilder.ApplyConfiguration( new ReportMasterTargetRoleModelMapping() );
            
        //     modelBuilder.ApplyConfiguration( new FormMasterTargetRoleModelMapping() );
           
        //     modelBuilder.ApplyConfiguration( new DashboardMasterTargetRoleModelMapping() );
           
        //     modelBuilder.ApplyConfiguration( new MenuTargetRoleModelMapping() );
           
        //     modelBuilder.ApplyConfiguration( new ReportCategoriesLookupModelMapping() );
           
        //     modelBuilder.ApplyConfiguration( new ReportFilterModelMapping() );
            
        //     modelBuilder.ApplyConfiguration( new ReportFilterDetailsModelMapping() );
            
        //     modelBuilder.ApplyConfiguration( new ReportDisplayModelMapping() );
            
        //     modelBuilder.ApplyConfiguration( new KPIDetailsModelMapping() );
            
        //     modelBuilder.ApplyConfiguration( new ReportDisplayKPIDetailsMapping() );
           
        //     modelBuilder.ApplyConfiguration( new ChartManagerKPIDetailsMapping() );
            
        //     modelBuilder.ApplyConfiguration( new RecordProcessingModelMapping() );
            
        //     modelBuilder.ApplyConfiguration( new ReportCalendarModelMapping() );
            
        //     modelBuilder.ApplyConfiguration( new SubReportModelMapping() );
           
        //     modelBuilder.ApplyConfiguration( new SubReportDetailsModelMapping() );
            
        //     modelBuilder.ApplyConfiguration( new ReportLinkModelMapping() );
            
        //     modelBuilder.ApplyConfiguration( new ReportMasterReportLinkModelMapping() );
            
        //     modelBuilder.ApplyConfiguration( new FormMasterReportLinkModelMapping() );
            
        //     modelBuilder.ApplyConfiguration( new ReportLinkDetailsModelMapping() );
            
        //     modelBuilder.ApplyConfiguration( new ChartDetailsModelMapping() );
            
        //     modelBuilder.ApplyConfiguration( new ChartManagerModelMapping() );
           
        //     modelBuilder.ApplyConfiguration( new ChartYAxesModelMapping() );
           
        //     modelBuilder.ApplyConfiguration( new FormSectionsModelMapping() );
            
        //     modelBuilder.ApplyConfiguration( new FormControlsModelMapping() );
            
        //     modelBuilder.ApplyConfiguration( new FormGridControlsModelMapping() );
            
        //     modelBuilder.ApplyConfiguration( new FormActionModelMapping() );
           
        //     modelBuilder.ApplyConfiguration( new FormActionParametersModelMapping() );
           
        //     modelBuilder.ApplyConfiguration( new ListDataModelMapping() );
            
        //     modelBuilder.ApplyConfiguration( new FormControlListDataModelMapping() );
            
        //     modelBuilder.ApplyConfiguration( new FormGridControlListDataModelMapping() );
            
        //     modelBuilder.ApplyConfiguration( new ListParameterModelMapping() );
            
        //     modelBuilder.ApplyConfiguration( new FormControlListParameterModelMapping() );
            
        //     modelBuilder.ApplyConfiguration( new FormGridControlListParameterModelMapping() );
           
        //     modelBuilder.ApplyConfiguration( new CompanyModelMapping() );
            
        //     modelBuilder.ApplyConfiguration( new BannerModelMapping() );
            
        //     modelBuilder.ApplyConfiguration( new BannerRoleModelMapping() );
            
        //     modelBuilder.ApplyConfiguration( new ContentModelMapping() );
            
        //     modelBuilder.ApplyConfiguration( new ContentRoleModelMapping() );
            
        //     modelBuilder.ApplyConfiguration( new MenuModelMapping() );
            
        //     modelBuilder.ApplyConfiguration( new MenuItemsModelMapping() );
           
        //     modelBuilder.ApplyConfiguration( new ReportMasterMenuItemsModelMapping() );
           
        //     modelBuilder.ApplyConfiguration( new FormMasterMenuItemsModelMapping() );
            
        //     modelBuilder.ApplyConfiguration( new DashboardMasterMenuItemsModelMapping() );
            
        //     modelBuilder.ApplyConfiguration( new DashboardDetailsModelMapping() );
            
        //     modelBuilder.ApplyConfiguration( new DashboardDetailsReportModelMapping() );

        //     modelBuilder.ApplyConfiguration( new DashboardDetailsChartModelMapping() );

        //     // modelBuilder.ApplyConfiguration( new ProfileModelMapping() );
        //     modelBuilder.ApplyConfiguration( new ProfileMapping() );

        //     modelBuilder.ApplyConfiguration( new ProfileDetailsModelMapping() );
            
        //    // modelBuilder.ApplyConfiguration( new VersagoUserDetailsModelMapping() );
           
        //     modelBuilder.ApplyConfiguration( new VersagoCustomersModelMapping() );
            
        //     modelBuilder.ApplyConfiguration( new SystemTimeZoneModelMapping() );
           
        //     modelBuilder.ApplyConfiguration( new VersagoEventsModelMapping() );
           
        //     modelBuilder.ApplyConfiguration( new ObjectFavouritesModelMapping() );
            
        //     modelBuilder.ApplyConfiguration( new ReportMasterFavouritesModelMapping() );
           
        //     modelBuilder.ApplyConfiguration( new FormMasterFavouritesModelMapping() );
           
        //     modelBuilder.ApplyConfiguration( new DashboardMasterFavouritesModelMapping() );
            
        //     modelBuilder.ApplyConfiguration( new CalculatedFieldFormulaModelMapping() );
            
        //     modelBuilder.ApplyConfiguration( new CountryModelMapping() );
           
        //     modelBuilder.ApplyConfiguration( new ReportFormatModelMapping() );
           
        //     modelBuilder.ApplyConfiguration( new ListDetailsModelMapping() );
           
        //     modelBuilder.ApplyConfiguration( new ListMasterModelMapping() );
            
        //     modelBuilder.ApplyConfiguration( new ControlRoleModelMapping() );
           
        //     modelBuilder.ApplyConfiguration( new FormControlRoleModelMapping() );
            
        //     modelBuilder.ApplyConfiguration( new FormGridControlRoleModelMapping() );
           
        //     modelBuilder.ApplyConfiguration( new VersagoMailLogModelMapping() );
            
        //     modelBuilder.ApplyConfiguration( new VersagoPaymentLogModelMapping() );

        //     modelBuilder.ApplyConfiguration( new CustomAPIModelMapping() );

        //     modelBuilder.ApplyConfiguration( new VersagoCustomAPIDetailsModelMapping() );

        //     modelBuilder.ApplyConfiguration( new ApplicationOptionsModelMapping() );

        }


    }
}