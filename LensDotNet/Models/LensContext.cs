namespace LensDotNet.Models
{
   
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Linq;
    using System.Net.Http;
    using System.Reflection;
    using System.Text.Json;
    using System.Threading.Tasks;
    using GraphQL;
    using GraphQL.Client.Http;
    using GraphQL.Client.Serializer.Newtonsoft;
    using GraphQL.Query.Builder;

    public partial class LensContext
    {
        GraphQLHttpClient _client;

        public LensContext(string baseUrl = "https://api.lens.dev/")
        {
            _client = new GraphQLHttpClient(baseUrl, new NewtonsoftJsonSerializer());
        }

        public LensContext(GraphQLHttpClient httpClient)
        {
            _client = httpClient;
        }

        public ContextQuery<T> BuildQuery<T>(object[] request, string name) 
        {
            var query = new ContextQuery<T>(this, name);
            var parameters = BuildDictionary(request, name);
            if (parameters != null && ((IDictionary<string, object>)parameters).Count > 0)
                query.AddArguments(parameters);

            return query;
        }

        private Dictionary<string, object> BuildDictionary(object[] parameterValues, string queryName)
        {
            var parameters = GetType().GetMethod(queryName, BindingFlags.Public | BindingFlags.IgnoreCase | BindingFlags.Instance).GetParameters();
            var arguments = parameters.Zip(parameterValues, (info, value) => new { info.Name, Value = value }).ToDictionary(arg => arg.Name, arg => arg.Value);
            return arguments;
        }


        public ContextQuery<AuthChallengeResult> Challenge(ChallengeRequest request)
        {
            var parameterValues = new object[] { request };
            return BuildQuery<AuthChallengeResult>( parameterValues, "challenge");
        }

        public ContextQuery<bool> Verify(VerifyRequest request)
        {
            var parameterValues = new object[] { request };
            return  BuildQuery<bool>(parameterValues, "verify");
        }

        public ContextQuery<string> TxIdToTxHash(string txId)
        {
            var parameterValues = new object[] { txId };
            return BuildQuery<string>(parameterValues, "txIdToTxHash");
        }

        public ContextQuery<ExplorePublicationResult<T>> ExplorePublications<T>(ExplorePublicationRequest request) 
        {
            var parameterValues = new object[] { request };
            return BuildQuery<ExplorePublicationResult<T>>(parameterValues, "explorePublications");
        }

        public ContextQuery<ExploreProfileResult> ExploreProfiles(ExploreProfilesRequest request)
        {
            var parameterValues = new object[] { request };
            return BuildQuery<ExploreProfileResult>(parameterValues, "exploreProfiles");
        }

        public ContextQuery<PaginatedFeedResult> Feed(FeedRequest request)
        {
            var parameterValues = new object[] { request };
            return BuildQuery<PaginatedFeedResult>(parameterValues, "feed");
        }

        public ContextQuery<PaginatedTimelineResult> FeedHighlights(FeedHighlightsRequest request)
        {
            var parameterValues = new object[] { request };
            return BuildQuery<PaginatedTimelineResult>(parameterValues, "feedHighlights");
        }

        public ContextQuery<PendingApproveFollowsResult> PendingApprovalFollows(PendingApprovalFollowsRequest request)
        {
            var parameterValues = new object[] { request };
            return BuildQuery<PendingApproveFollowsResult>(parameterValues, "pendingApprovalFollows");
        }

        public ContextQuery<IEnumerable<DoesFollowResponse>> DoesFollow(DoesFollowRequest request)
        {
            var parameterValues = new object[] { request };
            return BuildQuery<IEnumerable<DoesFollowResponse>>(parameterValues, "doesFollow");
        }

        public ContextQuery<PaginatedFollowingResult> Following(FollowingRequest request)
        {
            var parameterValues = new object[] { request };
            return BuildQuery<PaginatedFollowingResult>(parameterValues, "following");
        }

        public ContextQuery<PaginatedFollowersResult> Followers(FollowersRequest request)
        {
            var parameterValues = new object[] { request };
            return BuildQuery<PaginatedFollowersResult>(parameterValues, "followers");
        }

        public ContextQuery<FollowerNftOwnedTokenIds> FollowerNftOwnedTokenIds(FollowerNftOwnedTokenIdsRequest request)
        {
            var parameterValues = new object[] { request };
            return BuildQuery<FollowerNftOwnedTokenIds>(parameterValues, "followerNftOwnedTokenIds");
        }

        public ContextQuery<PaginatedProfileResult> MutualFollowersProfiles(MutualFollowersProfilesQueryRequest request)
        {
            var parameterValues = new object[] { request };
            return BuildQuery<PaginatedProfileResult>(parameterValues, "mutualFollowersProfiles");
        }

        public ContextQuery<string> Ping()
        {
            var parameterValues = new object[] { };
            return BuildQuery<string>(parameterValues, "ping");
        }

        public ContextQuery<TransactionResult> HasTxHashBeenIndexed(HasTxHashBeenIndexedRequest request)
        {
            var parameterValues = new object[] { request };
            return BuildQuery<TransactionResult>(parameterValues, "hasTxHashBeenIndexed");
        }

        public ContextQuery<IEnumerable<Erc20>> EnabledModuleCurrencies()
        {
            var parameterValues = new object[] { };
            return BuildQuery < IEnumerable<Erc20>>(parameterValues, "enabledModuleCurrencies");
        }

        public ContextQuery<IEnumerable<ApprovedAllowanceAmount>> ApprovedModuleAllowanceAmount(ApprovedModuleAllowanceAmountRequest request)
        {
            var parameterValues = new object[] { request };
            return BuildQuery < IEnumerable<ApprovedAllowanceAmount>>(parameterValues, "approvedModuleAllowanceAmount");
        }

        public ContextQuery<GenerateModuleCurrencyApproval> GenerateModuleCurrencyApprovalData(GenerateModuleCurrencyApprovalDataRequest request)
        {
            var parameterValues = new object[] { request };
            return BuildQuery<GenerateModuleCurrencyApproval>(parameterValues, "generateModuleCurrencyApprovalData");
        }

        public ContextQuery<bool> ProfileFollowModuleBeenRedeemed(ProfileFollowModuleBeenRedeemedRequest request)
        {
            var parameterValues = new object[] { request };
            return BuildQuery<bool>(parameterValues, "profileFollowModuleBeenRedeemed");
        }

        public ContextQuery<EnabledModules> EnabledModules()
        {
            var parameterValues = new object[] { };
            return BuildQuery<EnabledModules>(parameterValues, "enabledModules");
        }

        public ContextQuery<EnabledModules> UnknownEnabledModules()
        {
            var parameterValues = new object[] { };
            return BuildQuery<EnabledModules>(parameterValues, "unknownEnabledModules");
        }

        public ContextQuery<NFTsResult> Nfts(NFTsRequest request)
        {
            var parameterValues = new object[] { request };
            return BuildQuery<NFTsResult>(parameterValues, "nfts");
        }

        public ContextQuery<NftOwnershipChallengeResult> NftOwnershipChallenge(NftOwnershipChallengeRequest request)
        {
            var parameterValues = new object[] { request };
            return BuildQuery<NftOwnershipChallengeResult>(parameterValues, "nftOwnershipChallenge");
        }

        public ContextQuery<PaginatedNotificationResult> Notifications(NotificationRequest request)
        {
            var parameterValues = new object[] { request };
            return BuildQuery<PaginatedNotificationResult>(parameterValues, "notifications");
        }

        public ContextQuery<PaginatedProfileResult> Profiles(ProfileQueryRequest request)
        {
            var parameterValues = new object[] { request };
            return BuildQuery<PaginatedProfileResult>(parameterValues, "profiles");
        }

        public ContextQuery<Profile> Profile(SingleProfileQueryRequest request)
        {
            var parameterValues = new object[] { request };
            return BuildQuery<Profile>(parameterValues, "profile");
        }

        public ContextQuery<IEnumerable<Profile>> RecommendedProfiles(RecommendedProfileOptions options)
        {
            var parameterValues = new object[] { options };
            return BuildQuery<IEnumerable<Profile>>(parameterValues, "recommendedProfiles");
        }

        public ContextQuery<Profile> DefaultProfile(DefaultProfileRequest request)
        {
            var parameterValues = new object[] { request };
            return BuildQuery<Profile>(parameterValues, "defaultProfile");
        }

        public ContextQuery<GlobalProtocolStats> GlobalProtocolStats(GlobalProtocolStatsRequest request)
        {
            var parameterValues = new object[] { request };
            return BuildQuery<GlobalProtocolStats>(parameterValues, "globalProtocolStats");
        }

        public ContextQuery<PaginatedPublicationResult> Publications(PublicationsQueryRequest request)
        {
            var parameterValues = new object[] { request };
            return BuildQuery<PaginatedPublicationResult>(parameterValues, "publications");
        }

        public ContextQuery<Publication> Publication(PublicationQueryRequest request)
        {
            var parameterValues = new object[] { request };
            return BuildQuery<Publication>(parameterValues, "publication");
        }

        public ContextQuery<PaginatedWhoCollectedResult> WhoCollectedPublication(WhoCollectedPublicationRequest request)
        {
            var parameterValues = new object[] { request };
            return BuildQuery<PaginatedWhoCollectedResult>(parameterValues, "whoCollectedPublication");
        }

        public ContextQuery<PaginatedProfilePublicationsForSaleResult> ProfilePublicationsForSale(ProfilePublicationsForSaleRequest request)
        {
            var parameterValues = new object[] { request };
            return BuildQuery<PaginatedProfilePublicationsForSaleResult>(parameterValues, "profilePublicationsForSale");
        }

        public ContextQuery<PaginatedAllPublicationsTagsResult> AllPublicationsTags(AllPublicationsTagsRequest request)
        {
            var parameterValues = new object[] { request };
            return BuildQuery<PaginatedAllPublicationsTagsResult>(parameterValues, "allPublicationsTags");
        }

        public ContextQuery<TResult> Search<TResult>(SearchQueryRequest request) where TResult : SearchResult
        {
            var parameterValues = new object[] { request };
            return BuildQuery<TResult>(parameterValues, "search");
        }

        public ContextQuery<UserSigNonces> UserSigNonces()
        {
            var parameterValues = new object[] { };
            return BuildQuery<UserSigNonces>(parameterValues, "userSigNonces");
        }

        public ContextQuery<ClaimableHandles> ClaimableHandles()
        {
            var parameterValues = new object[] { };
            return BuildQuery<ClaimableHandles>(parameterValues, "claimableHandles");
        }

        public ContextQuery<ClaimStatus> ClaimableStatus()
        {
            var parameterValues = new object[] { };
            return BuildQuery<ClaimStatus>(parameterValues, "claimableStatus");
        }

        public ContextQuery<PaginatedPublicationResult> InternalPublicationFilter(InternalPublicationsFilterRequest request)
        {
            var parameterValues = new object[] { request };
            return BuildQuery<PaginatedPublicationResult>(parameterValues, "internalPublicationFilter");
        }

        public ContextQuery<IEnumerable<OnChainIdentity>> ProfileOnChainIdentity(ProfileOnChainIdentityRequest request)
        {
            var parameterValues = new object[] { request };
            return BuildQuery<IEnumerable<OnChainIdentity>>(parameterValues, "profileOnChainIdentity");
        }

        public ContextQuery<IEnumerable<string>> ProfileInterests()
        {
            var parameterValues = new object[] { };
            return BuildQuery<IEnumerable<string>>(parameterValues, "profileInterests");
        }

        public ContextQuery<ProxyActionStatusResultUnion> ProxyActionStatus(string proxyActionId)
        {
            var parameterValues = new object[] { proxyActionId };
            return BuildQuery<ProxyActionStatusResultUnion>(parameterValues, "proxyActionStatus");
        }

        public ContextQuery<PublicationValidateMetadataResult> ValidatePublicationMetadata(ValidatePublicationMetadataRequest request)
        {
            var parameterValues = new object[] { request };
            return BuildQuery<PublicationValidateMetadataResult>(parameterValues, "validatePublicationMetadata");
        }

        public ContextQuery<PublicationMetadataStatus> PublicationMetadataStatus(GetPublicationMetadataStatusRequest request)
        {
            var parameterValues = new object[] { request };
            return BuildQuery<PublicationMetadataStatus>(parameterValues, "publicationMetadataStatus");
        }

        public ContextQuery<PaginatedWhoReactedResult> WhoReactedPublication(WhoReactedPublicationRequest request)
        {
            var parameterValues = new object[] { request };
            return BuildQuery<PaginatedWhoReactedResult>(parameterValues, "whoReactedPublication");
        }

        public ContextQuery<ProfilePublicationRevenueResult> ProfilePublicationRevenue(ProfilePublicationRevenueQueryRequest request)
        {
            var parameterValues = new object[] { request };
            return BuildQuery<ProfilePublicationRevenueResult>(parameterValues, "profilePublicationRevenue");
        }

        public ContextQuery<PublicationRevenue> PublicationRevenue(PublicationRevenueQueryRequest request)
        {
            var parameterValues = new object[] { request };
            return BuildQuery<PublicationRevenue>(parameterValues, "publicationRevenue");
        }

        public ContextQuery<FollowRevenueResult> ProfileFollowRevenue(ProfileFollowRevenueQueryRequest request)
        {
            var parameterValues = new object[] { request };
            return BuildQuery<FollowRevenueResult>(parameterValues, "profileFollowRevenue");
        }

        public ContextQuery<string> Rel(RelRequest request)
        {
            var parameterValues = new object[] { request };
            return BuildQuery<string>(parameterValues, "rel");
        }

        internal async Task<GraphQLResponse<ResultModel<T>>> Execute<T>(Query<T> contextQuery)
        {
            contextQuery.Alias("result");
            string query = "{" + contextQuery.Build() + "}";
            return await _client.SendQueryAsync<ResultModel<T>>(new GraphQLRequest(query));
        }
    }
}