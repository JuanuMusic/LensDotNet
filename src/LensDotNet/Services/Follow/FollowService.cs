using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LensDotNet.Services.Auth;
using LensDotNet.Models;
using LensDotNet.Models.Modules;
using LensDotNet.Models.Requests;
using Newtonsoft.Json;
using LensDotNet.Contexts;
using LensDotNet.Core.Extensions;

namespace LensDotNet.Services.Follow
{
    public class FollowService : BaseService, IFollowService
    {
        public FollowService(LensContext context) : base(context)
        {
        }

        public FollowService(LensContext context, Credentials? credentials) : base(context, credentials)
        {
        }

        /// <summary>
        /// Executes a follow on a given profile ID.
        /// Generic parameter allos to pass FollowModule properties.
        /// </summary>
        /// <typeparam name="TFollowModuleParams">The type of the FolloeModule params. Must implement <see cref="IModuleParams"/></typeparam>
        /// <param name="profileId">The id of the profile to follow</param>
        /// <param name="followModuleProps">The properties for the FollowModule (or null)</param>
        /// <param name="signBroadcast">A function to sign the message and broadcast it.</param>
        /// <returns></returns>
        public async Task<RelayResult> Follow<TFollowModuleParams>(string profileId, TFollowModuleParams? followModuleProps, Func<string, string> signBroadcast) where TFollowModuleParams : IModuleParams
        {
            throw new NotImplementedException();
            //var followTypedData = await GetFollowTypedData(profileId.ToHexString(), followModuleProps);
            //var jsonTyped = JsonConvert.SerializeObject(followTypedData.TypedData);
            //return await Broadcast(followTypedData.Id, signBroadcast(jsonTyped));
        }

        public Task Follow(object value)
        {
            throw new NotImplementedException();
        }

        public async Task<PaginatedProfileResult> MutualProfileFollows(string viewingProfileId, string yourProfileId)
        {
            var resp = await _context.MutualFollowersProfiles(new MutualFollowersProfilesQueryRequest { ViewingProfileId = viewingProfileId, YourProfileId = yourProfileId })
                .AddField(q => q.Items,
                    itms => itms
                    .AddField(itm => itm.Handle)
                    .AddField(itm => itm.Id))
                .Execute(_context.QueryRunner);

            return resp.Result;
        }

        /// <summary>
        /// Executes an Unfollow on a given profile ID
        /// </summary>
        /// <param name="profileId">Id of the profile to unfollow</param>
        /// <returns>The result of the unfollowed profile.</returns>
        public async Task<RelayResult> Unfollow(string profileId, Func<string, string> signBroadcast)
        {
            throw new NotImplementedException();
            //var followTypedData = await GetUnfollowTypedData(BitConverter.ToString(profileId));
            //var jsonTyped = JsonConvert.SerializeObject(followTypedData.TypedData);
            //return await Broadcast(followTypedData.Id, signBroadcast(jsonTyped));
        }

        public Task<RelayResult> Unfollow<TFollowModuleProps>(string profileId)
        {
            throw new NotImplementedException();
        }

        #region Private Functions
        /// <summary>
        /// Returns the queried Follow Typed Data for broadcasting
        /// </summary>
        /// <typeparam name="TFollowModuleParams">The Follow Module params type</typeparam>
        /// <param name="profileId">Id of the profile to follow</param>
        /// <param name="followModuleProps">Properties of the follow module.</param>
        /// <returns>A typed data object for signing and broadcasting.</returns>
        private async Task<CreateFollowBroadcastItemResult> GetFollowTypedData<TFollowModuleParams>(string profileId, TFollowModuleParams? followModuleProps) where TFollowModuleParams : IModuleParams
        {
            throw new NotImplementedException();
            //var parameters = new FollowRequest<TFollowModuleParams> { Follow = new List<Follow<TFollowModuleParams>> { new Follow<TFollowModuleParams> { Profile = profileId } } };
            //var request = await Context.CreateFollowTypedData(null, parameters)
            //        .AddField(r => r.Id)
            //        .AddField(r => r.TypedData,
            //            sub => sub.AddField(td => td.Types,
            //                typesQuery => typesQuery.AddField(t => t.FollowWithSig,
            //                    followingQuery => followingQuery
            //                        .AddField(f => f.Name)
            //                        .AddField(f => f.Type)))
            //                .AddField(td => td.Value,
            //                    valueQuery => valueQuery
            //                        .AddField(v => v.Nonce)
            //                        .AddField(v => v.Deadline)
            //                        .AddField(v => v.ProfileIds)
            //                        .AddField(v => v.Datas))
            //                .AddField(td => td.Domain,
            //                sub1 => sub1
            //                    .AddField(d => d.Name)
            //                    .AddField(d => d.ChainId)
            //                    .AddField(d => d.VerifyingContract)
            //                    .AddField(d => d.Version)
            //                    )).Execute();

            //return request;
        }

        /// <summary>
        /// Returns the queried Unfollow Typed Data for broadcasting
        /// </summary>
        /// <param name="profileId">Id of the profile to follow</param>
        /// <returns>A typed data object for signing and broadcasting.</returns>
        private async Task<CreateUnfollowBroadcastItemResult> GetUnfollowTypedData(string profileId)
        {
            throw new NotImplementedException();
            //var parameters = new UnfollowRequest { Profile = profileId };
            //var request = await Context.CreateUnfollowTypedData(null, parameters)
            //        .AddField(r => r.Id)
            //        .AddField(r => r.TypedData,
            //            sub => sub.AddField(td => td.Types,
            //                typesQuery => typesQuery.AddField(t => t.BurnWithSig,
            //                    followingQuery => followingQuery
            //                        .AddField(f => f.Name)
            //                        .AddField(f => f.Type)))
            //                .AddField(td => td.Value,
            //                    valueQuery => valueQuery
            //                        .AddField(v => v.Nonce)
            //                        .AddField(v => v.Deadline)
            //                        .AddField(v => v.TokenId))
            //                .AddField(td => td.Domain,
            //                sub1 => sub1
            //                    .AddField(d => d.Name)
            //                    .AddField(d => d.ChainId)
            //                    .AddField(d => d.VerifyingContract)
            //                    .AddField(d => d.Version)
            //                    )).Execute();

            //return request;
        }
        #endregion Private Functions
    }
}

