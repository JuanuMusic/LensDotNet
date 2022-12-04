namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class NftOwnershipInput
    {
        public string ContractAddress { get; set; }
        public string ChainID { get; set; }
        public ContractType ContractType { get; set; }
        public string TokenIds { get; set; }
    }
}