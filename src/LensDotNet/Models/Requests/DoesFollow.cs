namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class DoesFollow
    {
        public string FollowerAddress { get; set; }
        public string ProfileId { get; set; }
    }
}