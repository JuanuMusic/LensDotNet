using System;
using System.Collections.Generic;

namespace LensDotNet.Core.Decorators
{
	public class CollectionResultModel<T>
	{
		public IEnumerable<T> Items { get; set; }
	}
}

