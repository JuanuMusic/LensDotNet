using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LensDotNet.Services.Auth;
using LensDotNet.Contexts;
using LensDotNet.Core;
using LensDotNet.Models;
using LensDotNet.Models.Modules;
using LensDotNet.Core.Extensions;

namespace LensDotNet.Services.Profiles
{
	public class ProfileService : BaseService, IProfileService
	{
        public ProfileService(LensContext context) : base(context)
        {
        }

        public ProfileService(LensContext context, Credentials? credentials) : base(context, credentials)
		{
		}

        public Task<RelayResult> AddProfileInterest(byte[] profileId, string[] interests)
        {
            throw new NotImplementedException();
        }

        public Task<RelayResult> BurnProfile(byte[] profileId)
        {
            throw new NotImplementedException();
        }

        public Task CreateProfile(string handle)
        {
            throw new NotImplementedException();
        }

        public Task CreateProfile<TFollowModuleParams>(string handle, CreateProfileOptions<TFollowModuleParams> followModuleParameters) where TFollowModuleParams : IModuleParams
        {
            throw new NotImplementedException();
        }

        public Task<Profile> GetDefaultProfile(string address)
        {
            throw new NotImplementedException();
        }

        public Task<Profile> GetProfile(byte[] profileId)
        {
            throw new NotImplementedException();
        }

        public Task<Profile> GetProfile(string handle)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Profile>> GetProfilesByHandles(IEnumerable<string> handles)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Profile>> GetProfilesById(IEnumerable<byte[]> profileIds)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Profile>> GetProfilesOwnedBy(IEnumerable<string> ownedBy)
        {
            throw new NotImplementedException();
        }

        public Task<ProfileStats> GetProfileStats(byte[] profileId, string appId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Profile>> GetRecommendedProfiles()
        {
            // TODO: Implement options parameter new RecommendedProfileOptions { Shuffle = true }
            var resp = await _context.RecommendedProfiles(null)
                .AddDefaultFields()
                .Execute(_context.QueryRunner);
            return resp.Result;
        }

        public Task<OnChainIdentity> OnChainIdentity(byte[] profileId)
        {
            throw new NotImplementedException();
        }

        public Task<RelayResult> RemoveProfileInterest(byte[] profileId, string[] interests)
        {
            throw new NotImplementedException();
        }

        public Task<RelayResult> SetDefaultProfile(byte[] profileId)
        {
            throw new NotImplementedException();
        }

        public Task<RelayResult> SetProfileImage(byte[] profileId, Uri imageUri)
        {
            throw new NotImplementedException();
        }

        public Task<RelayResult> SetProfileImage(byte[] profileId, NFTData nftData)
        {
            throw new NotImplementedException();
        }

        public Task<RelayResult> SetProfileMetadata(byte[] profileId, Uri metadataURI)
        {
            throw new NotImplementedException();
        }
    }
}

	