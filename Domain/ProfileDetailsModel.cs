using System;

namespace Domain
{
    public class ProfileDetailsModel
    {
        public Guid ProfileId { get; set; }
        public string FieldName { get; set; }
        public string FieldDisplayName { get; set; }
        public bool IsText { get; set; }
        public string ProfileFieldIdentifier { get; set; }
        public Guid Id { get; set; }

        public virtual Profile Profile { get; set; }
    }
}
