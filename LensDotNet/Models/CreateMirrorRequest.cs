namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class CreateMirrorRequest
    {
        public string ProfileId { get; set; }
        public string PublicationId { get; set; }
        public ReferenceModuleParams ReferenceModule { get; set; }
    }
}