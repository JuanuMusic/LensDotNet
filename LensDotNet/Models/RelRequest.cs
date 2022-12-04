namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class RelRequest
    {
        public string Secret { get; set; }
        public string EthereumAddress { get; set; }
    }
}