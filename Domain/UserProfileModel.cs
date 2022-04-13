using System;

namespace Domain
{
    public class UserProfileModel
    {
        public Guid UserId { get; set; }
        public string ProfileFieldName { get; set; }
        public string ProfileFieldValue { get; set; }
        public Guid ProfileId { get; set; }
        public Guid Id { get; set; }

        public virtual ProfileModel Profile { get; set; }
        public virtual User User { get; set; }
    }
}
