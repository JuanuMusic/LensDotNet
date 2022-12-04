namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Follower
    {
        public Wallet Wallet { get; set; }
        public int TotalAmountOfTimesFollowed { get; set; }
    }
}