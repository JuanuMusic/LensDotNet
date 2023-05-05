namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Erc20
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public int Decimals { get; set; }
        public string Address { get; set; }
    }
}