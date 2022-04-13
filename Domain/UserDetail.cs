using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.PMPA.Model;

namespace Domain
{
    public partial class UserDetail
    {
        
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string UniqueId { get; set; }
        public UserStatus Status { get; set; }
        public DateTime Initiateddatetime { get; set; }
        public DateTime? Setdatetime { get; set; }
        public string Oldpwd { get; set; }
        public string Newpwd { get; set; }

        public virtual User User { get; set; }
    }
}
