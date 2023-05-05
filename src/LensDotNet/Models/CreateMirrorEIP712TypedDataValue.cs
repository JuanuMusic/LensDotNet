namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class CreateMirrorEIP712TypedDataValue
    {
        public string Nonce { get; set; }
        public string Deadline { get; set; }
        public string ProfileId { get; set; }
        public string ProfileIdPointed { get; set; }
        public string PubIdPointed { get; set; }
        public string ReferenceModuleData { get; set; }
        public string ReferenceModule { get; set; }
        public string ReferenceModuleInitData { get; set; }
    }
}