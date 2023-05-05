using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Query.Builder;
using LensDotNet.Core.Extensions;
using LensDotNet.Models;

namespace LensDotNet.Tests.ContextTests
{
	public class SearchTests : BaseContextTest
	{

        [Test]
		public async Task ShouldFindUserByHandle()
			{
			string handle = "themanfromearth.test";
			var searchResult = await Context.Search<SearchResult.ProfileSearchResult>(new SearchQueryRequest { Query = handle, Type = SearchRequestTypes.PROFILE })
					.AddPossibleType<SearchResult.ProfileSearchResult>(
							sub =>
								sub.AddField(s => s.Items, sub1 => sub1.AddField(itm => itm.Handle)))
					.Execute(Context.QueryRunner);
			
			Assert.That(searchResult, Is.Not.Null);
            Assert.That(searchResult.Result, Is.Not.Null);
            Assert.That(searchResult.Result, Is.AssignableFrom(typeof(SearchResult.ProfileSearchResult)));
            Assert.That(searchResult.Result.Items, Is.Not.Null);
            Assert.That(searchResult.Result.Items.Count, Is.GreaterThan(0));
            Assert.That(searchResult.Result.Items[0], Is.Not.Null);
            Assert.That(searchResult.Result.Items[0].Handle, Is.EqualTo(handle));
        }
	}
}

