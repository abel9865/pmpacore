using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Domain
{
    public partial class User
    {
        public User()
        {
            InverseLastUpdatedByNavigation = new HashSet<User>();
            UserGlobalFilter = new HashSet<UserGlobalFilter>();
        }

        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string CompanyName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public int? Extension { get; set; }
        public string Fax { get; set; }
        public bool IncludeinMailings { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime LastUpdateDateTime { get; set; }
        public string B1recordId { get; set; }
        public string B1syncFailureReason { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? LastUpdatedBy { get; set; }
        public string CompanyCode { get; set; }
        public string Country { get; set; }
        public string QryGroup1 { get; set; }
        public string QryGroup2 { get; set; }
        public string QryGroup3 { get; set; }
        public string QryGroup4 { get; set; }
        public string QryGroup5 { get; set; }
        public string QryGroup6 { get; set; }
        public string QryGroup7 { get; set; }
        public string QryGroup8 { get; set; }
        public string QryGroup9 { get; set; }
        public string QryGroup10 { get; set; }
        public string QryGroup11 { get; set; }
        public string QryGroup12 { get; set; }
        public string QryGroup13 { get; set; }
        public string QryGroup14 { get; set; }
        public string QryGroup15 { get; set; }
        public string QryGroup16 { get; set; }
        public string QryGroup17 { get; set; }
        public string QryGroup18 { get; set; }
        public string QryGroup19 { get; set; }
        public string QryGroup20 { get; set; }
        public string QryGroup21 { get; set; }
        public string QryGroup22 { get; set; }
        public string QryGroup23 { get; set; }
        public string QryGroup24 { get; set; }
        public string QryGroup25 { get; set; }
        public string QryGroup26 { get; set; }
        public string QryGroup27 { get; set; }
        public string QryGroup28 { get; set; }
        public string QryGroup29 { get; set; }
        public string QryGroup30 { get; set; }
        public string QryGroup31 { get; set; }
        public string QryGroup32 { get; set; }
        public string QryGroup33 { get; set; }
        public string QryGroup34 { get; set; }
        public string QryGroup35 { get; set; }
        public string QryGroup36 { get; set; }
        public string QryGroup37 { get; set; }
        public string QryGroup38 { get; set; }
        public string QryGroup39 { get; set; }
        public string QryGroup40 { get; set; }
        public string QryGroup41 { get; set; }
        public string QryGroup42 { get; set; }
        public string QryGroup43 { get; set; }
        public string QryGroup44 { get; set; }
        public string QryGroup45 { get; set; }
        public string QryGroup46 { get; set; }
        public string QryGroup47 { get; set; }
        public string QryGroup48 { get; set; }
        public string QryGroup49 { get; set; }
        public string QryGroup50 { get; set; }
        public string QryGroup51 { get; set; }
        public string QryGroup52 { get; set; }
        public string QryGroup53 { get; set; }
        public string QryGroup54 { get; set; }
        public string QryGroup55 { get; set; }
        public string QryGroup56 { get; set; }
        public string QryGroup57 { get; set; }
        public string QryGroup58 { get; set; }
        public string QryGroup59 { get; set; }
        public string QryGroup60 { get; set; }
        public string QryGroup61 { get; set; }
        public string QryGroup62 { get; set; }
        public string QryGroup63 { get; set; }
        public string QryGroup64 { get; set; }
        public bool HasAdmin { get; set; }
        public bool Active { get; set; }
        public byte[] ProfileImage { get; set; }
        public string ProfilePath { get; set; }
        public string SysTimeZone { get; set; }
        public string SysTimeOffset { get; set; }
        public Guid? ClientId { get; set; }

        public virtual User LastUpdatedByNavigation { get; set; }
        public virtual ICollection<User> InverseLastUpdatedByNavigation { get; set; }
        public virtual ICollection<UserGlobalFilter> UserGlobalFilter { get; set; }
        public virtual Client Client { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();
        public virtual ICollection<UserDetail> UserDetails { get; set; } = new HashSet<UserDetail>();

        public virtual ICollection<UserProject> UserProjects { get; set; } = new HashSet<UserProject>();

       public virtual ICollection<UserProfile> UserProfiles { get; set; } = new HashSet<UserProfile>();

    //     public virtual ICollection<ReportMasterFavouritesModel> ReportMasterFavourites { get; set; } = new HashSet<ReportMasterFavouritesModel>();
    //     public virtual ICollection<DashboardMasterFavouritesModel> DashboardMasterFavourites { get; set; } = new HashSet<DashboardMasterFavouritesModel>();
    //     public virtual ICollection<FormMasterFavouritesModel> FormMasterFavourites { get; set; } = new HashSet<FormMasterFavouritesModel>();


    //     /// <summary>
    //     /// ///////////////////////////////////////////////////////////////////////////
    //     /// </summary>



    //    // public virtual ICollection<RoleModel> RoleCreatedUsers { get; set; } = new HashSet<RoleModel>();
    //    // public virtual ICollection<RoleModel> RoleUpdatedUsers { get; set; } = new HashSet<RoleModel>();
    //     //public virtual ICollection<UserRoleModel> UserRoles { get; set; } = new HashSet<UserRoleModel>();
    //     //public virtual ICollection<MenuModel> MenuCreatedUsers { get; set; } = new HashSet<MenuModel>();
    //     //public virtual ICollection<MenuModel> MenuUpdatedUsers { get; set; } = new HashSet<MenuModel>();
    //   //  public virtual ICollection<UserProfileModel> UserProfiles { get; set; } = new HashSet<UserProfileModel>();

    //     //public virtual ICollection<UserDetail> UserDetails { get; set; } = new HashSet<UserDetail>();
    //     public virtual ICollection<BannerModel> BannerCreatedUsers { get; set; } = new HashSet<BannerModel>();
    //     public virtual ICollection<BannerModel> BannerUpdatedUsers { get; set; } = new HashSet<BannerModel>();
    //     public virtual ICollection<ContentModel> ContentCreatedUsers { get; set; } = new HashSet<ContentModel>();
    //     public virtual ICollection<ContentModel> ContentUpdatedUsers { get; set; } = new HashSet<ContentModel>();

    //     public virtual ICollection<DashboardMasterModel> DashboardMasterCreatedUsers { get; set; } = new HashSet<DashboardMasterModel>();
    //     public virtual ICollection<DashboardMasterModel> DashboardMasterUpdatedUsers { get; set; } = new HashSet<DashboardMasterModel>();

    //     public virtual ICollection<CustomAPIModel> ApiCreatedUsers { get; set; } = new HashSet<CustomAPIModel>();
    //     public virtual ICollection<CustomAPIModel> ApiUpdatedUsers { get; set; } = new HashSet<CustomAPIModel>();
    //     //public virtual ICollection<VersagoCustomersModel> CustomerCreatedUsers { get; set; } = new HashSet<VersagoCustomersModel>();
    //     //public virtual ICollection<VersagoCustomersModel> CustomerUpdatedUsers { get; set; } = new HashSet<VersagoCustomersModel>();
    //     //public virtual ICollection<VersagoMailLogModel> MailLogs { get; set; } = new HashSet<VersagoMailLogModel>();
    //     public virtual ICollection<FormMasterModel> FormMasterCreatedUsers { get; set; } = new HashSet<FormMasterModel>();
    //     public virtual ICollection<FormMasterModel> FormMasterUpdatedUsers { get; set; } = new HashSet<FormMasterModel>();
    //     public virtual ICollection<FormMasterModel> FormMasterOwners { get; set; } = new HashSet<FormMasterModel>();
    //     //public virtual ICollection<CompanyModel> CompanyCreatedUsers { get; set; } = new HashSet<CompanyModel>();
    //     //public virtual ICollection<CompanyModel> CompanyUpdatedUsers { get; set; } = new HashSet<CompanyModel>();
    //     //public virtual ICollection<ProfileModel> ProfileCreatedUsers { get; set; } = new HashSet<ProfileModel>();
    //     //public virtual ICollection<ProfileModel> ProfileUpdatedUsers { get; set; } = new HashSet<ProfileModel>();
    //     public virtual ICollection<ReportMasterModel> ReportMasterCreatedUsers { get; set; } = new HashSet<ReportMasterModel>();
    //     public virtual ICollection<ReportMasterModel> ReportMasterUpdatedUsers { get; set; } = new HashSet<ReportMasterModel>();

    }
}
