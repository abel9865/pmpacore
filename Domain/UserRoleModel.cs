
using System;

namespace Domain
{
    public class UserRoleModel
    {
        public virtual Guid Id { get; set; }
        public virtual Guid RoleId { get; set; }        
        public virtual Guid UserId { get; set; }        
        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
