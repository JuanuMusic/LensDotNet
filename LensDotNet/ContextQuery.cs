using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Query.Builder;
using GraphQL.Types;
using LensDotNet.Exceptions;
using LensDotNet.Models;

namespace LensDotNet
{
    public class ContextQuery<T> : Query<T>
    {
        LensContext _context;
        public ContextQuery(LensContext context, string name)
            : base(name, new QueryOptions { Formatter = (p) => p.Name.ToCamelCase() })
            => _context = context;

        public new ContextQuery<T> AddArguments(Dictionary<string, object> arguments)
            => (ContextQuery<T>)base.AddArguments(arguments);

        public new ContextQuery<T> AddArguments<TArguments>(TArguments arguments) where TArguments : class
            => (ContextQuery<T>)base.AddArguments<TArguments>(arguments);

        public new ContextQuery<T> AddField(string field)
            => (ContextQuery<T>)base.AddField(field);

        public new ContextQuery<T> AddField<TProperty>(Expression<Func<T, TProperty>> selector)
            => (ContextQuery<T>)base.AddField(selector);

        public new ContextQuery<T> AddField<TSubSource>(
            string field, Func<IQuery<TSubSource>, IQuery<TSubSource>> build)
        where TSubSource : class
            => (ContextQuery<T>)base.AddField(field, build);

        public new ContextQuery<T> AddField<TSubSource>(
            Expression<Func<T, TSubSource>> selector,
            Func<IQuery<TSubSource>, IQuery<TSubSource>> build)
        where TSubSource : class
            => (ContextQuery<T>)base.AddField(selector, build);

        public new ContextQuery<T> AddField<TSubSource>(
            Expression<Func<T, IEnumerable<TSubSource>>> selector,
            Func<IQuery<TSubSource>, IQuery<TSubSource>> build)
        where TSubSource : class
            => (ContextQuery<T>)base.AddField(selector, build);

        //public object AddField(Func<ExplorePublicationResult<ExplorePostResult>, IEnumerable<ExplorePostResult>> value1, Func<IQuery<Post>, IQuery<Post>> value2)
        //{
        //    throw new NotImplementedException();
        //}

        public new ContextQuery<T> AddPossibleType(string type)
            => (ContextQuery<T>)base.AddPossibleType(type);

        public new ContextQuery<T> AddPossibleType<TSubSource>(string field, Expression<Func<IQuery<TSubSource>, IQuery<TSubSource>>> build)
        where TSubSource : class
            => (ContextQuery<T>)base.AddPossibleType<TSubSource>(field, build);

        public new ContextQuery<T> AddPossibleType<TSubSource>(Expression<Func<IQuery<TSubSource>, IQuery<TSubSource>>> build)
        where TSubSource : class
            => (ContextQuery<T>)base.AddPossibleType<TSubSource>(build);

        public ContextQuery<T> AddPossibleType<TSubSource>()
        {
            Type possibleType = typeof(TSubSource);
            string name = GetTypeName(possibleType);
            this.PossibleTypesList.Add(name);
            return this;
        }

        /// <summary>Adds a possible type as the query result. This uses the `... on Model` clause and requires inner fields to be added to the query.</summary>
        /// <typeparam name="TPossibleType">The opssible type.</typeparam>
        /// <param name="selector">The field selector.</param>
        /// <param name="build">The fields builder for the possible type.</param>
        /// <returns>The query.</returns>
        //public new ContextQuery<T> AddPossibleType<TPossibleType>(
        //    Expression<Func<T, TPossibleType>> selector, Func<IQuery<TPossibleType>, IQuery<TPossibleType>> build)
        //    where TPossibleType : class
        //        => (ContextQuery<T>)base.AddPossibleType(selector, build);

        public async Task<T> Execute()
        {
            var response = await _context.Execute(this);
            if (response == null) throw new NullReferenceException("Query response was null.");
            if (response.Errors != null && response.Errors.Length > 0)
                throw new GraphQLRequestException(response.Errors, this.Build());
            return response.Data.Result;
        }
    }
}

