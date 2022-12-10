namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class FollowersRequest : BasePagingModel
    {
        public string? ProfileId { get; set; }
    }
}