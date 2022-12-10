using System;
using System.Threading.Tasks;
using GraphQL.Query.Builder;
using LensDotNet.Core.Decorators;

namespace LensDotNet.Decorators
{
    /// <summary>
    /// This interface acts for a decorator of <see cref="ExecutableQuery<T>"/> enabling a query to be executed.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IExecutableQuery<T> : IQuery<T>
	{
		/// <summary>
		/// Executes the query and returns the deserialized result.
		/// </summary>
		/// <returns></returns>
		public Task<ResultModel<T>> Execute();
	}
}

