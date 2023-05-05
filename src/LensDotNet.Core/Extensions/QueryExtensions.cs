using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml.Linq;
using GraphQL.Client.Abstractions.Utilities;
using GraphQL.Query.Builder;
using LensDotNet.Core.Decorators;
using LensDotNet.Core.Queries;
using LensDotNet.Core.Utils;
//using LensDotNet.Decorators;
using static System.Net.Mime.MediaTypeNames;

namespace LensDotNet.Core.Extensions
{
    public static class QueryExtensions
    {
        ///// <summary>
        ///// Convert a <see cref="Query{T}"/> into an <see cref="ExecutableQuery{T}"/> passing an <see cref="IQueryRunner"/>
        ///// </summary>
        ///// <typeparam name="T">The underlying type of the query.</typeparam>
        ///// <param name="query">Source query</param>
        ///// <param name="runner">The runnet to use for executions on this query.</param>
        ///// <returns></returns>
        //public static ExecutableQuery<T> AsExecutable<T>(this IQuery<T> query, IQueryRunner runner)
        //    => ExecutableQuery<T>.From(query, runner);

        ///// <summary>
        ///// Convert a <see cref="Query{T}"/> into an <see cref="ExecutableQuery{T}"/> passing an <see cref="IQueryRunner"/>
        ///// </summary>
        ///// <typeparam name="T">The underlying type of the query.</typeparam>
        ///// <param name="query">Source query</param>
        ///// <param name="runner">The runnet to use for executions on this query.</param>
        ///// <returns></returns>
        //public static ExecutableCollectionQuery<T> AsExecutable<T>(this IQuery<IEnumerable<T>> query, IQueryRunner runner)
        //    => ExecutableCollectionQuery<T>.From(query, runner);

        ////public static ExecutableCollectionQuery<T> AsExecutable<T>(this IQuery<IEnumerable<T>> query, IQueryRunner runner)
        ////    => ExecutableCollectionQuery<T>.From(query, runner);

        ///// <summary>
        ///// Convert a <see cref="Query{T}"/> into an <see cref="ExecutableQuery{T}"/> passing an <see cref="IQueryRunner"/>
        ///// </summary>
        ///// <typeparam name="T">The underlying type of the query.</typeparam>
        ///// <param name="query">Source query</param>
        ///// <param name="runner">The runnet to use for executions on this query.</param>
        ///// <returns></returns>
        //public static async Task<ResultModel<T>> Execute<T>(this IQuery<T> query, IQueryRunner runner) where T : DynamicObject
        //    => await query.AsExecutable(runner).Execute();

        /// <summary>Adds a field to a collection query.</summary>
        /// <typeparam name="TProperty">The property type.</typeparam>
        /// <param name="selector">The field selector.</param>
        /// <returns>The query.</returns>
        public static IQuery<TSource> AddField<TSource, TProperty>(
            this IQuery<TSource> query,
            Expression<Func<TSource, TProperty>> selector)
            where TProperty : DynamicObject
            where TSource : DynamicObject
        {
            var property = ReflectionHelper.GetPropertyInfo(selector);
            string name = ReflectionHelper.GetPropertyName(property, QueryFactory.DefaultQueryOptions);

            query.SelectList.Add(name);

            return query;
        }

        public static IQuery<TSource> AddField<TSource, TSubSource>(
            this IQuery<TSource> query,
        Expression<Func<TSource, TSubSource>> selector,
        Func<IQuery<TSubSource>, IQuery<TSubSource>> build)
        where TSubSource : DynamicObject
        where TSource : DynamicObject
        {

            PropertyInfo property = ReflectionHelper.GetPropertyInfo(selector);
            string name = ReflectionHelper.GetPropertyName(property, QueryFactory.DefaultQueryOptions);

            return query.AddField(name, build);
        }
        /// <summary>
        /// Add all the default fields of the underlying type of this query.
        /// </summary>
        /// <typeparam name="TSource">The query underlying type</typeparam>
        /// <param name="query">The wuery with the default fields added</param>
        /// <returns></returns>
        public static IQuery<TSource> AddDefaultFields<TSource>(this IQuery<TSource> query) where TSource : DynamicObject
        {

            var defaultFields = ArgumentBuilder.GetDefaultFieldNames(typeof(TSource));

            foreach (var field in defaultFields)
                query.AddField(field.ToCamelCase());

            return query;
        }

    }
}

