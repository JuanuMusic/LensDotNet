using System;
using System.Reflection;
using System.Xml.Linq;
using GraphQL.Client.Abstractions.Utilities;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using GraphQL.Query.Builder;
using LensDotNet.Core;
using LensDotNet.Core.Decorators;
using LensDotNet.Core.Queries;
using LensDotNet.CoreTests.TestModels;
using LensDotNet.Decorators;

namespace LensDotNet.CoreTests
{
	public class ExecutableQueryTests
	{
        string apiUrl = "https://api-mumbai.lens.dev/";
        QueryRunner executor;

        [SetUp]
		public void SetUp()
		{
            executor = new QueryRunner(new GraphQLHttpClient(apiUrl, new NewtonsoftJsonSerializer()));
        }

        [Test]
        public async Task ShouldCorrectlyExecuteASimpleQuery()
        {
            string name = "challenge";
            ChallengeRequest request = new ChallengeRequest { Address = "0x1c2eAdbB291709D3252610C431A6Ee355191E545" };
            var parameterValues = new object[] { request };
            var query = QueryFactory.BuildQuery<AuthChallengeResult>(name)
                .AddField(r => r.Text);

            var parameters = ArgumentBuilder.BuildDictionary(request);
            query.AddArguments(new RequestModel<ChallengeRequest>(request));

            var execQuery = new Decorators.ExecutableQuery<AuthChallengeResult>(query, executor);
            var result = await execQuery.Execute();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Result, Is.Not.Null);
            Assert.That(result.Result.Text, Is.Not.Empty.And.Not.Null);
        }

        [Test]
        public async Task ShouldCorrectlyExecuteAQueryWithListResults()
        {
            string name = "profiles";
            var request = new { Handles = "themanfromearth.test" };


            var query = QueryFactory.BuildQuery<PaginatedProfileResult>(name)
                .AddField(r => r.Items,
                    iq => iq.AddField(i => i.Handle)
                            .AddField(i => i.Id))
                .AddField(r => r.PageInfo,
                    pq => pq.AddField(pi => pi.Next)
                            .AddField(pi => pi.Prev)
                            .AddField(pi => pi.TotalCount));

            var parameters = ArgumentBuilder.BuildDictionary(request);
            query.AddArguments(new RequestModel(request));

            var execQuery = new Decorators.ExecutableQuery<PaginatedProfileResult>(query, executor);
            var result = await execQuery.Execute();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Result, Is.Not.Null);
            Assert.That(result.Result.Items, Is.Not.Null);
            Assert.That(result.Result.Items.Count, Is.GreaterThan(0));
            Assert.That(result.Result.Items.First().Handle, Is.Not.Null.And.Not.Empty);
            Assert.That(result.Result.Items.First().Id, Is.Not.Null.And.Not.Empty);
            Assert.That(result.Result.PageInfo.TotalCount, Is.EqualTo(1));
        }
    }
}

