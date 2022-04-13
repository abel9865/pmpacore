using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Domain
{
    public partial class Profile
    {
        public Guid ProfileId { get; set; }
        public string ProfileName { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedByDate { get; set; }
        public Guid LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public string Remark { get; set; }
        public string SourceTableName { get; set; }
        public Guid ConnectionId { get; set; }

        //public virtual CompanyModel Company { get; set; }

        public virtual ICollection<UserProfile> UserProfiles { get; set; } = new HashSet<UserProfile>();
        public virtual ICollection<ProfileDetailsModel> ProfileDetails { get; set; } = new HashSet<ProfileDetailsModel>();
    }
}
