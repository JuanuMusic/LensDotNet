namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class ClaimableHandles
    {
        public List<ReservedClaimableHandle> ReservedHandles { get; set; }
        public bool CanClaimFreeTextHandle { get; set; }
    }
}