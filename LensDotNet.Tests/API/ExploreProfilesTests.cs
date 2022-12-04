using System;
using GraphQL.Query.Builder;
using LensDotNet.Models;
using System.Threading.Tasks;
using System.Linq;

namespace LensDotNet.Tests.API
{
	public class ExploreProfilesTests : BaseTest
	{
        [Test]
        public async Task ExploreProfiles()
        {
            var query = Context.ExploreProfiles(new ExploreProfilesRequest { SortCriteria = ProfileSortCriteria.MOST_FOLLOWERS })
                //                                                              {
                .AddField(r => r.Items, //                                          items
                    (IQuery<Profile> itm) => //                                     {
                        itm.AddField(p => p.Id) //                                      id
                        .AddField(p => p.Name) //                                       name
                        .AddField(p => p.Bio) //                                        bio
                        .AddField(p => p.Attributes, //                                 attributes
                        bldr => bldr //                                                 {
                            .AddField((Models.Attribute attr) => attr.Value) //             value
                            .AddField((Models.Attribute attr) => attr.Key)  //              key
                        ));    //                                              }   }   }

            Assert.That(query, Is.Not.Null);
            var result = await query.Execute();
            Assert.That(result.Items, Is.Not.Null);
            Assert.That(result.Items.Count, Is.GreaterThan(0));
            Assert.That(result.Items.First().Id, Is.Not.Null.And.Not.Empty);
            Assert.That(result.Items.First().Name, Is.Not.Null.And.Not.Empty);
            Assert.That(result.Items.First().Bio, Is.Not.Null.And.Not.Empty);
            Assert.That(result.Items.First().Attributes, Is.Not.Null);
            Assert.That(result.Items.First().Attributes.Count, Is.GreaterThan(0));
            Assert.That(result.Items.First().Attributes.First().Value, Is.Not.Null.And.Not.Empty);
            Assert.That(result.Items.First().Attributes.First().Key, Is.Not.Null.And.Not.Empty);
        }
    }
}

