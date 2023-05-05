namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class ProfileStats
    {
        public string Id { get; set; }
        public int TotalFollowers { get; set; }
        public int TotalFollowing { get; set; }
        public int TotalPosts { get; set; }
        public int TotalComments { get; set; }
        public int TotalMirrors { get; set; }
        public int TotalPublications { get; set; }
        public int TotalCollects { get; set; }
        public int CommentsTotal { get; set; }
        public int PostsTotal { get; set; }
        public int MirrorsTotal { get; set; }
        public int PublicationsTotal { get; set; }
    }
}