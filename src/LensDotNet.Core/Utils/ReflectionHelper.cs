using System;
using System.Linq.Expressions;
using System.Reflection;
using GraphQL.Query.Builder;

namespace LensDotNet.Core.Utils
{
	public static class ReflectionHelper
	{
        public static string GetPropertyName(PropertyInfo property, QueryOptions options)
        {
            bool ignoreFormatter = property.GetCustomAttribute(typeof(IgnoreFormatterAttribute)) != null;
            return options?.Formatter != null && !ignoreFormatter
                ? options?.Formatter.Invoke(property)
                : property.Name;
        }

        public static PropertyInfo GetPropertyInfo<TSource, TProperty>(Expression<Func<TSource, TProperty>> lambda) where TProperty : class
        {
            //RequiredArgument.NotNull(lambda, nameof(lambda));

            if (!(lambda.Body is MemberExpression member))
            {
                throw new ArgumentException($"Expression '{lambda}' body is not member expression.");
            }

            if (!(member.Member is PropertyInfo propertyInfo))
            {
                throw new ArgumentException($"Expression '{lambda}' not refers to a property.");
            }

            if (propertyInfo.ReflectedType is null)
            {
                throw new ArgumentException($"Expression '{lambda}' not refers to a property.");
            }

            Type type = typeof(TSource);
            if (type != propertyInfo.ReflectedType && !propertyInfo.ReflectedType.IsAssignableFrom(type))
            {
                throw new ArgumentException($"Expression '{lambda}' refers to a property that is not from type {type}.");
            }

            return propertyInfo;
        }
    }
}

