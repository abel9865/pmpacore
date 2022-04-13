using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Domain
{
    public partial class ClientService
    {
        public Guid ClientServiceId { get; set; }
        public Guid ClientId { get; set; }
        public bool Pm { get; set; }
        public bool Pa { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public string Comment { get; set; }

        public virtual Client Client { get; set; }
    }
}
