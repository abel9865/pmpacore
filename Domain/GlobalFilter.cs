using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Domain
{
    public partial class GlobalFilter
    {
        public GlobalFilter()
        {
            UserGlobalFilter = new HashSet<UserGlobalFilter>();
        }

        public Guid GlobalFilterId { get; set; }
        public string GlobalFilterName { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public string Remark { get; set; }
        public string SourceTableName { get; set; }
        public Guid? ConnectionId { get; set; }

        public virtual ICollection<UserGlobalFilter> UserGlobalFilter { get; set; }
    }
}
