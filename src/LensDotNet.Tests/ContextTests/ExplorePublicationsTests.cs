using System.Linq;
using System.Threading.Tasks;
using GraphQL.Query.Builder;
using LensDotNet.Core.Extensions;
using LensDotNet.Models;

namespace LensDotNet.Tests.ContextTests
{
	public class ExploreTests : BaseContextTest
	{
		[Test]
		public async Task ExplorePosts()
		{
            var result = await Context.ExplorePublications<Post>(
                new ExplorePublicationRequest
                {
                    PublicationTypes = (new PublicationTypes[] { PublicationTypes.POST }).ToList()
                })
                // {
                .AddField(r => r.Items, // items {
                    (IQuery<Post> itm) => itm.AddPossibleType<Post>( // ... on Post {
                            p => p.AddField(p => p.OnChainContentURI)))  // onChainContentURI
                .Execute(Context.QueryRunner);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Result, Is.Not.Null);
            Assert.That(result.Result.Items, Is.Not.Null);
            Assert.That(result.Result.Items.Count, Is.GreaterThan(0));
			Assert.That(result.Result.Items.First().OnChainContentURI, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public async Task ExploreMirrors()
        {
            var resp = await Context.ExplorePublications<Mirror>(
                new ExplorePublicationRequest
                {
                    PublicationTypes = (new PublicationTypes[] { PublicationTypes.MIRROR }).ToList()
                })
                // {
                .AddField(r => r.Items, // items {
                    (IQuery<Mirror> itm) => itm.AddPossibleType<Mirror>( // ... on Mirror {
                            p => p.AddField(p => p.OnChainContentURI))) // onChainContentURI
                .Execute(Context.QueryRunner);// } } }


            Assert.That(resp, Is.Not.Null);
            Assert.That(resp.Result, Is.Not.Null);
            Assert.That(resp.Result.Items, Is.Not.Null);

            if (resp.Result.Items.Count() > 0)
            {
                Assert.That(resp.Result.Items.Count, Is.GreaterThan(0));
                Assert.That(resp.Result.Items.First().OnChainContentURI, Is.Not.Null.And.Not.Empty);
            }
        }

        [Test]
        public async Task ExploreComments()
        {
            var resp = await Context.ExplorePublications<Comment>(
                new ExplorePublicationRequest
                {
                    SortCriteria = PublicationSortCriteria.TOP_COMMENTED,
                    PublicationTypes = (new PublicationTypes[] { PublicationTypes.COMMENT }).ToList()
                })
                // {
                .AddField(r => r.Items, // items {
                    (IQuery<Comment> itm) => itm.AddPossibleType<Comment>( // ... on Comment {
                            p => p.AddField(p => p.OnChainContentURI))) // onChainContentURI
                .Execute(Context.QueryRunner);                                                        // } } }

            Assert.That(resp, Is.Not.Null);
            Assert.That(resp.Result.Items, Is.Not.Null);
            Assert.That(resp.Result.Items.Count, Is.GreaterThan(0));
            Assert.That(resp.Result.Items.First().OnChainContentURI, Is.Not.Null.And.Not.Empty);
        }
    }
}

