using System;
namespace LensDotNet.Core.Decorators
{
	/// <summary>
	/// Used to encapsulate GraphQL results
	/// </summary>
	public class ResultModel<T>
	{
		public T Result { get; set; }
	}
}

