using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Domain
{
    public partial class AppUser:IdentityUser
    {

         public Guid UserId { get; set; }
     
        public string FirstName { get; set; }
        public string LastName { get; set; }
          public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }

         public DateTime? CreateDateTime { get; set; }
        public DateTime? LastUpdateDateTime { get; set; }
        

        public Guid? CreatedBy { get; set; }
        public Guid? LastUpdatedBy { get; set; }
       
        public string Country { get; set; }
           public bool IsAdmin { get; set; }
        public bool Active { get; set; }
        public byte[] ProfileImage { get; set; }
        public string ProfilePath { get; set; }
        public string SysTimeZone { get; set; }
        public string SysTimeOffset { get; set; }
        public Guid? ClientId { get; set; }
        

       
    }
}
