using LensDotNet.Authentication;
using LensDotNet.Client.Fragments.Profile;
using LensDotNet.Client.Fragments.Publication;
using LensDotNet.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LensDotNet.Client.Publication
{
    public class PublicationClient : BaseClient
    {
        public PublicationClient(LensConfig config, AuthenticationClient? authentication = null) : base(config, authentication) {}

        public async Task<PostFragment> Fetch(PublicationQueryRequest publicationRequest, string? observerId = null)
        {
            var request = new
            {
                Input = publicationRequest,
                ObserverId = observerId
            };
            var resp = await _client.Query(request, static (i, o) => o.Publication<PostFragment>(i.Input, output => output.AsProfileFragment()));
            return resp.Data;
        }
    }
}
