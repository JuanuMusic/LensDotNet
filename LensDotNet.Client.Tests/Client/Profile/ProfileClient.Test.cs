using LensDotNet.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LensDotNet.Tests.Client.Profile
{
    public class ProfileClientTests
    {
        [Test]
        public async Task TestFetchShouldRunSuccessfullyNotAuthenticated()
        {
            var client = new ProfileClient(TestConfigs.DEV_CONFIG);
            Assert.DoesNotThrowAsync(async () => await client.Fetch(new SingleProfileQueryRequest { ProfileId = TestConfigs.EXISTING_PROFILE_ID }));
        }
    }
}
