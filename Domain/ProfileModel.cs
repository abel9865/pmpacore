using System;
using System.Collections.Generic;

namespace Domain
{
    public class ProfileModel
    {
       
        public Guid ProfileId { get; set; }
        public string ProfileName { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int UpdatedUserId { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        public string Remark { get; set; }
        public string SourceTableName { get; set; }
        public Guid CompanyId { get; set; }

        //public virtual CompanyModel Company { get; set; }
        public virtual User CreatedUser { get; set; }
        public virtual User UpdatedUser { get; set; }
        public virtual ICollection<UserProfileModel> UserProfiles { get; set; } = new HashSet<UserProfileModel>();
        public virtual ICollection<ProfileDetailsModel> ProfileDetails { get; set; } = new HashSet<ProfileDetailsModel>();
    }
}
