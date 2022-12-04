using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Query.Builder;
using LensDotNet.Models;

namespace LensDotNet.Tests
{
	public class SearchTests : BaseTest
	{

        [Test]
		public async Task ShouldFindUserByHandle()
			{
			string handle = "juanumusic.lens";
			var searchResponse = Context.Search<SearchResult.ProfileSearchResult>(new SearchQueryRequest { Query = handle, Type = SearchRequestTypes.PROFILE })
					.AddPossibleType<SearchResult.ProfileSearchResult>(
							sub =>
								sub.AddField(s => s.Items, sub1 => sub1.AddField(itm => itm.Handle)));
					//.IncludeUnion<ProfileSearchResult>();
			var searchResult = await searchResponse.Execute();
			Assert.That(searchResult, Is.Not.Null);
            Assert.That(searchResult, Is.AssignableFrom(typeof(SearchResult.ProfileSearchResult)));
            Assert.That(searchResult.Items, Is.Not.Null);
            Assert.That(searchResult.Items.Count, Is.GreaterThan(0));
            Assert.That(searchResult.Items[0], Is.Not.Null);
            Assert.That(searchResult.Items[0].Handle, Is.EqualTo(handle));
        }
	}
}

