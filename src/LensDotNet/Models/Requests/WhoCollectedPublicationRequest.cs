namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class WhoCollectedPublicationRequest : BasePagingModel
    {
        public string PublicationId { get; set; }
    }
}