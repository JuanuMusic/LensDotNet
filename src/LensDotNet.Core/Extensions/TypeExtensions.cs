using System;
using System.Collections;
using System.Collections.Generic;

namespace LensDotNet.Core.Extensions
{
	public static class TypeExtensions
	{
		/// <summary>
		/// It checks whether the type is any kinf of collection
		/// </summary>
		/// <returns>True if its a kind of collections</returns>
		public static bool IsAnyKindOfCollection(this Type type)
		{
            return type.IsArray ||
                type.GetInterface(typeof(IEnumerable<>).FullName) != null ||
                typeof(IEnumerable).IsAssignableFrom(type);
		}
	}
}

