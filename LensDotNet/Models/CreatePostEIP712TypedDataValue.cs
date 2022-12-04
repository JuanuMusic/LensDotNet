namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class CreatePostEIP712TypedDataValue
    {
        public string Nonce { get; set; }
        public string Deadline { get; set; }
        public string ProfileId { get; set; }
        public string ContentURI { get; set; }
        public string CollectModule { get; set; }
        public string CollectModuleInitData { get; set; }
        public string ReferenceModule { get; set; }
        public string ReferenceModuleInitData { get; set; }
    }
}