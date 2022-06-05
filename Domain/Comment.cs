using System;
namespace Domain
{
    public class Comment
    {
     
            public int Id { get; set; }

       public string Body { get; set; }
        public  AppUser author{ get; set; }
        public Resource Resource { get; set; } = new Resource();
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    }
}
