using System;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using GraphQL.Query.Builder;
using LensDotNet.Core;
using LensDotNet.Core.Decorators;
using LensDotNet.CoreTests.TestModels;
using Newtonsoft.Json;

namespace LensDotNet.CoreTests
{
    public class QueryExecutorTests
    {
        string apiUrl = "https://api-mumbai.lens.dev/";
        QueryRunner executor;

        [SetUp]
        public void SetUp()
        {
            executor = new QueryRunner(new GraphQLHttpClient(apiUrl, new NewtonsoftJsonSerializer()));
        }

        string LoadQuery(string path)
        {
            string query;
            using (StreamReader reader = new StreamReader(path))
                query = reader.ReadToEnd();
            return query;
        }

        [Test]
        public async Task ShouldExecuteQueryWIthEnumerableResult()
        {
            string query = LoadQuery("Queries/GetProfilesByHandle.graphql");
            var resp = await executor.ExecuteQuery<ResultModel<ProfilesList>>(query);
            //var resp = await executor.ExecuteQuery<ResultModel<object>>(query);
            //string json = JsonConvert.SerializeObject(resp.Result);
            //Console.WriteLine(json);
            Assert.That(resp, Is.Not.Null);
            Assert.That(resp.Result, Is.Not.Null);
            Assert.That(resp.Result.Items, Is.Not.Null);
            Assert.That(resp.Result.Items.Count(), Is.EqualTo(1));
            Assert.That(resp.Result.Items.FirstOrDefault(p => p.Handle.Contains("themanfromearth")), Is.Not.Null);
        }

    }
}

