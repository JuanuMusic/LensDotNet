namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Following
    {
        public Profile Profile { get; set; }
        public int TotalAmountOfTimesFollowing { get; set; }
    }
}