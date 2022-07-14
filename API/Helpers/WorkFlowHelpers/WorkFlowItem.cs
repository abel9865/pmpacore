using System;
using System.Collections.Generic;

namespace API.Helpers.WorkFlowHelpers
{
    public class WorkFlowItem
    {
        public string id { get; set; }
        public string definitionId { get; set; }
        public string tenantId { get; set; }
        public string name { get; set; }
        public string displayName { get; set; }
        public int version { get; set; }
        public bool isSingleton { get; set; }
        public string persistenceBehavior { get; set; }
        public bool isPublished { get; set; }
        public bool isLatest { get; set; }
        public string customAttributes { get; set; }
    }

    public class WorkFlowItems
    {
        public List<WorkFlowItem> items { get; set; }
        public int totalCount { get; set; }
    }
}

