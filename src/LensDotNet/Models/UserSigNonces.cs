namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class UserSigNonces
    {
        public string LensHubOnChainSigNonce { get; set; }
        public string PeripheryOnChainSigNonce { get; set; }
    }
}