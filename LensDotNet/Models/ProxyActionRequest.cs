namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class ProxyActionRequest
    {
        public FollowProxyAction Follow { get; set; }
        public CollectProxyAction Collect { get; set; }
    }
}