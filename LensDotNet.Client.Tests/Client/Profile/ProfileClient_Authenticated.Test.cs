using LensDotNet.Client;
using LensDotNet.Client.Authentication;
using LensDotNet.Client.Fragments.Publication;
using LensDotNet.Tests.Utils;
using NBitcoin.OpenAsset;
using Nethereum.Web3.Accounts;

namespace LensDotNet.Tests.Client.Profile
{
    public class ProfileClient_Authenticated
    {
        private readonly static Account _account = new Account(TestConfigs.TEST_PK);
        AuthenticationClient authenticationClient;
        ProfileClient client;
        [SetUp]
        public async Task Setup()
        {
            authenticationClient = await Helpers.GetAuthenticationClient(_account);
            client = new ProfileClient(TestConfigs.DEV_CONFIG, authenticationClient);
        }
        [Test]
        public void  Test_Fetch_Should_Run_Successfully()
            => Assert.DoesNotThrowAsync(async () => await client.Fetch(new SingleProfileQueryRequest { ProfileId = TestConfigs.EXISTING_PROFILE_ID }));

        [Test]
        public async Task Test_Fetch_Should_Fetch_Profile_By_Handle() {
            var resp = await client.Fetch(new SingleProfileQueryRequest { Handle = TestConfigs.PROFILE_HANDLE + ".test" });
            Assert.IsNotNull(resp);
            Assert.That(resp.Handle.Value, Is.EqualTo(TestConfigs.PROFILE_HANDLE + ".test"));
        }

        [Test]
        public void Test_Stats_Should_Run_Successfully() 
            => Assert.DoesNotThrowAsync(async () => await client.Stats(new SingleProfileQueryRequest { ProfileId = TestConfigs.EXISTING_PROFILE_ID }, new Sources[] { new Sources("lenster") }));

        [Test]
        public async Task Test_FetchAll_Should_Run_Succesfully()
        {
            var result = await client.FetchAll(new ProfileQueryRequest { ProfileIds = new ProfileId[] { TestConfigs.EXISTING_PROFILE_ID, TestConfigs.ALT_PROFILE_ID } });
            Assert.That(result.Items.Length == 2);
        }

        [Test]
        public void Test_AllRecommended_Should_Run_Succesfully()
            => Assert.DoesNotThrowAsync(async () => await client.AllRecommended(null));

        [Test]
        public void Test_MutualFollowers_Should_Run_Succesfully()
            => Assert.DoesNotThrowAsync(async () => await client.MutualFollowers(new MutualFollowersProfilesQueryRequest { ViewingProfileId = TestConfigs.EXISTING_PROFILE_ID, YourProfileId = TestConfigs.ALT_PROFILE_ID}));

        [Test]
        public void Tests_DoesFollow_Should_Run_Succesfully()
        => Assert.DoesNotThrowAsync(async () 
            => await client.DoesFollow(
                new DoesFollowRequest { 
                    FollowInfos = new DoesFollow[] { 
                        new DoesFollow { FollowerAddress = "0x088C3152A5Ad1892236b312f18405Df3586Aca87", ProfileId = TestConfigs.EXISTING_PROFILE_ID }, 
                        new DoesFollow { FollowerAddress = "0x088C3152A5Ad1892236b312f18405Df3586Aca87", ProfileId = TestConfigs.ALT_PROFILE_ID } } }));

        [Test]
        public void Tests_AllFollowing_Should_Run_Succesfully()
            => Assert.DoesNotThrowAsync(async () 
                => await client.AllFollowing(new FollowingRequest { Address = "0x088C3152A5Ad1892236b312f18405Df3586Aca87" }));

        [Test]
        public void Tests_AllFollowers_Should_Run_Succesfully()
            => Assert.DoesNotThrowAsync(async () 
                => await client.AllFollowers(new FollowersRequest { ProfileId = TestConfigs.EXISTING_PROFILE_ID }));

        [Test]
        public void Test_FollowerNftOwnedTokenIds_ShouldRunSuccesfully()
            => Assert.DoesNotThrowAsync(async () 
                => await client.FollowerNftOwnedTokenIds(new FollowerNftOwnedTokenIdsRequest { 
                    Address = "0x088C3152A5Ad1892236b312f18405Df3586Aca87", 
                    ProfileId = TestConfigs.EXISTING_PROFILE_ID }));

        [Test]
        public async Task Test_CreateProfile_ShouldRunSucesfully()
        {
            var fetchResp = await client.Fetch(new SingleProfileQueryRequest { Handle = TestConfigs.PROFILE_HANDLE + ".test" });
            if (fetchResp != null && fetchResp.Handle == TestConfigs.PROFILE_HANDLE + ".test")
                return;

            var resp = await client.CreateProfile(new CreateProfileRequest
            {
                Handle = new CreateHandle(TestConfigs.PROFILE_HANDLE)
            });
            
                if(resp.Error != null)
                throw new Exception(resp.Error.Reason.ToString());

            Assert.IsNotNull(resp);
            Assert.IsNotNull(resp.Result);
        }
    }
}
