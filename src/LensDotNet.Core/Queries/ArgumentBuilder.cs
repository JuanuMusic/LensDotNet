using System;
using GraphQL.Query.Builder;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GraphQL.Client.Abstractions.Utilities;
using System.Collections;
using LensDotNet.Core.Extensions;

namespace LensDotNet.Core.Queries
{
    /// <summary>
    /// Static class that contins helper methods to prepare arguments for a GraphQL query.
    /// </summary>
	public static class ArgumentBuilder
	{
        /// <summary>
        /// Builds a dictionary with the array of objects passed to be used as arguments on a query.
        /// </summary>
        /// <param name="parameterValues"></param>
        /// <param name="queryName"></param>
        /// <returns></returns>
        //private static Dictionary<string, object> BuildDictionary(object?[] parameterValues, string queryName)
        //{
        //    var parameters = GetType().GetMethod(queryName, BindingFlags.Public | BindingFlags.IgnoreCase | BindingFlags.Instance).GetParameters();
        //    var arguments = parameters.Zip(parameterValues, (info, value) => new { info.Name, Value = value }).ToDictionary(arg => arg.Name, arg => arg.Value);
        //    return arguments;
        //}

        ///Builds a dictionary ready to be passed as arguments to a query.
        public static Dictionary<string, object?> BuildDictionary<T>(T parameterValues, int depth = 1)
        {
            if (parameterValues == null) return new Dictionary<string, object?>();
            PropertyInfo[] parameters = parameterValues.GetType().GetProperties(BindingFlags.Public | BindingFlags.IgnoreCase | BindingFlags.Instance)
                    .Where(p => p.GetIndexParameters().Length == 0).ToArray();

            //var arguments = parameters.Zip(parameterValues, (info, value) => new { info.Name, Value = value }).ToDictionary(arg => arg.Name, arg => arg.Value);
            var arguments = parameters.ToDictionary(k => k.Name.ToCamelCase(), v => GetValue<T>(v, parameterValues, depth));
            
            return arguments.Where(kv => kv.Value != null).ToDictionary(k => k.Key, v => v.Value);
        }

        private static object? GetValue<T>(PropertyInfo info, T instance, int depth)
        {
            if (instance == null) return null;
            var val = info.GetValue(instance);
            if (val == null) return null;

            if (IsBasicType(info) || depth > 2)
                return val;

            // Convert to array if its "some sort" of collection 🫠
            if (info.PropertyType.IsAnyKindOfCollection()) return AsArray(info, val);

            return BuildDictionary(val, depth + 1);
        }

        private static object[] AsArray(PropertyInfo info, object value)
        {
            if (info.PropertyType.IsArray)
                return (object[])value;
            else if (typeof(IEnumerable).IsAssignableFrom(info.PropertyType))
                return ((IEnumerable)value).Cast<object>().ToArray();
            //else if (info.PropertyType.GetInterface(typeof(IEnumerable<>).FullName) != null)
            //    return ((IEnumerable<object>)value).ToArray();
            else
                throw new Exception($"Cannot convert type {info.PropertyType.Name} to array");
        }

        /// <summary>
        /// Checks if a <see cref="PropertyInfo"/> is an enum, or if its nullable, if its underlying type is enum.
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        private static bool IsEnum(PropertyInfo info)
            => info.PropertyType.IsEnum ||
                (Nullable.GetUnderlyingType(info.PropertyType) != null &&
                Nullable.GetUnderlyingType(info.PropertyType).IsEnum);

        private static bool IsBasicType(PropertyInfo info)
            => IsEnum(info) ||
                info.PropertyType == typeof(string) ||
                info.PropertyType.IsPrimitive;


        /// <summary>
        /// Gets an array with the default field names on a type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IEnumerable<string> GetDefaultFieldNames(Type type)
        {
            PropertyInfo[] parameters = type.GetProperties(BindingFlags.Public | BindingFlags.IgnoreCase | BindingFlags.Instance)
                    .Where(p => p.GetIndexParameters().Length == 0 && IsBasicType(p)).ToArray();

            return parameters.Select(pi => pi.Name);
        }
    }
}

