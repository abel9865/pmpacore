using System;
using System.Collections.Generic;
using Domain.PMPA.Model;

namespace Domain
{
    public class Resource
    {
       public Guid ResourceId { get; set; }
        public ResourceType ResourceType { get; set; }
        public Guid ResourceLinkId { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
