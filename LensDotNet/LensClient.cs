using System;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;

namespace LensDotNet
{

    public class LensClient
    {
        GraphQLHttpClient _client;
        public LensClient(string baseURL = "https://api.lens.dev/")
        {
            _client = new GraphQLHttpClient(baseURL, new NewtonsoftJsonSerializer());
        }

        public async Task<GraphQLResponse<object>> RunQuery(string query)
        {
            var graphQLQuery = new GraphQLRequest
            {
                Query = query
            };

            return await _client.SendQueryAsync<object>(graphQLQuery);
         }

        internal async Task<GraphQLResponse<object>> RunQuery(string query, string handle)
        {
            var graphQLQuery = new GraphQLRequest
            {
                Query = query,
                Variables = new
                {
                    handle = handle
                }
            };

            return await _client.SendQueryAsync<object>(graphQLQuery);
        }
    }
}

