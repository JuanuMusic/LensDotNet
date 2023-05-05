namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Wallet
    {
        public string Address { get; set; }
        public Profile DefaultProfile { get; set; }
    }
}