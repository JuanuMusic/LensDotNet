namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Erc20OwnershipInput
    {
        public string ContractAddress { get; set; }
        public string ChainID { get; set; }
        public string Amount { get; set; }
        public float Decimals { get; set; }
        public ScalarOperator Condition { get; set; }
    }
}