namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class GatedPublicationParamsInput
    {
        public NftOwnershipInput Nft { get; set; }
        public Erc20OwnershipInput Token { get; set; }
        public EoaOwnershipInput Eoa { get; set; }
        public ProfileOwnershipInput Profile { get; set; }
        public FollowConditionInput Follow { get; set; }
        public CollectConditionInput Collect { get; set; }
        public AndConditionInput And { get; set; }
        public OrConditionInput Or { get; set; }
        public string EncryptedSymmetricKey { get; set; }
    }
}