using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GraphQL.Query.Builder;
using LensDotNet.Core;
using LensDotNet.Core.Decorators;

namespace LensDotNet.Decorators
{
    /// <summary>
    /// This class acts as a decorator of <see cref="IQuery<T>"/> enabling a query to be executed.
    /// </summary>
    /// <typeparam name="T"></typeparam>
	public class ExecutableCollectionQuery<T> : ExecutableQuery<IEnumerable<T>> where T : DynamicObject
    {
        IQuery<T> _internalQuery; // Stores the actual query
        IQueryRunner _queryExecutor; // Takes care of executing queries.
        private string name;
        private IQueryRunner queryRunner;

        private ExecutableCollectionQuery(IQuery<IEnumerable<T>> query, IQueryRunner queryExecutor) : base(query, queryExecutor)
        {
            _internalQuery = query;
            _queryExecutor = queryExecutor;
        }

        public ExecutableCollectionQuery(string name, IQueryRunner queryExecutor) : base(name, queryExecutor)
        {
            _internalQuery = new Query<T>(name);
            this.name = name;
            this.queryRunner = queryExecutor;
        }

        public static ExecutableCollectionQuery<T> From(IQuery<T> query, IQueryRunner queryExecutor)
        {
            if (query is ExecutableCollectionQuery<T>)
                return (ExecutableCollectionQuery<T>)query;
            else
                return new ExecutableCollectionQuery<T>(query, queryExecutor);
        }

        /// <summary>
        /// Executes the query and returns the deserialized result.
        /// </summary>
        /// <returns></returns>
        public override async Task<ResultModel<IEnumerable<T>>> Execute()
            => await ExecuteAsCollection();

        /// <summary>
        /// Executes the query and returns the deserialized result <see cref="ResultModel{IEnumerable{T}}"/>
        /// </summary>
        /// <returns>An <see cref="ResultModel{IEnumerable{T}}"/>.</returns>
        public Task<ResultModel<IEnumerable<T>>> ExecuteAsCollection()
        {
            string query = _internalQuery.Alias("result").Compile();
            switch (_internalQuery.Type)
            {
                case QueryType.Query:
                    return _queryExecutor.ExecuteQuery<ResultModel<IEnumerable<T>>>(query);
                case QueryType.Mutation:
                    return _queryExecutor.ExecuteMutation<ResultModel<IEnumerable<T>>>(query);
                default:
                    throw new NotSupportedException("QueryType not supported.");
            }
        }

        #region ΙQuery implementation (wrapper for Query).

        public List<object> SelectList => _internalQuery.SelectList;

        public List<object> PossibleTypesList => _internalQuery.PossibleTypesList;

        public Dictionary<string, object> Arguments => _internalQuery.Arguments;

        public string Name => _internalQuery.Name;

        public string AliasName => _internalQuery.AliasName;

        public QueryType Type
        {
            get => _internalQuery.Type;
            set => _internalQuery.Type = value;
        }

        public string Build()
            => _internalQuery.Build();

        public string Compile()
            => _internalQuery.Compile();
        #endregion ΙQuery implementation (wrapper for Query).
    }
}

