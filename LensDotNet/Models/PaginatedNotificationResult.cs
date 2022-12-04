namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class PaginatedNotificationResult
    {
        public List<Notification> Items { get; set; }
        public PaginatedResultInfo PageInfo { get; set; }
    }
}