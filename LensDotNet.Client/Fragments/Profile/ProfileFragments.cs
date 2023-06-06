using LensDotNet.Client.Fragments.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LensDotNet.Client.Fragments.Profile
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

    public record ProfileStatsFragment
    {
        public int TotalCollects { get; set; }
        public int TotalComments { get; set; }
        public int TotalFollowers { get; set; }
        public int TotalFollowing { get; set; }
        public int TotalMirrors { get; set; }
        public int TotalPosts { get; set; }
        public int TotalPublications { get; set; }
        public int CommentsTotal { get; internal set; }
        public int PostsTotal { get; internal set; }
        public int MirrorsTotal { get; internal set; }
        public int PublicationsTotal { get; internal set; }

        //   commentsTotal(forSources: $sources)
        //postsTotal(forSources: $sources)
        //mirrorsTotal(forSources: $sources)
        //publicationsTotal(forSources: $sources)
    }

    public record DoesFollowFragment
    {
        public EthereumAddress FollowerAddress { get; set; }

        public ProfileId ProfileId { get; set; }

        public bool Follows { get; set; }

        public bool IsFinalisedOnChain { get; set; }
    }

    public record FollowingFragment
    {
        public ProfileFragment Profile { get; set; }
    }

    public record FollowerFragment
    {
        public WalletFragment Wallet { get ; set; }
    }

    public record FollowerNftOwnedTokenIdsFragment
    {
        public ContractAddress FollowerNftAddress { get; set; }
        public string[] TokenIds { get; set; }
    }

    public record ExploreProfilesResultFragment
    {
        public ProfileFragment[] Profiles { get; set; }
    }
}