namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class NFTsRequest : BasePagingModel
    {
        public string OwnerAddress { get; set; }
        public string ContractAddress { get; set; }
        public List<string> ChainIds { get; set; }
    }
}