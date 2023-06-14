using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZeroQL;

namespace LensDotNet.Client
{
    public static class Extensions
    {
        /// <summary>
        /// Converts an array of <see cref="GraphQLError"/> into an <see cref="AggregateException"/>
        /// </summary>
        /// <param name="errors">The errors to convert.</param>
        /// <returns>A single <see cref="AggregateException"/> representing all the errors.</returns>
        public static AggregateException ToException(this GraphQueryError[] errors)
            => new AggregateException("One or more errors resulted executing the query. Check the details of this exception.", errors.Select(err => new Exception(err.Message)).ToArray());

        public static AggregateException ToException(this GraphQueryError[] errors, string message)
            => new AggregateException(message, errors.Select(err => new Exception(err.Message)).ToArray());

        public static void AssertErrors<T>(this GraphQLResult<T> resp)
        { 
            if (resp.Errors != null && resp.Errors.Length > 0)
                throw resp.Errors.ToException("GraphQL Result Errors occured");
        }
    }
}
