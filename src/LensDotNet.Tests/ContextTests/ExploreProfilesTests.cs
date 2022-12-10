using System;
using GraphQL.Query.Builder;
using System.Threading.Tasks;
using System.Linq;
using LensDotNet.Models;
using LensDotNet.Core.Extensions;

namespace LensDotNet.Tests.ContextTests
{
	public class ExploreProfilesTests : BaseContextTest
	{
        [Test]
        public async Task ExploreProfiles()
        {
            var result = await Context.ExploreProfiles(new ExploreProfilesRequest { SortCriteria = ProfileSortCriteria.MOST_FOLLOWERS })
                //                                                              {
                .AddField(r => r.Items, //                                          items
                    itm => //                                     {
                        itm.AddDefaultFields() // ...
                        .AddField(p => p.Attributes, //                                 attributes
                            bldr => bldr //                                                 {
                                .AddField((Models.Attribute attr) => attr.Value) //             value
                                .AddField((Models.Attribute attr) => attr.Key)  //              key
                            ))    //                                              }   }   }
                .Execute(Context.QueryRunner);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Result, Is.Not.Null);
            Assert.That(result.Result.Items, Is.Not.Null);
            Assert.That(result.Result.Items.Count, Is.GreaterThan(0));
            Assert.That(result.Result.Items.First().Id, Is.Not.Null.And.Not.Empty);
            Assert.That(result.Result.Items.First().Name, Is.Not.Null.And.Not.Empty);
            Assert.That(result.Result.Items.First().Bio, Is.Not.Null.And.Not.Empty);
            Assert.That(result.Result.Items.First().Attributes, Is.Not.Null);
            Assert.That(result.Result.Items.First().Attributes.Count, Is.GreaterThan(0));
            Assert.That(result.Result.Items.First().Attributes.First().Value, Is.Not.Null.And.Not.Empty);
            Assert.That(result.Result.Items.First().Attributes.First().Key, Is.Not.Null.And.Not.Empty);
        }
    }
}

