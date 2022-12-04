namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class EIP712TypedDataDomain
    {
        public string Name { get; set; }
        public string ChainId { get; set; }
        public string Version { get; set; }
        public string VerifyingContract { get; set; }
    }
}