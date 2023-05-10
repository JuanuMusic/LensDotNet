//using GraphQL;

//namespace LensDotNet.Core
//{
//    public static class ExceptionsExtensions
//    {
//        /// <summary>
//        /// Converts an array of <see cref="GraphQLError"/> into an <see cref="AggregateException"/>
//        /// </summary>
//        /// <param name="errors">The errors to convert.</param>
//        /// <returns>A single <see cref="AggregateException"/> representing all the errors.</returns>
//        public static AggregateException ToException(this GraphQLError[] errors)
//            => new AggregateException("One or more errors resulted executing the query. Check the details of this exception.", errors.Select(err => new Exception(err.Message)).ToArray());


//    }
//}