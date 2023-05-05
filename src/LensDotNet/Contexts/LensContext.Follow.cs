using System;
using LensDotNet.Core.Queries;
using LensDotNet.Decorators;
using LensDotNet.Models;
using System.Collections.Generic;
using LensDotNet.Core.Extensions;

namespace LensDotNet.Contexts
{
	public partial class LensContext
	{
        public ExecutableQuery<PendingApproveFollowsResult> PendingApprovalFollows(PendingApprovalFollowsRequest request)
        {
            var parameterValues = new object[] { request };
            return QueryFactory.BuildQuery<PendingApproveFollowsResult>(parameterValues, "pendingApprovalFollows")
                .AsExecutable(QueryRunner);
        }

        public ExecutableQuery<IEnumerable<DoesFollowResponse>> DoesFollow(DoesFollowRequest request)
        {
            return QueryFactory.BuildQuery<IEnumerable<DoesFollowResponse>, DoesFollowRequest>(request, "doesFollow")
                .AsExecutable(QueryRunner);
        }

        public ExecutableQuery<PaginatedFollowingResult> Following(FollowingRequest request)
        {
            return QueryFactory.BuildQuery<PaginatedFollowingResult, FollowingRequest>(request, "following")
                .AsExecutable(QueryRunner);
        }

        public ExecutableQuery<PaginatedFollowersResult> Followers(FollowersRequest request)
        {
            return QueryFactory.BuildQuery<PaginatedFollowersResult, FollowersRequest>(request, "followers")
                .AsExecutable(QueryRunner);
        }

        public ExecutableQuery<FollowerNftOwnedTokenIds> FollowerNftOwnedTokenIds(FollowerNftOwnedTokenIdsRequest request)
        {
            return QueryFactory.BuildQuery<FollowerNftOwnedTokenIds, FollowerNftOwnedTokenIdsRequest>(request, "followerNftOwnedTokenIds")
                .AsExecutable(QueryRunner);
        }

        public ExecutableQuery<PaginatedProfileResult> MutualFollowersProfiles(MutualFollowersProfilesQueryRequest request)
        {
            return QueryFactory.BuildQuery<PaginatedProfileResult, MutualFollowersProfilesQueryRequest>(request, "mutualFollowersProfiles")
                .AsExecutable(QueryRunner);
        }

        public ExecutableQuery<bool> ProfileFollowModuleBeenRedeemed(ProfileFollowModuleBeenRedeemedRequest request)
        {
            var parameterValues = new object[] { request };
            return QueryFactory.BuildQuery<bool>(parameterValues, "profileFollowModuleBeenRedeemed")
                .AsExecutable(QueryRunner);
        }
    }
}

