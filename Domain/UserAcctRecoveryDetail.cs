using System;
using Domain.PMPA.Model;

namespace Domain
{
    public class UserAcctRecoveryDetail
    {
       public Guid Id { get; set; }
        public string UserId { get; set; }
        public string RecoveryToken { get; set; }
        public UserAcctRecoveryStatus Status { get; set; }
        public DateTime RequestCreateDate { get; set; }
        public DateTime? RequestCompleteDate { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public AppUser User { get; set; }
    }
}
