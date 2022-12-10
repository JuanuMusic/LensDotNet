namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class SybilDotOrgIdentity
    {
        public bool Verified { get; set; }
        public SybilDotOrgIdentitySource Source { get; set; }
    }
}