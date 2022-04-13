using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Domain
{
    public partial class UserProfile
    {
        public Guid UserProfileId { get; set; }
        public Guid UserId { get; set; }
        public string ProfileFieldName { get; set; }
        public string ProfileFieldValue { get; set; }
        public Guid ProfileId { get; set; }

        public virtual Profile Profile { get; set; }
        public virtual User User
        {
            get; set;
        }
    }
}
