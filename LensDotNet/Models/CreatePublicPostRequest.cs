namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class CreatePublicPostRequest
    {
        public string ProfileId { get; set; }
        public string ContentURI { get; set; }
        public CollectModuleParams CollectModule { get; set; }
        public ReferenceModuleParams ReferenceModule { get; set; }
        public GatedPublicationParamsInput Gated { get; set; }
    }
}