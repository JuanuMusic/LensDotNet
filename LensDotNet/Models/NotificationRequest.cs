namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class NotificationRequest
    {
        public string Limit { get; set; }
        public string Cursor { get; set; }
        public string ProfileId { get; set; }
        public List<NotificationTypes> NotificationTypes { get; set; }
        public List<string> Sources { get; set; }
        public PublicationMetadataFilters Metadata { get; set; }
        public List<CustomFiltersTypes> CustomFilters { get; set; }
    }
}