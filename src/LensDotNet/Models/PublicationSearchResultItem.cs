namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class PublicationSearchResultItem
    {
        public Post Post { get; set; }
        public Comment Comment { get; set; }
    }
}