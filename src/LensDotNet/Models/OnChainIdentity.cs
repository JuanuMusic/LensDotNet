namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class OnChainIdentity
    {
        public bool ProofOfHumanity { get; set; }
        public EnsOnChainIdentity Ens { get; set; }
        public SybilDotOrgIdentity SybilDotOrg { get; set; }
        public WorldcoinIdentity Worldcoin { get; set; }
    }
}