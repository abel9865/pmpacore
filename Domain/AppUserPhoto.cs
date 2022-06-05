using System;
namespace Domain
{
    public class AppUserPhoto
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public string UserId { get; set; }

        public AppUser User { get; set; }
    }
}
