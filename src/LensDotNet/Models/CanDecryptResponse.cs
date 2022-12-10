namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class CanDecryptResponse
    {
        public bool Result { get; set; }
        public DecryptFailReason Reasons { get; set; }
    }
}