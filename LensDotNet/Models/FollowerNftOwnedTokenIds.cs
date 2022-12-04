namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class FollowerNftOwnedTokenIds
    {
        public string FollowerNftAddress { get; set; }
        public List<string> TokensIds { get; set; }
    }
}