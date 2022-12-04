namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public static class QueryExtensions
    {
        public static ReactionTypes Reaction(this Comment comment, ReactionFieldResolverRequest request)
        {
            throw new NotImplementedException("This method is not implemented. It exists solely for query purposes.");
        }

        public static bool HasCollectedByMe(this Comment comment, bool isFinalisedOnChain)
        {
            throw new NotImplementedException("This method is not implemented. It exists solely for query purposes.");
        }

        public static CanCommentResponse CanComment(this Comment comment, string profileId)
        {
            throw new NotImplementedException("This method is not implemented. It exists solely for query purposes.");
        }

        public static CanMirrorResponse CanMirror(this Comment comment, string profileId)
        {
            throw new NotImplementedException("This method is not implemented. It exists solely for query purposes.");
        }

        public static CanDecryptResponse CanDecrypt(this Comment comment, string profileId, string address)
        {
            throw new NotImplementedException("This method is not implemented. It exists solely for query purposes.");
        }

        public static List<string> Mirrors(this Comment comment, string by)
        {
            throw new NotImplementedException("This method is not implemented. It exists solely for query purposes.");
        }

        public static ReactionTypes Reaction(this Mirror mirror, ReactionFieldResolverRequest request)
        {
            throw new NotImplementedException("This method is not implemented. It exists solely for query purposes.");
        }

        public static bool HasCollectedByMe(this Mirror mirror, bool isFinalisedOnChain)
        {
            throw new NotImplementedException("This method is not implemented. It exists solely for query purposes.");
        }

        public static CanCommentResponse CanComment(this Mirror mirror, string profileId)
        {
            throw new NotImplementedException("This method is not implemented. It exists solely for query purposes.");
        }

        public static CanMirrorResponse CanMirror(this Mirror mirror, string profileId)
        {
            throw new NotImplementedException("This method is not implemented. It exists solely for query purposes.");
        }

        public static CanDecryptResponse CanDecrypt(this Mirror mirror, string profileId, string address)
        {
            throw new NotImplementedException("This method is not implemented. It exists solely for query purposes.");
        }

        public static ReactionTypes Reaction(this Post post, ReactionFieldResolverRequest request)
        {
            throw new NotImplementedException("This method is not implemented. It exists solely for query purposes.");
        }

        public static bool HasCollectedByMe(this Post post, bool isFinalisedOnChain)
        {
            throw new NotImplementedException("This method is not implemented. It exists solely for query purposes.");
        }

        public static CanCommentResponse CanComment(this Post post, string profileId)
        {
            throw new NotImplementedException("This method is not implemented. It exists solely for query purposes.");
        }

        public static CanMirrorResponse CanMirror(this Post post, string profileId)
        {
            throw new NotImplementedException("This method is not implemented. It exists solely for query purposes.");
        }

        public static CanDecryptResponse CanDecrypt(this Post post, string profileId, string address)
        {
            throw new NotImplementedException("This method is not implemented. It exists solely for query purposes.");
        }

        public static List<string> Mirrors(this Post post, string by)
        {
            throw new NotImplementedException("This method is not implemented. It exists solely for query purposes.");
        }

        public static bool IsFollowedByMe(this Profile profile, bool isFinalisedOnChain)
        {
            throw new NotImplementedException("This method is not implemented. It exists solely for query purposes.");
        }

        public static bool IsFollowing(this Profile profile, string who)
        {
            throw new NotImplementedException("This method is not implemented. It exists solely for query purposes.");
        }

        public static int CommentsTotal(this ProfileStats profileStats, List<string> forSources)
        {
            throw new NotImplementedException("This method is not implemented. It exists solely for query purposes.");
        }

        public static int PostsTotal(this ProfileStats profileStats, List<string> forSources)
        {
            throw new NotImplementedException("This method is not implemented. It exists solely for query purposes.");
        }

        public static int MirrorsTotal(this ProfileStats profileStats, List<string> forSources)
        {
            throw new NotImplementedException("This method is not implemented. It exists solely for query purposes.");
        }

        public static int PublicationsTotal(this ProfileStats profileStats, List<string> forSources)
        {
            throw new NotImplementedException("This method is not implemented. It exists solely for query purposes.");
        }

        public static int CommentsTotal(this PublicationStats publicationStats, List<string> forSources)
        {
            throw new NotImplementedException("This method is not implemented. It exists solely for query purposes.");
        }
    }
}