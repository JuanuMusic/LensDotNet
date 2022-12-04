using System.Text.Json;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;

namespace LensDotNet.Tests;

public class LensClientTests
{
    GraphQLHttpClient _graphClient;
    [SetUp]
    public void Setup()
    {
        _graphClient = new GraphQLHttpClient("https://api.lens.dev/", new NewtonsoftJsonSerializer());
    }

    [Test]
    public async Task CanRunQuery()
    {
        //LensClient client = new LensClient();
        //var result = await client.RunQuery(Queries.ProfileQueries.EXPLORE_PRPOFILES);
        //Assert.That(result.Errors, Is.Null);
        //Assert.That(result.Data, Is.Not.Null);
    }

    [Test]
    public async Task GraphQLHttpClientCanQuery()
    {

        var graphQLQuery = new GraphQLRequest
        {
            Query = @"query Profile($request: SingleProfileQueryRequest!) { result: profile (request: $request) { 
                      id
                      name
                      bio
                      followNftAddress
                      metadata
                      handle
                      ownedBy
                      isDefault
                      isFollowedByMe
                      isFollowing
                     } }",
            OperationName = "Profile",
            Variables = new { request = new { handle = "juanumusic.lens" } }
        };

        var resp = await _graphClient.SendQueryAsync<object>(graphQLQuery);
        Assert.That(resp, Is.Not.Null);
        Assert.That(resp.Errors, Is.Null);
    }

    [Test]
    public async Task GraphQLHttpClientCanSearch()
    {

        var graphQLQuery = new GraphQLRequest
        {
            Query = @"query ($request: SearchQueryRequest!) { result: search (request: $request) { 
              ... on ProfileSearchResult {
                items { 
    	            handle
  	            }
 	            }
	            }
            }",
            Variables = new { request = new { query = "juanumusic.lens" , type = "PROFILE"} }
        };

        var resp = await _graphClient.SendQueryAsync<object>(graphQLQuery);
        Assert.That(resp, Is.Not.Null);
        Assert.That(resp.Errors, Is.Null);
    }
    
}
