using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Client.Abstractions.Utilities;
using GraphQL.Query.Builder;
using LensDotNet.Core.Decorators;
using LensDotNet.Core.Queries;
using LensDotNet.Decorators;
using static System.Net.Mime.MediaTypeNames;

namespace LensDotNet.Core.Extensions
{
	public static class QueryExtensions
	{
		/// <summary>
		/// Convert a <see cref="Query{T}"/> into an <see cref="ExecutableQuery{T}"/> passing an <see cref="IQueryRunner"/>
		/// </summary>
		/// <typeparam name="T">The underlying type of the query.</typeparam>
		/// <param name="query">Source query</param>
		/// <param name="runner">The runnet to use for executions on this query.</param>
		/// <returns></returns>
		public static ExecutableQuery<T> AsExecutable<T>(this IQuery<T> query, IQueryRunner runner)
			=> new ExecutableQuery<T>(query, runner);

        /// <summary>
        /// Convert a <see cref="Query{T}"/> into an <see cref="ExecutableQuery{T}"/> passing an <see cref="IQueryRunner"/>
        /// </summary>
        /// <typeparam name="T">The underlying type of the query.</typeparam>
        /// <param name="query">Source query</param>
        /// <param name="runner">The runnet to use for executions on this query.</param>
        /// <returns></returns>
        public static async Task<ResultModel<T>> Execute<T>(this IQuery<T> query, IQueryRunner runner)
            => await query.AsExecutable(runner).Execute();

		/// <summary>
		/// Add all the default fields of the underlying type of this query.
		/// </summary>
		/// <typeparam name="T">The query underlying type</typeparam>
		/// <param name="query">The wuery with the default fields added</param>
		/// <returns></returns>
		public static IQuery<T> AddDefaultFields<T>(this IQuery<T> query) 
		{
			
			var defaultFields = ArgumentBuilder.GetDefaultFieldNames(typeof(T));

			foreach(var field in defaultFields)
				query.AddField(field.ToCamelCase());

			return query;
		}

		/// <summary>
		/// Add all the default fields of the underlying type of the IEnumerable of this query.
		/// </summary>
		/// <typeparam name="T">Underlying type of the IEnumerable</typeparam>
		/// <param name="query"></param>
		/// <returns>The query with all the default fields included</returns>
        public static IQuery<IEnumerable<T>> AddDefaultFields<T>(this IQuery<IEnumerable<T>> query)
        {
            var defaultFields = ArgumentBuilder.GetDefaultFieldNames(typeof(T));

			foreach (var field in defaultFields)
				query.AddField(field.ToCamelCase()); ;

            return query;
        }
    }
}

