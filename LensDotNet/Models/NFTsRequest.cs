namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class NFTsRequest
    {
        public string Limit { get; set; }
        public string Cursor { get; set; }
        public string OwnerAddress { get; set; }
        public string ContractAddress { get; set; }
        public List<string> ChainIds { get; set; }
    }
}