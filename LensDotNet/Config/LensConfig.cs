using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LensDotNet.Config
{
    public class LensConfig
    {
        public const string PRODUCTION_GQL_ENDPOINT = "https://api.lens.dev";
        public const string DEVELOPMENT_GQL_ENDPOINT = "https://api-mumbai.lens.dev";

        public LensConfig(string gqlEndpoint) => GqlEndpoint = new Uri(gqlEndpoint);
        public LensConfig(Uri gqlEndpoint) => GqlEndpoint = gqlEndpoint;

        public Uri GqlEndpoint { get; set; }
    }
}
