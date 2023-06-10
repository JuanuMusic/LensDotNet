using System.Dynamic;

namespace LensDotNet.Models.Profile
{
    public class ProfileFragment
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public string FollowNftAddress { get; set; }
        public string Metadata { get; set; }
        public string Handle { get; set; }
        public DynamicObject Picture { get; set; }
        public DynamicObject CoverPicture { get; set; }
        public string OwnedBy { get; set; }
        public object Dispatcher { get; set; }
        public object Stats { get; set; }
        public object FollowModule { get; set; }
        public bool IsDefault { get; set; }
        public List<Attribute> Attributes { get; set; }
        public object OnChainIdentity { get; set; }
        public List<string> Interests { get; set; }
        public bool IsFollowedByMe { get; set; }
        public bool IsFollowing { get; set; }
    }
}
