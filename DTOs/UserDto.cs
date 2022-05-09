using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTOs
{
    public class UserDto
    {
        public Guid UserId{get;set;}
        public string FirstName{get;set;}
        public string LastName{get;set;}
        public string Email{get;set;}
        public Guid ClientId{get;set;}
        public string Token{get;set;}
        public string Image{get;set;}
    }
}