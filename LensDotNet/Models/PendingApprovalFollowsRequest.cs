namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class PendingApprovalFollowsRequest
    {
        public string Limit { get; set; }
        public string Cursor { get; set; }
    }
}