using System;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Query.Builder;
using LensDotNet.Models;

namespace LensDotNet.Tests
{
	public class ExploreTests : BaseTest
	{
		[Test]
		public async Task ExplorePosts()
		{
			var query = Context.ExplorePublications<Post>(
				new Models.ExplorePublicationRequest
				{
					PublicationTypes = (new PublicationTypes[] { PublicationTypes.POST }).ToList()
				})
				// {
				.AddField(r => r.Items, // items {
					(IQuery<Post> itm) => itm.AddPossibleType<Post>( // ... on Post {
							p => p.AddField(p => p.OnChainContentURI))); // onChainContentURI
				// } } }
				

			Assert.That(query, Is.Not.Null);
			var result = await query.Execute();
            Assert.That(result.Items, Is.Not.Null);
            Assert.That(result.Items.Count, Is.GreaterThan(0));
			Assert.That(result.Items.First().OnChainContentURI, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public async Task ExploreMirrors()
        {
            var query = Context.ExplorePublications<Mirror>(
                new Models.ExplorePublicationRequest
                {
                    PublicationTypes = (new PublicationTypes[] { PublicationTypes.MIRROR }).ToList()
                })
                // {
                .AddField(r => r.Items, // items {
                    (IQuery<Mirror> itm) => itm.AddPossibleType<Mirror>( // ... on Mirror {
                            p => p.AddField(p => p.OnChainContentURI))); // onChainContentURI
                                                                         // } } }


            Assert.That(query, Is.Not.Null);
            var result = await query.Execute();
            Assert.That(result.Items, Is.Not.Null);
            Assert.That(result.Items.Count, Is.GreaterThan(0));
            Assert.That(result.Items.First().OnChainContentURI, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public async Task ExploreComments()
        {
            var query = Context.ExplorePublications<Comment>(
                new Models.ExplorePublicationRequest
                {
                    PublicationTypes = (new PublicationTypes[] { PublicationTypes.COMMENT }).ToList()
                })
                // {
                .AddField(r => r.Items, // items {
                    (IQuery<Comment> itm) => itm.AddPossibleType<Comment>( // ... on Comment {
                            p => p.AddField(p => p.OnChainContentURI))); // onChainContentURI
                                                                         // } } }


            Assert.That(query, Is.Not.Null);
            var result = await query.Execute();
            Assert.That(result.Items, Is.Not.Null);
            Assert.That(result.Items.Count, Is.GreaterThan(0));
            Assert.That(result.Items.First().OnChainContentURI, Is.Not.Null.And.Not.Empty);
        }
    }
}

