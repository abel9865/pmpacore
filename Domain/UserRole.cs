using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UserRole
    {
        public Guid UserRoleId { get; set; }
        public Guid RoleId { get; set; }
        public Guid UserId { get; set; }
        public bool Status { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public string Comments { get; set; }

        public virtual Role Role { get; set; }

        public virtual User User { get; set; }
    }
}
