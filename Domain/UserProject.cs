using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Domain
{
    public partial class UserProject
    {
        public Guid UserProjectId { get; set; }
        public Guid ProjectId { get; set; }
        public Guid UserId { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public bool Status { get; set; }
        public string Comment { get; set; }

        public virtual ClientProject Project { get; set; }
        public virtual User User { get; set; }
    }
}
