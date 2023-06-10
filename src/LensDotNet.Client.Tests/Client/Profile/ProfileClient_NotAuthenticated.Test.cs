using LensDotNet.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LensDotNet.Tests.Client.Profile
{
    public class ProfileClient_NotAuthenticated
    {
        [Test]
        public async Task Test_Fetch_Should_Run_Successfully()
        {
            var client = new ProfileClient(TestConfigs.DEV_CONFIG);
            Assert.DoesNotThrowAsync(async () => await client.Fetch(new SingleProfileQueryRequest { ProfileId = TestConfigs.EXISTING_PROFILE_ID }));
        }

        [Test]
        public async Task Test_Stats_Should_Run_Successfully()
        {
            var client = new ProfileClient(TestConfigs.DEV_CONFIG);
            Assert.DoesNotThrowAsync(async () => await client.Stats(new SingleProfileQueryRequest { ProfileId = TestConfigs.EXISTING_PROFILE_ID }, new Sources[] { new Sources("lenster") }));
        }

        [Test]
        public async Task Test_FetchAll_Should_Run_Succesfully()
        {
            var client = new ProfileClient(TestConfigs.DEV_CONFIG);
            var result = await client.FetchAll(new ProfileQueryRequest { ProfileIds = new ProfileId[] { TestConfigs.EXISTING_PROFILE_ID, TestConfigs.ALT_PROFILE_ID } });
            Assert.That(result.Items.Length == 2);
        }

        [Test]
        public void Test_AllRecommended_Should_Run_Succesfully()
        {
            var client = new ProfileClient(TestConfigs.DEV_CONFIG);
            Assert.DoesNotThrowAsync(async () => await client.AllRecommended(null)) ;
        }

        [Test]
        public void Test_MutualFollowers_Should_Run_Succesfully()
        {
            var client = new ProfileClient(TestConfigs.DEV_CONFIG);
            Assert.DoesNotThrowAsync(async () => await client.MutualFollowers(new MutualFollowersProfilesQueryRequest { ViewingProfileId = TestConfigs.EXISTING_PROFILE_ID, YourProfileId = TestConfigs.ALT_PROFILE_ID}));
        }

        [Test]
        public void Tests_DoesFollow_Should_Run_Succesfully()
        {
            var client = new ProfileClient(TestConfigs.DEV_CONFIG);
            Assert.DoesNotThrowAsync(async () => await client.DoesFollow(new DoesFollowRequest
            {
                FollowInfos = new DoesFollow[] {
                    new DoesFollow { FollowerAddress = "0x088C3152A5Ad1892236b312f18405Df3586Aca87", ProfileId = TestConfigs.EXISTING_PROFILE_ID },
                    new DoesFollow { FollowerAddress = "0x088C3152A5Ad1892236b312f18405Df3586Aca87", ProfileId = TestConfigs.ALT_PROFILE_ID }
            }}));
        }

        [Test]
        public void Tests_AllFollowing_Should_Run_Succesfully()
        {
            var client = new ProfileClient(TestConfigs.DEV_CONFIG);
            Assert.DoesNotThrowAsync(async () => await client.AllFollowing(new FollowingRequest
            {
                Address = "0x088C3152A5Ad1892236b312f18405Df3586Aca87"
            }));;
        }

        [Test]
        public void Tests_AllFollowers_Should_Run_Succesfully()
        {
            var client = new ProfileClient(TestConfigs.DEV_CONFIG);
            Assert.DoesNotThrowAsync(async () => await client.AllFollowers(new FollowersRequest
            {
                ProfileId = TestConfigs.EXISTING_PROFILE_ID,
            }));
        }

        [Test]
        public void Test_FollowerNftOwnedTokenIds_ShouldRunSuccesfully()
        {
            var client = new ProfileClient(TestConfigs.DEV_CONFIG);
            Assert.DoesNotThrowAsync(async () => await client.FollowerNftOwnedTokenIds(new FollowerNftOwnedTokenIdsRequest
            {
                Address = "0x088C3152A5Ad1892236b312f18405Df3586Aca87",
                ProfileId = TestConfigs.EXISTING_PROFILE_ID
            }));
        }
    }
}
