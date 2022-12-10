
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;

namespace LensDotNet.Core
{
    public abstract class BaseClient
    {
        IQueryRunner _queryRunner;
        /// <summary>
        /// The runner instance to use for query executions.
        /// </summary>
        public IQueryRunner QueryRunner => _queryRunner;

        //private Credentials _credentials;
        //public Credentials? Credentials => _credentials;

        public BaseClient(string baseUrl)
        {
            var client = new GraphQLHttpClient(baseUrl, new NewtonsoftJsonSerializer());
            _queryRunner = new QueryRunner(client);
        }

        public BaseClient(GraphQLHttpClient httpClient)
        {
            _queryRunner = new QueryRunner(httpClient);
        }
        //public BaseClient(Network network, Credentials _credentials)
        //{
        //    var client = new GraphQLHttpClient(network.Value, new NewtonsoftJsonSerializer());
        //    _queryRunner = new QueryRunner(client);
        //    SetCredentials(_credentials);
        //}

        //public BaseClient(string url, Credentials _credentials)
        //{
        //    var client = new GraphQLHttpClient(url, new NewtonsoftJsonSerializer());
        //    _queryRunner = new QueryRunner(client);
        //    SetCredentials(_credentials);
        //}


        //internal async Task<GraphQLResponse<ResultModel<T>>> Execute<T>(ExecutableQuery<T> contextQuery)
        //     => await Execute(contextQuery);

        //internal async Task<GraphQLResponse<ResultModel<T>>> Execute<T>(IQuery<T> query)
        //{
        //    query.Alias("result");
        //    string strQuery = query.Compile();
        //    if (query.Type == QueryType.Mutation)
        //    {
        //        var resp = await _client.SendMutationAsync<ResultModel<object>>(new GraphQLRequest(strQuery));
        //        var json = JsonConvert.SerializeObject(resp.Data.Result);
        //        return new GraphQLResponse<ResultModel<T>>
        //        {
        //            Data = new ResultModel<T> { Result = JsonConvert.DeserializeObject<T>(json) },
        //            Errors = resp.Errors,
        //            Extensions = resp.Extensions
        //        };
        //    }
        //    else
        //    {
        //        return await _client.SendQueryAsync<ResultModel<T>>(new GraphQLRequest(strQuery));
        //    }
        //}

        //public void SetCredentials(Credentials? newCredentials)
        //{
        //    throw new NotImplementedException();
        //}
    }
}

