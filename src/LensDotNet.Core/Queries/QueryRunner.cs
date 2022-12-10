using System;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;

namespace LensDotNet.Core
{
    public class QueryRunner : IQueryRunner
    {
        GraphQLHttpClient _client;

        public bool IsJWTSet => _client.HttpClient.DefaultRequestHeaders.Contains("x-auth-token");

        /// <summary>
        /// Creates a new instance of QueryExecutor with an instance of <see cref="IGraphQLClient"/> used to execute queries.
        /// </summary>
        public QueryRunner(GraphQLHttpClient client) => _client = client;

        /// <summary>
        /// Execute a QraphQL query using this executor's Client.
        /// </summary>
        /// <typeparam name="T">The expected return type</typeparam>
        /// <param name="query">The query to execute</param>
        /// <returns></returns>
        public async Task<T> ExecuteQuery<T>(string query)
        {
            var response = await _client.SendQueryAsync<T>(new GraphQLRequest(query));
            return ProcessResponse(response);
        }

        /// <summary>
        /// Execute a QraphQL mutation using this executor's Client.
        /// </summary>
        /// <typeparam name="T">The expected return type</typeparam>
        /// <param name="mutation">The mutation to execute</param>
        /// <returns></returns>
        public async Task<T> ExecuteMutation<T>(string mutation)
        {
            var response = await _client.SendMutationAsync<T>(new GraphQLRequest(mutation));
            return ProcessResponse(response);
        }

        /// <summary>
        /// Processes the response internally by checking for errors or returning the actual data.
        /// </summary>
        /// <typeparam name="T">The expected response type</typeparam>
        /// <param name="response">The response to process.</param>
        /// <returns></returns>
        private T ProcessResponse<T>(GraphQLResponse<T> response)
        {
            if (response.Errors != null && response.Errors.Length > 0)
                throw ToException(response.Errors);
            return response.Data;
        }

        /// <summary>
        /// Converts an array of <see cref="GraphQLError"/> into an <see cref="AggregateException"/>
        /// </summary>
        /// <param name="errors">The errors to convert.</param>
        /// <returns>A single <see cref="AggregateException"/> representing all the errors.</returns>
        private AggregateException ToException(GraphQLError[] errors)
            => new AggregateException("One or more errors resulted executing the query. Check the details of this exception.", errors.Select(err => new Exception(err.Message)).ToArray());

        public void SetJWTAuthToken(string authToken)
        {
            ClearJWT();

            if(!string.IsNullOrEmpty(authToken))
                _client.HttpClient.DefaultRequestHeaders.Add("x-auth-token", authToken);
        }

        /// <summary>
        /// Clears the JWT token. All authenticated calls will fail.
        /// </summary>
        public void ClearJWT()
        {
            if (_client.HttpClient.DefaultRequestHeaders.Contains("x-access-token"))
                _client.HttpClient.DefaultRequestHeaders.Remove("x-access-token");
        }
    }
}

