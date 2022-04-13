

using System;
using Domain.PMPA.Model;

namespace Domain
{
    public abstract class TargetRoleModel
    {
        public Guid Id { get; set; }
        public Guid  ReportId { get; set; }
        public Guid RoleId { get; set; }
       public ObjectType ObjectType { get; set; }
        public int IsFavorite { get; set; }
        public virtual Role Role { get; set; }
        
    }
}
