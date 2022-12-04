namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class CollectConditionInput
    {
        public string PublicationId { get; set; }
        public bool? ThisPublication { get; set; }
    }
}