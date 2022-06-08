using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTOs
{
    public class RoleDto
    {
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
        public bool Active { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDate { get; set; }

        public Guid ClientId { get; set; }
        public Guid ProjectId { get; set; }

        //public ICollection<RegisteredUserDto> RegisteredUsers { get; set; } = new List<RegisteredUserDto>();

        // public ICollection<RoleResource> RoleResources { get; set; }
    }
}