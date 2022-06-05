using System;
namespace DTOs
{
    public class CommentDto
    {
       public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Body { get; set; }
        public string UserEmail { get; set; }
        public string DisplayName { get; set; }
        public string Image { get; set; }
    }
}
