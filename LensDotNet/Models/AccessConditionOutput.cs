namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class AccessConditionOutput
    {
        public NftOwnershipOutput Nft { get; set; }
        public Erc20OwnershipOutput Token { get; set; }
        public EoaOwnershipOutput Eoa { get; set; }
        public ProfileOwnershipOutput Profile { get; set; }
        public FollowConditionOutput Follow { get; set; }
        public CollectConditionOutput Collect { get; set; }
        public AndConditionOutput And { get; set; }
        public OrConditionOutput Or { get; set; }
    }
}