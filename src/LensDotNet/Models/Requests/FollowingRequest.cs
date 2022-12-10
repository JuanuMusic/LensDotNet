namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class FollowingRequest : BasePagingModel
    {
        public string Address { get; set; }
    }
}