namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class UpdateProfileImageRequest
    {
        public string ProfileId { get; set; }
        public string Url { get; set; }
        public NFTData NftData { get; set; }
    }
}