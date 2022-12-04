namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Profile
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public string FollowNftAddress { get; set; }
        public string Metadata { get; set; }
        public string Handle { get; set; }
        public ProfileMedia Picture { get; set; }
        public ProfileMedia CoverPicture { get; set; }
        public string OwnedBy { get; set; }
        public Dispatcher Dispatcher { get; set; }
        public ProfileStats Stats { get; set; }
        public FollowModule FollowModule { get; set; }
        public bool IsDefault { get; set; }
        public List<Attribute> Attributes { get; set; }
        public OnChainIdentity OnChainIdentity { get; set; }
        public List<string> Interests { get; set; }
        public bool IsFollowedByMe { get; set; }
        public bool IsFollowing { get; set; }
    }
}