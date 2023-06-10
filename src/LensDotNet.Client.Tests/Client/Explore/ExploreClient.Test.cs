using LensDotNet.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LensDotNet.Tests.Client.Explore
{
    public class ExploreClient_Test
    {
        [Test]
        public async Task Test_ExplorePublications_Should_Return_Publications()
        {
            var client = new ExploreClient(TestConfigs.DEV_CONFIG);
            var response = await client.ExplorePublications();
            Assert.NotNull(response);
            Assert.NotNull(response.Items);
            Assert.Greater(response.Items.Length, 0);
        }

        [Test]
        public async Task Test_ExploreProfiles_ShouldFetchProfilesSuccesfully()
        {
            var client = new ExploreClient(TestConfigs.DEV_CONFIG);
            var profiles = await client.ExploreProfiles();
            Assert.IsNotNull(profiles);
            Assert.IsNotNull(profiles.Items);
            Assert.Greater(profiles.Items.Length, 0);
        }
    }
}
