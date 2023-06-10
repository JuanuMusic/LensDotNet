using LensDotNet.Client.Authentication;
using LensDotNet.Client.Fragments.Common;
using LensDotNet.Client.Fragments.Profile;
using LensDotNet.Client.Fragments.Publication;
using LensDotNet.Config;
using System.Threading.Tasks;

namespace LensDotNet.Client
{
    public class ExploreClient : BaseClient
    {
        public ExploreClient(LensConfig config, AuthenticationClient? authentication = null) : base(config, authentication)
        {
        }

        public async Task<PaginatedResult<ProfileFragment>> ExploreProfiles(ProfileSortCriteria profileSortCriteria = ProfileSortCriteria.MostFollowers)
        {
            var request = new
            {
                Input = new ExploreProfilesRequest { SortCriteria = profileSortCriteria }
            };
            var resp = await _client.Query(request,
                static (i, o) => o.ExploreProfiles(i.Input,
                    output => output.AsPaginatedResult<ProfileFragment>()));

            if (resp.Errors != null && resp.Errors.Length > 0)
            {
                throw resp.Errors.ToException("An unhandled exception occurred while fetching explore profiles");
            }

            return resp.Data;

        }

        public async Task<PaginatedResult<PublicationFragment>> ExplorePublications(PublicationSortCriteria publicationSortCriteria = PublicationSortCriteria.TopCommented)
        {
            var request = new
            {
                Input = new ExplorePublicationRequest { SortCriteria = publicationSortCriteria }
            };
            var resp = await _client.Query(request,
                static (i, o) => o.ExplorePublications(i.Input,
                    output => output.AsPaginatedResult<PublicationFragment>()));

            if (resp.Errors != null && resp.Errors.Length > 0)
            {
                throw resp.Errors.ToException("An unhandled exception occurred while fetching explore publications");
            }

            return resp.Data;

        }
    }
}
