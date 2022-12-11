using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using GraphQL.Query.Builder;
using LensDotNet.Core.Decorators;
using LensDotNet.Decorators;

namespace LensDotNet.Core.Queries
{
    /// <summary>
    /// A Factory for building queries ready to be used with the LensDotNet API
    /// </summary>
	public static class QueryFactory
	{
        /// <summary>
        /// The default Query options
        /// </summary>
		public static readonly QueryOptions DefaultQueryOptions = new QueryOptions
		{ 
			Formatter = CamelCasePropertyNameFormatter.Formatter,
			TypeFormatter = ProperCaseTypeNameFormatter.Formatter
        };

        /// <summary>
        /// Retusn a new 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
		public static Query<T> BuildQuery<T>(string name)
			=> new Query<T>(name, DefaultQueryOptions) { Type = QueryType.Query };

        /// <summary>
        /// Returns a new <see cref="Query{T}"/> instance with a specified type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Query<T> BuildQuery<T>(string name, QueryType type)
            => new Query<T>(name, DefaultQueryOptions, type);

        /// <summary>
        /// Returns a new <see cref="Query{T}"/> instance with initial arguments.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [Obsolete("Use with Generic TRequest overload")]
        public static Query<T> BuildQuery<T>(object[] request, string name)
        {
            var query = new Query<T>(name, DefaultQueryOptions);
            var parameters = ArgumentBuilder.BuildDictionary(new RequestModel(request)); // We use the "request" alias
            if (parameters != null && ((IDictionary<string, object>)parameters).Count > 0)
                query.AddArguments(parameters);

            return query;
        }

        public static Query<T> BuildQuery<T,TRequest>(TRequest request, string name)
        {
            var query = new Query<T>(name, DefaultQueryOptions);
            var parameters = ArgumentBuilder.BuildDictionary(new RequestModel<TRequest>(request)); // We use the "request" alias
            if (parameters != null && ((IDictionary<string, object>)parameters).Count > 0)
                query.AddArguments(parameters);

            return query;
        }

        /// <summary>
        /// Returns a new instance of a collection query.
        /// Collection queries are used to build queries from an array (instead of an object)
        /// </summary>
        /// <typeparam name="T">The underlying type of the collection</typeparam>
        /// <typeparam name="TRequest"></typeparam>
        /// <param name="request"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Query<IEnumerable<T>> BuildCollectionQuery<T, TRequest>(TRequest request, string name)
        {
            var query = new Query<IEnumerable<T>>(name, DefaultQueryOptions);
            var parameters = ArgumentBuilder.BuildDictionary(new RequestModel<TRequest>(request)); // We use the "request" alias
            if (parameters != null && ((IDictionary<string, object>)parameters).Count > 0)
                query.AddArguments(parameters);

            return query;
        }

        /// <summary>
        /// Returns a new instance of a mutation query, with initial arguments.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [Obsolete("Use with Generic TRequest overload")]
        public static Query<T> BuildMutationQuery<T>(object?[] request, string name)
        {
            var query = new Query<T>(name, DefaultQueryOptions);

            var parameters = ArgumentBuilder.BuildDictionary(request);
            if (parameters != null && ((IDictionary<string, object>)parameters).Count > 0)
                query.AddArguments(parameters);

            return query;
        }

        /// <summary>
        /// Returns a new instance of a mutation query, with initial arguments.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Query<T> BuildMutationQuery<T, TRequest>(TRequest request, string name)
        {
            var query = new Query<T>(name, DefaultQueryOptions, QueryType.Mutation);

            var parameters = ArgumentBuilder.BuildDictionary(new RequestModel<TRequest>(request));
            if (parameters != null && ((IDictionary<string, object>)parameters).Count > 0)
                query.AddArguments(parameters);

            return query;
        }
    }
}

