namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class GlobalProtocolStats
    {
        public int TotalProfiles { get; set; }
        public int TotalBurntProfiles { get; set; }
        public int TotalPosts { get; set; }
        public int TotalMirrors { get; set; }
        public int TotalComments { get; set; }
        public int TotalCollects { get; set; }
        public int TotalFollows { get; set; }
        public List<Erc20Amount> TotalRevenue { get; set; }
    }
}