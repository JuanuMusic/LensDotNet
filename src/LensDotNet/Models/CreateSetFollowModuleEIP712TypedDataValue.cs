namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class CreateSetFollowModuleEIP712TypedDataValue
    {
        public string Nonce { get; set; }
        public string Deadline { get; set; }
        public string ProfileId { get; set; }
        public string FollowModule { get; set; }
        public string FollowModuleInitData { get; set; }
    }
}