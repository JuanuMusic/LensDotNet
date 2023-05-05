using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LensDotNet.Models;
using LensDotNet.Models.Modules;

namespace LensDotNet.Services.Follow
{
	public interface IFollowService
	{

        /// <summary>
        /// Executes a follow on a given profile ID.
        /// Generic parameter allos to pass FollowModule properties.
        /// </summary>
        /// <typeparam name="TFollowModuleParams">The type of the FolloeModule params. Must implement <see cref="IModuleParams"/></typeparam>
        /// <param name="profileId">The id of the profile to follow</param>
        /// <param name="followModuleProps">The properties for the FollowModule (or null)</param>
        /// <param name="signBroadcast">A function to sign the message and broadcast it.</param>
        /// <returns></returns>
        public Task<RelayResult> Follow<TFollowModuleProps>(string profileId, TFollowModuleProps? followModuleProps, Func<string, string> signBroadcast) where TFollowModuleProps : IModuleParams;

        /// <summary>
        /// Executes an Unfollow on a given profile ID
        /// </summary>
        /// <param name="profileId">Id of the profile to unfollow</param>
        /// <returns>The result of the unfollowed profile.</returns>
        public Task<RelayResult> Unfollow(string profileId, Func<string, string> signBroadcast);

        /// <summary>
        /// Returns mutual profiles based on the 2 profiles following.
        /// It will return to you all profiles that the profile you are viewing is followed by the profiles you follow.
        /// </summary>
        /// <param name="viewingProfileId">Id of the profile you want to view</param>
        /// <param name="yourProfileId">Id of your profile</param>
        /// <returns></returns>
        public Task<PaginatedProfileResult> MutualProfileFollows(string viewingProfileId, string yourProfileId);
    }
}

