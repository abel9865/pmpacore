using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Domain
{
    public partial class ClientProject
    {
        public ClientProject()
        {
            Role = new HashSet<Role>();
        }
        public Guid ProjectId { get; set; }
        public Guid ClientId { get; set; }
        public string ProjectTitle { get; set; }
        public string ProjectDescription{get; set;}
        public bool ProjectStatus { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDate { get; set; }

        public virtual Client Client { get; set; }
        public virtual ICollection<Role> Role { get; set; } = new List<Role>();
    }
}
