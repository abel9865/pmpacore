using System;
using System.Collections.Generic;

namespace API.Helpers.DashboardHelpers
{
    public partial class DashboardItem
    {
        public bool CanRead { get; set; }
        public bool CanWrite { get; set; }
        public bool CanDelete { get; set; }
        public bool CanDownload { get; set; }
        public bool CanSchedule { get; set; }
        public bool CanOpen { get; set; }
        public bool CanMove { get; set; }
        public bool CanCopy { get; set; }
        public bool CanClone { get; set; }
        public bool CanCreateItem { get; set; }
        public string Id { get; set; }
        public string ItemType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ItemLocation { get; set; }
        public long CreatedById { get; set; }
        public string CreatedByDisplayName { get; set; }
        public long ModifiedById { get; set; }
        public string ModifiedByFullName { get; set; }
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public DateTimeOffset ItemModifiedDate { get; set; }
        public DateTimeOffset ItemCreatedDate { get; set; }
        public bool IsMultiDashboard { get; set; }
        public bool IsFavorite { get; set; }
        public bool IsPublic { get; set; }
        public List<TabDetail> TabDetail { get; set; }
    }

    public partial class TabDetail
    {
        public string MultiTabDashboardId { get; set; }
        public string DashboardId { get; set; }
        public string Name { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
    }
}
