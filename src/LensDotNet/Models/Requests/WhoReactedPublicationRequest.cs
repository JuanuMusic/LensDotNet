namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class WhoReactedPublicationRequest : BasePagingModel
    {
        public string PublicationId { get; set; }
    }
}