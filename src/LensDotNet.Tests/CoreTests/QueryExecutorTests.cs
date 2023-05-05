using System;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using LensDotNet.Core;

namespace LensDotNet.Tests.CoreTests
{
	public class QueryExecutorTests
	{
		string apiUrl = "https://api-mumbai.lens.dev/";
        QueryRunner runner;

		[SetUp]
		public void SetUp()
		{
			runner = new QueryRunner(new GraphQLHttpClient(apiUrl, new NewtonsoftJsonSerializer()));
		}

    }
}

