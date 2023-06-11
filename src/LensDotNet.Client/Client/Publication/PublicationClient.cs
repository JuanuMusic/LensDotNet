using LensDotNet.Client.Authentication;
using LensDotNet.Client.Fragments.Common;
using LensDotNet.Client.Fragments.Gasless;
using LensDotNet.Client.Fragments.Profile;
using LensDotNet.Client.Fragments.Publication;
using LensDotNet.Config;
using System.Threading.Tasks;

namespace LensDotNet.Client
{
    public class PublicationClient : BaseClient
    {
        public PublicationClient(LensConfig config, AuthenticationClient? authentication = null) : base(config, authentication) { }

        #region AllForSale
        /// <summary>
        /// This query returns you all the publications that are on sale for a given profile.
        /// </summary>
        /// <param name="profileId">The profile for which to fetch the publications for sale</param>
        /// <returns></returns>
        public async Task<PaginatedResult<PublicationForSaleFragment>> AllForSale(ProfileId profileId, LimitScalar? limit = null, Cursor? cursor = null)
            => await AllForSale(new ProfilePublicationsForSaleRequest { ProfileId = profileId, Cursor = cursor, Limit = limit });

        public async Task<PaginatedResult<PublicationForSaleFragment>> AllForSale(ProfilePublicationsForSaleRequest request)
        {
            var resp = await _client.Query(new { Input = request },
               static (i, o) => o.ProfilePublicationsForSale(i.Input,
                   output => output.AsPaginatedResult()));

            return resp.Data;
        }
        #endregion

        #region AllWalletsWhoCollected

        public async Task<PaginatedResult<WalletFragment>> AllWalletsWhoCollected(InternalPublicationId publicationId, LimitScalar? limit = null, Cursor? cursor = null)
           => await AllWalletsWhoCollected(new WhoCollectedPublicationRequest { PublicationId = publicationId, Limit = limit, Cursor = cursor });

        public async Task<PaginatedResult<WalletFragment>> AllWalletsWhoCollected(WhoCollectedPublicationRequest request)
        {
            var resp = await _client.Query(new { Input = request },
                static (i, o) => o.WhoCollectedPublication(i.Input,
                    output => output.AsPaginatedResult()));

            return resp.Data;
        }
        #endregion

        #region Fetch

        public async Task<PublicationFragment> Fetch(InternalPublicationId publicationId)
            => await Fetch(new PublicationQueryRequest { PublicationId = publicationId });

        public async Task<PublicationFragment> Fetch(TxHash txHash)
           => await Fetch(new PublicationQueryRequest { TxHash = txHash });

        public async Task<PublicationFragment> Fetch(PublicationQueryRequest publicationRequest, string? observerId = null)
        {
            var resp = await _client.Query(new { Input = publicationRequest }, static (i, o) => o.Publication(i.Input,
                output => output.AsFragment()));
            return resp.Data;
        }
        #endregion

        public async Task<PaginatedResult<PublicationFragment>> FetchAll(ProfileId profileId, PublicationTypes[]? publicationTypes = null, LimitScalar? limit = null, Cursor? cursor = null)
            => await FetchAll(new PublicationsQueryRequest { 
                ProfileId = profileId, 
                PublicationTypes = publicationTypes, 
                Limit = limit, 
                Cursor = cursor });

        public async Task<PaginatedResult<PublicationFragment>> FetchAll(ProfileId[] profileIds, PublicationTypes[]? publicationTypes = null, LimitScalar? limit = null, Cursor? cursor = null)
            => await FetchAll(new PublicationsQueryRequest { 
                ProfileIds = profileIds,
                PublicationTypes = publicationTypes,
                Limit = limit, 
                Cursor = cursor });

        public async Task<PaginatedResult<PublicationFragment>> FetchAll(PublicationsQueryRequest publicationsQueryRequest)
        {
            var resp = await _client.Query(new { Input = publicationsQueryRequest },
                static (i, o) => o.Publications(i.Input,
                    output => output.AsPaginatedResult<PublicationFragment>()));

            return resp.Data;
        }

        public async Task<PublicationMetadataStatus> MetadataStatus(TxId txId)
        {
            var resp = await _client.Query(new { Input = new GetPublicationMetadataStatusRequest { TxId = txId } },
                static (i, o) => o.PublicationMetadataStatus(i.Input,
                    output => new PublicationMetadataStatus { Status = output.Status, Reason = output.Reason }));

            return resp.Data;
        }

        public async Task Report(ReportPublicationRequest reportRequest)
        {
            var request = new
            {
                Input = reportRequest
            };
            await _client.Mutation(request, static (i, o) => o.ReportPublication(i.Input));
        }

        public async Task<PublicationValidateMetadataResult> ValidateMetadata(PublicationMetadataV2Input validateRequest)
        {
            var request = new
            {
                Input = new ValidatePublicationMetadataRequest { Metadatav2 = validateRequest }
            };
            var resp = await _client.Query(request, static (i, o) => o.ValidatePublicationMetadata(i.Input,
                o => new PublicationValidateMetadataResult { Reason = o.Reason, Valid = o.Valid }));

            return resp.Data;
        }

        /// <summary>
        /// Create a post using dispatcher. Profile has to have the dispatcher enabled.
        /// ⚠️ Requires authenticated <see cref="PublicationClient"/>.
        /// </summary>
        public async Task<RelayResultFragment> CreatePostViaDispatcher(CreatePublicPostRequest request)
        {
            var req = new
            {
                Input = request
            };

            if (_authentication == null || !await _authentication.IsAuthenticated())
                throw new System.Exception("Client not authenticated.");

            var resp = await _client.Mutation(req, static (i, o) => o.CreatePostViaDispatcher(i.Input, output => output.AsFragment()));
            if (resp.Errors != null && resp.Errors.Length > 0)
                throw resp.Errors.ToException("An unhandled exception occurred while creating post via dispatcher");

            if (resp.Data != null && resp.Data.Error != null)
                throw new System.Exception(resp.Data.Error.Reason.ToString());
            return resp.Data;
        }
    }
}
