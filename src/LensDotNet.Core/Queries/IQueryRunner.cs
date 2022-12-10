using System;
using System.Threading.Tasks;
using GraphQL.Client.Abstractions;

namespace LensDotNet.Core
{
    public interface IQueryRunner
    {
        /// <summary>
        /// Gets wether the JWT has been set.
        /// Does NOT guarantee valid credentials.
        /// </summary>
        public bool IsJWTSet { get; }

        /// <summary>
        /// Sets the JWT token to use for the query calls.
        /// </summary>
        /// <param name="authToken"></param>
        public void SetJWTAuthToken(string authToken);

        /// <summary>
		/// Execute a QraphQL query using this executor's Client.
		/// </summary>
		/// <typeparam name="T">The expected return type</typeparam>
		/// <param name="query">The query to execute</param>
		/// <returns></returns>
        public Task<T> ExecuteQuery<T>(string query);

        /// <summary>
        /// Execute a QraphQL mutation using this executor's Client.
        /// </summary>
        /// <typeparam name="T">The expected return type</typeparam>
        /// <param name="mutation">The mutation to execute</param>
        /// <returns></returns>
        public Task<T> ExecuteMutation<T>(string query);

        /// <summary>
        /// Clears the JWT token. All authenticated calls will fail.
        /// </summary>
        void ClearJWT();
    }
}

