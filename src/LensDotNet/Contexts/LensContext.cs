namespace LensDotNet.Contexts
{

    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Linq;
    using System.Net.Http;
    using System.Reflection;
    using System.Threading.Tasks;
    using GraphQL;
    using GraphQL.Client.Http;
    using GraphQL.Client.Serializer.Newtonsoft;
    using GraphQL.Query.Builder;
    using LensDotNet.Core;
    using LensDotNet.Core.Extensions;
    using LensDotNet.Core.Queries;
    using LensDotNet.Decorators;
    using LensDotNet.Models;
    using LensDotNet.Models.Modules;
    using LensDotNet.Models.Requests;

    public partial class LensContext : BaseClient
    {
        public LensContext(string url) : base(url) { }
        public LensContext(Network network) : base(network.Value) { }


        public ExecutableQuery<string> TxIdToTxHash(string txId)
        {
            return QueryFactory.BuildQuery<string, string>(txId, "txIdToTxHash")
                .AsExecutable(QueryRunner);
        }

        public ExecutableQuery<ExplorePublicationResult<T>> ExplorePublications<T>(ExplorePublicationRequest request)
        {
            return QueryFactory.BuildQuery<ExplorePublicationResult<T>, ExplorePublicationRequest>(request, "explorePublications")
                .AsExecutable(QueryRunner);
        }

        public ExecutableQuery<ExploreProfileResult> ExploreProfiles(ExploreProfilesRequest request)
        {
            return QueryFactory.BuildQuery<ExploreProfileResult, ExploreProfilesRequest>(request, "exploreProfiles")
                .AsExecutable(QueryRunner);
        }

        public ExecutableQuery<PaginatedFeedResult> Feed(FeedRequest request)
        {
            return QueryFactory.BuildQuery<PaginatedFeedResult, FeedRequest>(request, "feed")
                .AsExecutable(QueryRunner);
        }

        public ExecutableQuery<PaginatedTimelineResult> FeedHighlights(FeedHighlightsRequest request)
        {
            return QueryFactory.BuildQuery<PaginatedTimelineResult, FeedHighlightsRequest>(request, "feedHighlights")
                .AsExecutable(QueryRunner);
        }

        public ExecutableQuery<string> Ping()
        {
            return QueryFactory.BuildQuery<string>(null, "ping")
                .AsExecutable(QueryRunner);
        }

        public ExecutableQuery<TransactionResult> HasTxHashBeenIndexed(HasTxHashBeenIndexedRequest request)
        {
            var parameterValues = new object[] { request };
            return QueryFactory.BuildQuery<TransactionResult>(parameterValues, "hasTxHashBeenIndexed")
                .AsExecutable(QueryRunner);
        }

        public ExecutableQuery<IEnumerable<Erc20>> EnabledModuleCurrencies()
        {
            var parameterValues = new object[] { };
            return QueryFactory.BuildQuery<IEnumerable<Erc20>>(parameterValues, "enabledModuleCurrencies")
                .AsExecutable(QueryRunner);
        }

        public ExecutableQuery<IEnumerable<ApprovedAllowanceAmount>> ApprovedModuleAllowanceAmount(ApprovedModuleAllowanceAmountRequest request)
        {
            var parameterValues = new object[] { request };
            return QueryFactory.BuildQuery<IEnumerable<ApprovedAllowanceAmount>>(parameterValues, "approvedModuleAllowanceAmount")
                .AsExecutable(QueryRunner);
        }

        public ExecutableQuery<GenerateModuleCurrencyApproval> GenerateModuleCurrencyApprovalData(GenerateModuleCurrencyApprovalDataRequest request)
        {
            var parameterValues = new object[] { request };
            return QueryFactory.BuildQuery<GenerateModuleCurrencyApproval>(parameterValues, "generateModuleCurrencyApprovalData")
                .AsExecutable(QueryRunner);
        }

        public ExecutableQuery<EnabledModules> EnabledModules()
        {
            var parameterValues = new object[] { };
            return QueryFactory.BuildQuery<EnabledModules>(parameterValues, "enabledModules")
                .AsExecutable(QueryRunner);
        }

        public ExecutableQuery<EnabledModules> UnknownEnabledModules()
        {
            var parameterValues = new object[] { };
            return QueryFactory.BuildQuery<EnabledModules>(parameterValues, "unknownEnabledModules")
                .AsExecutable(QueryRunner);
        }

        public ExecutableQuery<NFTsResult> Nfts(NFTsRequest request)
        {
            return QueryFactory.BuildQuery<NFTsResult, NFTsRequest>(request, "nfts")
                .AsExecutable(QueryRunner);
        }

        public ExecutableQuery<NftOwnershipChallengeResult> NftOwnershipChallenge(NftOwnershipChallengeRequest request)
        {
            return QueryFactory.BuildQuery<NftOwnershipChallengeResult, NftOwnershipChallengeRequest>(request, "nftOwnershipChallenge")
                .AsExecutable(QueryRunner);
        }

        public ExecutableQuery<PaginatedNotificationResult> Notifications(NotificationRequest request)
        {
            return QueryFactory.BuildQuery<PaginatedNotificationResult, NotificationRequest>(request, "notifications")
                .AsExecutable(QueryRunner);
        }

        public ExecutableQuery<PaginatedProfileResult> Profiles(ProfileQueryRequest request)
        {
            return QueryFactory.BuildQuery<PaginatedProfileResult, ProfileQueryRequest>(request, "profiles")
                .AsExecutable(QueryRunner);
        }

        public ExecutableQuery<Profile> Profile(SingleProfileQueryRequest request)
        {
            return QueryFactory.BuildQuery<Profile, SingleProfileQueryRequest>(request, "profile")
                .AsExecutable(QueryRunner);
        }

        public ExecutableQuery<IEnumerable<Profile>> RecommendedProfiles(RecommendedProfileOptions? options)
        {
            return QueryFactory.BuildQuery<IEnumerable<Profile>, RecommendedProfileOptions?>(options, "recommendedProfiles")
                .AsExecutable(QueryRunner);
        }

        public ExecutableQuery<Profile> DefaultProfile(DefaultProfileRequest request)
        {
            var parameterValues = new object[] { request };
            return QueryFactory.BuildQuery<Profile>(parameterValues, "defaultProfile")
                .AsExecutable(QueryRunner);
        }

        public ExecutableQuery<GlobalProtocolStats> GlobalProtocolStats(GlobalProtocolStatsRequest request)
        {
            var parameterValues = new object[] { request };
            return QueryFactory.BuildQuery<GlobalProtocolStats>(parameterValues, "globalProtocolStats")
                .AsExecutable(QueryRunner);
        }

        public ExecutableQuery<PaginatedPublicationResult> Publications(PublicationsQueryRequest request)
        {
            var parameterValues = new object[] { request };
            return QueryFactory.BuildQuery<PaginatedPublicationResult>(parameterValues, "publications")
                .AsExecutable(QueryRunner);
        }

        public ExecutableQuery<Publication> Publication(PublicationQueryRequest request)
        {
            var parameterValues = new object[] { request };
            return QueryFactory.BuildQuery<Publication>(parameterValues, "publication")
                .AsExecutable(QueryRunner);
        }

        public ExecutableQuery<PaginatedWhoCollectedResult> WhoCollectedPublication(WhoCollectedPublicationRequest request)
        {
            var parameterValues = new object[] { request };
            return QueryFactory.BuildQuery<PaginatedWhoCollectedResult>(parameterValues, "whoCollectedPublication")
                .AsExecutable(QueryRunner);
        }

        public ExecutableQuery<PaginatedProfilePublicationsForSaleResult> ProfilePublicationsForSale(ProfilePublicationsForSaleRequest request)
        {
            var parameterValues = new object[] { request };
            return QueryFactory.BuildQuery<PaginatedProfilePublicationsForSaleResult>(parameterValues, "profilePublicationsForSale")
                .AsExecutable(QueryRunner);
        }

        public ExecutableQuery<PaginatedAllPublicationsTagsResult> AllPublicationsTags(AllPublicationsTagsRequest request)
        {
            var parameterValues = new object[] { request };
            return QueryFactory.BuildQuery<PaginatedAllPublicationsTagsResult>(parameterValues, "allPublicationsTags")
                .AsExecutable(QueryRunner);
        }

        public ExecutableQuery<TResult> Search<TResult>(SearchQueryRequest request) where TResult : SearchResult
        {
            return QueryFactory.BuildQuery<TResult, SearchQueryRequest>(request, "search")
                .AsExecutable(QueryRunner);
        }

        public ExecutableQuery<UserSigNonces> UserSigNonces()
        {
            return QueryFactory.BuildQuery<UserSigNonces>(null, "userSigNonces")
                .AsExecutable(QueryRunner);
        }

        public ExecutableQuery<ClaimableHandles> ClaimableHandles()
        {
            var parameterValues = new object[] { };
            return QueryFactory.BuildQuery<ClaimableHandles>(parameterValues, "claimableHandles")
                .AsExecutable(QueryRunner);
        }

        public ExecutableQuery<ClaimStatus> ClaimableStatus()
        {
            var parameterValues = new object[] { };
            return QueryFactory.BuildQuery<ClaimStatus>(parameterValues, "claimableStatus")
                .AsExecutable(QueryRunner);
        }

        public ExecutableQuery<PaginatedPublicationResult> InternalPublicationFilter(InternalPublicationsFilterRequest request)
        {
            var parameterValues = new object[] { request };
            return QueryFactory.BuildQuery<PaginatedPublicationResult>(parameterValues, "internalPublicationFilter")
                .AsExecutable(QueryRunner);
        }

        public ExecutableQuery<IEnumerable<OnChainIdentity>> ProfileOnChainIdentity(ProfileOnChainIdentityRequest request)
        {
            var parameterValues = new object[] { request };
            return QueryFactory.BuildQuery<IEnumerable<OnChainIdentity>>(parameterValues, "profileOnChainIdentity")
                .AsExecutable(QueryRunner);
        }

        public ExecutableQuery<IEnumerable<string>> ProfileInterests()
        {
            var parameterValues = new object[] { };
            return QueryFactory.BuildQuery<IEnumerable<string>>(parameterValues, "profileInterests")
                .AsExecutable(QueryRunner);
        }

        public ExecutableQuery<ProxyActionStatusResultUnion> ProxyActionStatus(string proxyActionId)
        {
            var parameterValues = new object[] { proxyActionId };
            return QueryFactory.BuildQuery<ProxyActionStatusResultUnion>(parameterValues, "proxyActionStatus")
                .AsExecutable(QueryRunner);
        }

        public ExecutableQuery<PublicationValidateMetadataResult> ValidatePublicationMetadata(ValidatePublicationMetadataRequest request)
        {
            var parameterValues = new object[] { request };
            return QueryFactory.BuildQuery<PublicationValidateMetadataResult>(parameterValues, "validatePublicationMetadata")
                .AsExecutable(QueryRunner);
        }

        public ExecutableQuery<PublicationMetadataStatus> PublicationMetadataStatus(GetPublicationMetadataStatusRequest request)
        {
            var parameterValues = new object[] { request };
            return QueryFactory.BuildQuery<PublicationMetadataStatus>(parameterValues, "publicationMetadataStatus")
                .AsExecutable(QueryRunner);
        }

        public ExecutableQuery<PaginatedWhoReactedResult> WhoReactedPublication(WhoReactedPublicationRequest request)
        {
            var parameterValues = new object[] { request };
            return QueryFactory.BuildQuery<PaginatedWhoReactedResult>(parameterValues, "whoReactedPublication")
                .AsExecutable(QueryRunner);
        }

        public ExecutableQuery<ProfilePublicationRevenueResult> ProfilePublicationRevenue(ProfilePublicationRevenueQueryRequest request)
        {
            var parameterValues = new object[] { request };
            return QueryFactory.BuildQuery<ProfilePublicationRevenueResult>(parameterValues, "profilePublicationRevenue")
                .AsExecutable(QueryRunner);
        }

        public ExecutableQuery<PublicationRevenue> PublicationRevenue(PublicationRevenueQueryRequest request)
        {
            var parameterValues = new object[] { request };
            return QueryFactory.BuildQuery<PublicationRevenue>(parameterValues, "publicationRevenue")
                .AsExecutable(QueryRunner);
        }

        public ExecutableQuery<FollowRevenueResult> ProfileFollowRevenue(ProfileFollowRevenueQueryRequest request)
        {
            var parameterValues = new object[] { request };
            return QueryFactory.BuildQuery<FollowRevenueResult>(parameterValues, "profileFollowRevenue")
                .AsExecutable(QueryRunner);
        }

        public ExecutableQuery<string> Rel(RelRequest request)
        {
            var parameterValues = new object[] { request };
            return QueryFactory.BuildQuery<string>(parameterValues, "rel")
                .AsExecutable(QueryRunner);
        }

        public ExecutableQuery<CreateFollowBroadcastItemResult> CreateFollowTypedData<TFollowModuleParams>(FollowRequest<TFollowModuleParams> request) where TFollowModuleParams : IModuleParams
        {
            return QueryFactory.BuildMutationQuery<CreateFollowBroadcastItemResult, FollowRequest<TFollowModuleParams>>(request, "createFollowTypedData")
                .AsExecutable(QueryRunner);
        }

        public ExecutableQuery<CreateFollowBroadcastItemResult> CreateFollowTypedData(FollowRequest request)
        {
            return QueryFactory.BuildMutationQuery<CreateFollowBroadcastItemResult, FollowRequest>(request, "createFollowTypedData")
                .AsExecutable(QueryRunner);
        }

        class TypedataFollowRequest
        {
            public TypedDataOptions? Options { get; set; }
            public FollowRequest Request { get; set; }
        }

        public ExecutableQuery<CreateFollowBroadcastItemResult> CreateFollowTypedData(TypedDataOptions? options, FollowRequest request)
        {

            return QueryFactory.BuildMutationQuery<CreateFollowBroadcastItemResult, TypedataFollowRequest>(new TypedataFollowRequest
            {
                Options = options,
                Request = request
            }, "createFollowTypedData")
                .AsExecutable(QueryRunner);
        }

        public ExecutableQuery<CreateUnfollowBroadcastItemResult> CreateUnfollowTypedData(TypedDataOptions options, UnfollowRequest request)
        {
            var parameterValues = new object[] { options, request };
            return QueryFactory.BuildMutationQuery<CreateUnfollowBroadcastItemResult>(parameterValues, "createUnfollowTypedData")
                .AsExecutable(QueryRunner);
        }

        public ExecutableQuery<CreateSetDispatcherBroadcastItemResult> CreateSetDispatcherTypedData(TypedDataOptions options, SetDispatcherRequest request)
        {
            var parameterValues = new object[] { options, request };
            return QueryFactory.BuildMutationQuery<CreateSetDispatcherBroadcastItemResult>(parameterValues, "createSetDispatcherTypedData")
                .AsExecutable(QueryRunner);
        }

        public ExecutableQuery<RelayResult> Broadcast(BroadcastRequest request)
        {
            var parameterValues = new object[] { request };
            return QueryFactory.BuildMutationQuery<RelayResult>(parameterValues, "broadcast")
                .AsExecutable(QueryRunner);
        }

        public ExecutableQuery<CreatePostBroadcastItemResult> CreatePostTypedData(TypedDataOptions options, CreatePublicPostRequest request)
        {
            var parameterValues = new object[] { options, request };
            return QueryFactory.BuildMutationQuery<CreatePostBroadcastItemResult>(parameterValues, "createPostTypedData")
                .AsExecutable(QueryRunner);
        }

        public ExecutableQuery<RelayResult> CreatePostViaDispatcher(CreatePublicPostRequest request)
        {
            var parameterValues = new object[] { request };
            return QueryFactory.BuildMutationQuery<RelayResult>(parameterValues, "createPostViaDispatcher")
                .AsExecutable(QueryRunner);
        }

    }
}