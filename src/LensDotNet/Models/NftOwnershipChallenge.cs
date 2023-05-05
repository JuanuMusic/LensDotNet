namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class NftOwnershipChallenge
    {
        public string ContractAddress { get; set; }
        public string TokenId { get; set; }
        public string ChainId { get; set; }
    }
}