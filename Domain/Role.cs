using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Role
    {
        public Role()
        {
            UserRoles = new HashSet<UserRole>();
        }

        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
        public bool IsSystemRole { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public int DefaultObjectId { get; set; }
        public short DefaultObjectType { get; set; }
        public Guid ProjectId { get; set; }

        public virtual ClientProject Project { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }


        //public virtual User CreateUser { get; set; }
        //public virtual User UpdatedUser { get; set; }
        //public virtual ICollection<UserRole> RoleUsers { get; set; } = new HashSet<UserRole>();
        //public virtual ICollection<TargetRoleModel> ReportRoles { get; set; } = new HashSet<TargetRoleModel>();

        // public virtual ICollection<ReportMasterTargetRoleModel> ReportRoles { get; set; } = new HashSet<ReportMasterTargetRoleModel>();
        // public virtual ICollection<DashboardMasterTargetRoleModel> DashboardRoles { get; set; } = new HashSet<DashboardMasterTargetRoleModel>();
        // public virtual ICollection<FormMasterTargetRoleModel> FormRoles { get; set; } = new HashSet<FormMasterTargetRoleModel>();
        // public virtual ICollection<MenuTargetRoleModel> MenuRoles { get; set; } = new HashSet<MenuTargetRoleModel>();

        // public virtual ICollection<BannerRoleModel> BannerRoles { get; set; } = new HashSet<BannerRoleModel>();
        // public virtual ICollection<ContentRoleModel> ContentRoles { get; set; } = new HashSet<ContentRoleModel>();
        // public virtual ICollection<ControlRoleModel> ControlRole { get; set; } = new HashSet<ControlRoleModel>();


    }
}
