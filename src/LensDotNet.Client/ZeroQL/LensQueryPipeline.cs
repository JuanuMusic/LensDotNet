using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using ZeroQL;
using ZeroQL.Internal;
using ZeroQL.Json;
using ZeroQL.Pipelines;
using ZeroQL.Stores;

namespace LensDotNet.ZeroQLImpl
{
    public class LensQueryPipeline : IGraphQLQueryPipeline
    {
        public async Task<GraphQLResponse<TQuery>> ExecuteAsync<TQuery>(HttpClient httpClient, string queryKey, object? variables, CancellationToken cancellationToken, Func<GraphQLRequest, HttpContent> contentCreator)
        {
            QueryInfo queryInfo = GraphQLQueryStore<TQuery>.Query[queryKey];
            string query = queryInfo.Query;
            GraphQLRequest arg = new GraphQLRequest
            {
                Query = query,
                Variables = variables
            };
            HttpContent content = contentCreator(arg);
            var response = await httpClient.PostAsync("", content, cancellationToken);
            var jsonString = await response.Content.ReadAsStringAsync();
            GraphQLResponse<TQuery> graphQLResponse = JsonSerializer.Deserialize<GraphQLResponse<TQuery>>(jsonString, ZeroQLJsonOptions.Options);
            if ((object)graphQLResponse != null)
            {
                graphQLResponse.Query = query;
            }

            return graphQLResponse;
        }
    }
}
