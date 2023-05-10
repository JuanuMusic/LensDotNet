using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LensDotNet.Client.Fragments
{
    public record ProfileFragment
    {   
        public ProfileId Id { get; set; }
        public string? Name { get; set; }
        public string? Bio { get; set; }
        public string Handle { get; set; }
        public string OwnedBy { get; set; }
        public ProfileInterest[]? Interests { get; set; }
        public bool IsDefault { get; set; }
        public bool IsFollowedByMe { get; set; }
        public bool IsFollowing { get; set; }
        public string Picture { get; set; }
    }
}