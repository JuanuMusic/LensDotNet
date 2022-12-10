namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class NftOwnershipChallengeRequest
    {
        public string EthereumAddress { get; set; }
        public List<NftOwnershipChallenge> Nfts { get; set; }
    }
}