namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class PublicationStats
    {
        public string Id { get; set; }
        public int TotalAmountOfMirrors { get; set; }
        public int TotalAmountOfCollects { get; set; }
        public int TotalAmountOfComments { get; set; }
        public int TotalUpvotes { get; set; }
        public int TotalDownvotes { get; set; }
        public int CommentsTotal { get; set; }
    }
}