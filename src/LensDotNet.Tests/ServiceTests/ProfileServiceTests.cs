using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using LensDotNet.Managers;
using LensDotNet.Models;
using LensDotNet.Services.Auth;
using LensDotNet.Services.Profiles;

namespace LensDotNet.Tests.ServiceTests
{
	public class ProfileServiceTests : BaseContextTest
	{
		IProfileService _profileService;
        Credentials _credentials;
        string address = "0x1c2eAdbB291709D3252610C431A6Ee355191E545";
        string pk = "184e2728ff5f73adeea760dfb34a096072dc6354b31d87e9f76cf9f4d523f146";

        [SetUp]
		public override void SetUp()
		{
			base.SetUp();
            _profileService = new ProfileService(Context);
        }

		[Test]
		public async Task ShouldFetchRecommendedProfiles()
		{
			var profilesQuery = _profileService.GetRecommendedProfiles();
			var profiles = await profilesQuery.Execute();
			Assert.That(profiles, Is.Not.Null);
            Assert.That(profiles.Result, Is.Not.Null);
            Assert.That(profiles.Result.Count(), Is.GreaterThan(0));
            Assert.That(profiles.Result.First().Picture, Is.Not.Null);
        }
	}
}

