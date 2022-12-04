namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class ProxyActionStatusResultUnion
    {
        public ProxyActionStatusResult ProxyActionStatusResult { get; set; }
        public ProxyActionError ProxyActionError { get; set; }
        public ProxyActionQueued ProxyActionQueued { get; set; }
    }
}