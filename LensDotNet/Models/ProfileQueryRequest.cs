namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class ProfileQueryRequest
    {
        public string Limit { get; set; }
        public string Cursor { get; set; }
        public List<string> ProfileIds { get; set; }
        public List<string> OwnedBy { get; set; }
        public List<string> Handles { get; set; }
        public string WhoMirroredPublicationId { get; set; }
    }
}