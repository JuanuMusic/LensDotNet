namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class NFT
    {
        public string ContractName { get; set; }
        public string ContractAddress { get; set; }
        public string Symbol { get; set; }
        public string TokenId { get; set; }
        public List<Owner> Owners { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ContentURI { get; set; }
        public NFTContent OriginalContent { get; set; }
        public string ChainId { get; set; }
        public string CollectionName { get; set; }
        public string ErcType { get; set; }
    }
}