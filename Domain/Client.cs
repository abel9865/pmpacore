using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Domain
{
    public partial class Client
    {
        public Client()
        {
            ClientProjects = new HashSet<ClientProject>();
            ClientServices = new HashSet<ClientService>();
        }

        public Guid ClientId { get; set; }
        public string ClientCode { get; set; }
        public string ClientName { get; set; }
        public string Comments { get; set; }

        public virtual ICollection<ClientProject> ClientProjects { get; set; }
        public virtual ICollection<ClientService> ClientServices { get; set; }

        public virtual ICollection<AppUser> Users { get; set; }
    }
}
