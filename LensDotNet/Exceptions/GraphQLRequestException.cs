using System;
using System.Collections.Generic;
using System.Linq;
using GraphQL;

namespace LensDotNet.Exceptions
{
	public class GraphQLRequestException : Exception
	{
		public string[] Errors { get; private set; }
		public string Query { get; }

		public GraphQLRequestException(GraphQLError[] errors, string query)
		{
			if (errors == null) throw new ArgumentException("Invalid errors argument length. Should me greater than 0", "errors");
			Errors = errors.Select(e => e.Message).ToArray();
			Query = query;
		}

		public GraphQLRequestException(GraphQLError error, string query) {
			Errors = new string[]{ error.Message };
			Query = query;
		}

        public override string ToString()
			=> $"Query:{Query}{Environment.NewLine}{string.Join(Environment.NewLine, Errors)}";
    }
}

