using System;
using System.Collections.Generic;
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
	public class ExecutableQuery<T> : IQuery<T>, IExecutableQuery<T>
	{
        IQuery<T> _internalQuery; // Stores the actual query
        IQueryRunner _queryExecutor; // Takes care of executing queries.
        private string name;
        private IQueryRunner queryRunner;

        public ExecutableQuery(IQuery<T> query, IQueryRunner queryExecutor)
		{
            _internalQuery = query;
            _queryExecutor = queryExecutor;
		}

        public ExecutableQuery(string name,  IQueryRunner queryExecutor)
        {
            _internalQuery = new Query<T>(name);
            this.name = name;
            this.queryRunner = queryExecutor;
        }

        /// <summary>
        /// Executes the query and returns the deserialized result.
        /// </summary>
        /// <returns></returns>
        public Task<ResultModel<T>> Execute()
        {
            string query = _internalQuery.Alias("result").Compile();
            switch (_internalQuery.Type)
            {
                case QueryType.Query:
                    return _queryExecutor.ExecuteQuery<ResultModel<T>>(query);
                case QueryType.Mutation:
                    return _queryExecutor.ExecuteMutation<ResultModel<T>>(query);
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

        public IQuery<T> AddArgument(string key, object value)
            => new ExecutableQuery<T>(_internalQuery.AddArgument(key, value), _queryExecutor);

        public IQuery<T> AddArguments(Dictionary<string, object> arguments)
            => new ExecutableQuery<T>(_internalQuery.AddArguments(arguments), _queryExecutor);

        public IQuery<T> AddArguments<TArguments>(TArguments arguments) where TArguments : class
            => new ExecutableQuery<T>(_internalQuery.AddArguments(arguments), _queryExecutor);

        public IQuery<T> AddField<TProperty>(System.Linq.Expressions.Expression<Func<T, IEnumerable<TProperty>>> selector)
            => new ExecutableQuery<T>(_internalQuery.AddField(selector), _queryExecutor);

        public IQuery<T> AddField<TProperty>(System.Linq.Expressions.Expression<Func<T, TProperty>> selector)
            => new ExecutableQuery<T>(_internalQuery.AddField(selector), _queryExecutor);

        public IQuery<T> AddField(string field)
            => new ExecutableQuery<T>(_internalQuery.AddField(field), _queryExecutor);

        public IQuery<T> AddField<TSubSource>(System.Linq.Expressions.Expression<Func<T, TSubSource>> selector, Func<IQuery<TSubSource>, IQuery<TSubSource>> build) where TSubSource : class
            => new ExecutableQuery<T>(_internalQuery.AddField(selector, build), _queryExecutor);

        public IQuery<T> AddField<TSubSource>(System.Linq.Expressions.Expression<Func<T, IEnumerable<TSubSource>>> selector, Func<IQuery<TSubSource>, IQuery<TSubSource>> build) where TSubSource : class
            => new ExecutableQuery<T>(_internalQuery.AddField(selector, build), _queryExecutor);

        public IQuery<T> AddField<TSubSource>(string field, Func<IQuery<TSubSource>, IQuery<TSubSource>> build) where TSubSource : class
            => new ExecutableQuery<T>(_internalQuery.AddField(field, build), _queryExecutor);

        public IQuery<T> AddPossibleType(string type)
            => new ExecutableQuery<T>(_internalQuery.AddPossibleType(type), _queryExecutor);

        public IQuery<T> AddPossibleType<TSubSource>(System.Linq.Expressions.Expression<Func<IQuery<TSubSource>, IQuery<TSubSource>>> build) where TSubSource : class
            => new ExecutableQuery<T>(_internalQuery.AddPossibleType(build), _queryExecutor);

        public IQuery<T> Alias(string alias)
            => new ExecutableQuery<T>(_internalQuery.Alias(alias), _queryExecutor);

        public string Build()
            => _internalQuery.Build();

        public string Compile()
            => _internalQuery.Compile();
        #endregion ΙQuery implementation (wrapper for Query).
    }
}

