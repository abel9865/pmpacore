using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Domain
{
    public partial class UserGlobalFilter
    {
        public Guid UserGlobalFilterId { get; set; }
        public Guid UserId { get; set; }
        public string GlobalFilterFieldName { get; set; }
        public string GlobalFilterFieldValue { get; set; }
        public Guid GlobalFilterId { get; set; }

        public virtual GlobalFilter GlobalFilter { get; set; }
        public virtual User User { get; set; }
    }
}
