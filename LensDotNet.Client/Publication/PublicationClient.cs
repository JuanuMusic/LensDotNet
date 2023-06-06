﻿using LensDotNet.Authentication;
using LensDotNet.Client.Fragments.Common;
using LensDotNet.Client.Fragments.Profile;
using LensDotNet.Client.Fragments.Publication;
using LensDotNet.Config;
using System.Threading.Tasks;

namespace LensDotNet.Client
{
    public class PublicationClient : BaseClient
    {
        public PublicationClient(LensConfig config, AuthenticationClient? authentication = null) : base(config, authentication) {}

        public async Task<PaginatedResult<PublicationForSaleFragment>> AllForSale(ProfilePublicationsForSaleRequest forSaleRequest)
        {
            var request = new
            {
                Input = forSaleRequest
            };
            var resp = await _client.Query(request,
               static (i, o) => o.ProfilePublicationsForSale(i.Input,
                   output => output.AsPaginatedResult()));

            return resp.Data;
        }

        public async Task <PaginatedResult<WalletFragment>> AllWalletsWhoCollected(WhoCollectedPublicationRequest whoCollectedPublicationRequest)
        {
            var request = new
            {
                Input = whoCollectedPublicationRequest
            };
            var resp = await _client.Query(request,
                static (i, o) => o.WhoCollectedPublication<PaginatedResult<WalletFragment>>(i.Input,
                    output => output.AsPaginatedResult()));

            return resp.Data;
        }

        public async Task<PublicationFragment> Fetch(PublicationQueryRequest publicationRequest, string? observerId = null)
        {
            var request = new
            {
                Input = publicationRequest
            };
            var resp = await _client.Query(request, static (i, o) => o.Publication(i.Input,
                output => output.AsFragment()));
            return resp.Data;
        }

        public async Task<PaginatedResult<PublicationFragment>> FetchAll(PublicationsQueryRequest publicationsQueryRequest)
        {
            var request = new
            {
                Input = publicationsQueryRequest
            };
            var resp = await _client.Query(request,
                static (i, o) => o.Publications<PaginatedResult<PublicationFragment>>(i.Input,
                    output => output.AsPaginatedResult<PublicationFragment>()));

            return resp.Data;
        }

        public async Task<PublicationMetadataStatus> MetadataStatus(GetPublicationMetadataStatusRequest getPublicationMetadataStatusRequest)
        {
            var request = new
            {
                Input = getPublicationMetadataStatusRequest
            };
            var resp = await _client.Query(request,
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
    }
}
