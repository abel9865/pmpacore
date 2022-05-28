using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DTOs
{
    public class RegisteredUserDto
    {
        [Required]
        public string FirstName{get;set;}
        [Required]
        public string LastName{get;set;}
        [Required]
        public string Email{get;set;}
        //[Required]
        //[RegularExpression("(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{8-12}$", ErrorMessage ="Password must meet the rules")]
        public string Password{get;set;}
        public string Address{get;set;}
        public string City{get;set;}
        public string State{get;set;}
        public string ZipCode{get;set;}
        public string Country { get; set; }
        public string PhoneNumber{get;set;}
        public bool? IsAdmin{get;set;}

        public bool Active { get; set; }
        public byte[] ProfileImage { get; set; }
        public string ProfilePath { get; set; }
        public string SysTimeZone { get; set; }
        public string SysTimeOffset { get; set; }

        
       public string ClientSideChangeBy {get;set;}
        public string UserId {get;set;}

        public Guid ClientId{get;set;}

        public ICollection<RoleDto> Roles{get;set;} = new List<RoleDto>();
    }
}