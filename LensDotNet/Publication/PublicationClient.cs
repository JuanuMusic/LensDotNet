using LensDotNet.Authentication;
using LensDotNet.Client.Fragments.Profile;
using LensDotNet.Client.Fragments.Publication;
using LensDotNet.Config;
using Org.BouncyCastle.Asn1.X509.Qualified;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LensDotNet.Client
{
    public class PublicationClient : BaseClient
    {
        public PublicationClient(LensConfig config, AuthenticationClient? authentication = null) : base(config, authentication) {}

        public async Task<PostFragment> Fetch(PublicationQueryRequest publicationRequest, string? observerId = null)
        {
            var request = new
            {
                Input = publicationRequest
            };
            var resp = await _client.Query(request, static (i, o) => o.Publication<PostFragment>(i.Input, 
                output => (output as Post).AsFragment()
            ));
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
    }
}
