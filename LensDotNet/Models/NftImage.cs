namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class NftImage
    {
        public string ContractAddress { get; set; }
        public string TokenId { get; set; }
        public string Uri { get; set; }
        public int ChainId { get; set; }
        public bool Verified { get; set; }
    }
}