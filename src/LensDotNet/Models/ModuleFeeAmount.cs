namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class ModuleFeeAmount
    {
        public Erc20 Asset { get; set; }
        public string Value { get; set; }
    }
}