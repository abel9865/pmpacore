using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UserRole
    {
       // public Guid UserRoleId { get; set; }
        public Guid RoleId { get; set; }
        public string UserId { get; set; }
        public bool Status { get; set; }

        public bool IsDefault{get;set;}
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public string Comments { get; set; }

        public virtual Role Role { get; set; }

        public virtual AppUser User { get; set; }
    }
}
