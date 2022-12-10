using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LensDotNet.Models;
using LensDotNet.Models.Modules;

namespace LensDotNet.Services.Profiles
{
    public record CreateProfileOptions<TFollowModuleParams> where TFollowModuleParams : IModuleParams
    {
        /// <summary>
        /// The profile picture URI
        /// </summary>
        public Uri? ProfilePictureURI { get; set; }

        /// <summary>
        /// The follow NFT URI is the NFT metadata your followers will mint when they follow you. This can be updated at all times.
        /// If you do not pass in anything it will create a super cool changing NFT which will show the last publication of your profile as the NFT which looks awesome!
        /// This means people do not have to worry about writing this logic but still have the ability to customise it for their followers
        /// </summary>
        public Uri? FollowNFTURI { get; set; }

        /// <summary>
        /// The parameters for the Follow module to use.
        /// Null if no follow module is used.
        /// </summary>
        public TFollowModuleParams? FollowMofuleParams { get; set; }
    }

	public interface IProfileService
	{
        /// <summary>
        /// Creating a profile on MAINNET is only allowed by trusted whitelisted addresses for now. This endpoint can be used on TESTNET to allow you to create profiles easily through your UI without worrying about the gas. This will only be exposed on the TESTNET public API. This is great for when you building some cool stuff against the TESTNET contracts.
        /// </summary>
        /// <param name="handle">The handle to create the profile</param>
        /// <returns></returns>
		public Task CreateProfile(string handle);

        /// <summary>
        /// Creating a profile on MAINNET is only allowed by trusted whitelisted addresses for now. This endpoint can be used on TESTNET to allow you to create profiles easily through your UI without worrying about the gas. This will only be exposed on the TESTNET public API. This is great for when you building some cool stuff against the TESTNET contracts.
        /// </summary>
        /// <typeparam name="TFollowModuleParams">The type for the params to pass to the follow module.</typeparam>
        /// <param name="handle">Handle to create profile for</param>
        /// <param name="followModuleParameters">Follow module parameters</param>
        /// <returns></returns>
        public Task CreateProfile<TFollowModuleParams>(string handle, CreateProfileOptions<TFollowModuleParams> followModuleParameters) where TFollowModuleParams : IModuleParams;

        /// <summary>
        /// The default profile for the wallet. A wallet can own many profiles but can set a default similar to how ens works with its resolvers.
        /// </summary>
        /// <param name="address">The address for which to get the default profile.</param>
        /// <returns></returns>
        public Task<Profile> GetDefaultProfile(string address);

        /// <summary>
        /// Get the profiles corresponding to a list of Profile IDs
        /// </summary>
        /// <param name="profileIds">An array with the profile ids to fetch.</param>
        /// <param name="ownedBy">An array with the ethereum addresses to fetch profiles for.</param>
        /// <param name="ownedBy">An array with the Lens handles to fetch profiles for.</param>
        /// <returns></returns>
        public Task<IEnumerable<Profile>> GetProfilesById(IEnumerable<byte[]> profileIds);

        /// <summary>
        /// Get the profiles corresponding that are owned by a list of etehreum addresses.
        /// </summary>
        /// <param name="ownedBy">An array with the ethereum addresses to fetch profiles for.</param>
        /// <returns></returns>
        public Task<IEnumerable<Profile>> GetProfilesOwnedBy(IEnumerable<string> ownedBy);

        /// <summary>
        /// Get the profiles that correspond to a list of handles.
        /// </summary>
        /// <param name="handles">An array with the Lens handles to fetch profiles for.</param>
        /// <returns></returns>
        public Task<IEnumerable<Profile>> GetProfilesByHandles(IEnumerable<string> handles);

        /// <summary>
        /// Get a single profile by ID
        /// </summary>
        /// <param name="profileId">The id of the profile to fetch</param>
        /// <returns></returns>
        public Task<Profile> GetProfile(byte[] profileId);

        /// <summary>
        /// Get a single profile by handle
        /// </summary>
        /// <param name="gabdle">The handle of the profile to fetch.</param>
        /// <returns></returns>
        public Task<Profile> GetProfile(string handle);

        /// <summary>
        /// Returns the stats of a profile for an app id
        /// </summary>
        /// <param name="profileId"></param>
        /// <returns></returns>
        public Task<ProfileStats> GetProfileStats(byte[] profileId, string appId);

        /// <summary>
        /// The API right now has basic ways to get popular profiles. It does not support a paging list as of yet.
        /// The API will undergo continuous improvement to ensure that it is returning profiles that are more relevant to the user using machine learning.
        /// By using this API you inherit all improvements without needing to change code.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Profile>> GetRecommendedProfiles();

        /// <summary>
        /// The API right now has basic ways to get popular profiles. It does not support a paging list as of yet.
        /// The API will undergo continuous improvement to ensure that it is returning profiles that are more relevant to the user using machine learning.
        /// By using this API you inherit all improvements without needing to change code.
        /// </summary>
        /// <param name="profileId">The id of the profile to set the metadata</param>
        /// <param name="metadataURI">The metadata URI to set to the profile</param>
        /// <returns></returns>
        public Task<RelayResult> SetProfileMetadata(byte[] profileId, Uri metadataURI);

        /// <summary>
        /// Attach an image link to a profile.
        /// </summary>
        /// <param name="profileId">Id of the profile to update the image</param>
        /// <param name="imageUri">Uri of the image to set</param>
        /// <returns></returns>
        public Task<RelayResult> SetProfileImage(byte[] profileId, Uri imageUri);

        /// <summary>
        /// Attach an nft as profile image of a profile.
        /// </summary>
        /// <param name="profileId">Id of the profile to update the image</param>
        /// <param name="nftData">NFTData of to set a the profile image.</param>
        /// <returns></returns>
        public Task<RelayResult> SetProfileImage(byte[] profileId, NFTData nftData);

        /// <summary>
        /// Burns a profile NFT. All the content will remain.
        /// </summary>
        /// <param name="profileId">Id of the profile to burn.</param>
        /// <returns></returns>
        public Task<RelayResult> BurnProfile(byte[] profileId);

        /// <summary>
        /// If the caller owns the profile, it will set it as the default profile of this account.
        /// </summary>
        /// <param name="profileId">Id of the profile to set as default.</param>
        /// <returns></returns>
        public Task<RelayResult> SetDefaultProfile(byte[] profileId);

        /// <summary>
        /// Returns an object with the on-chain identity stored on Lens Protocol.
        /// </summary>
        /// <param name="profileId">Id of the profile to fetch the onchain identity</param>
        /// <returns></returns>
        public Task<OnChainIdentity> OnChainIdentity(byte[] profileId);

        /// <summary>
        /// Add interests to a profile.
        /// </summary>
        /// <param name="profileId">Id of the profile to add interests to</param>
        /// <param name="interests">The interests to add. Profiles can have up to 12 interests.</param>
        /// <returns></returns>
        public Task<RelayResult> AddProfileInterest(byte[] profileId, string[] interests);

        /// <summary>
        /// Remove interests from  a profile.
        /// </summary>
        /// <param name="profileId">Id of the profile to remove interests from</param>
        /// <param name="interests">The interests to remove.</param>
        /// <returns></returns>
        public Task<RelayResult> RemoveProfileInterest(byte[] profileId, string[] interests);
    }
}

