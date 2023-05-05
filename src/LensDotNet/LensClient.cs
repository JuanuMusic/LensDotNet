using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LensDotNet.Services.Auth;
using LensDotNet.Services.Follow;
using LensDotNet.Core;
using LensDotNet.Models;
//using Nethereum.ABI.EIP712;

namespace LensDotNet
{
    public class LensClient : ContextualizedObject, ILensClient
    {
        private Credentials? _credentials;

        private FollowService _followService;
        /// <summary>
        /// Gets the instance of the Follow manager used on this context.
        /// </summary>
        public FollowService Follow { get => _followService ?? (_followService = new FollowService(Context)); }

        //private BroadcastManager _broadcastManager;
        ///// <summary>
        ///// Gets the instance of the Broadcas manager use   d by this context.
        ///// </summary>
        //public BroadcastManager Broadcast { get => _broadcastManager ?? (_broadcastManager = new BroadcastManager(Context, _authenticator.Credentials)); }

        /// <summary>
        /// Creates a new instance of the LensClient, passing the network to use. Default is <see cref="Network.MumbaiTestnet"/>.
        /// </summary>
        /// <param name="network">The Network to use</param>
        public LensClient(Network network) : base(network) {}

        #region AUTH STUFF

        /// <summary>
        /// Authenticates the indicated addres to lens, using a function for signing the challenge.
        /// </summary>
        /// <param name="address"></param>
        /// <param name="signChallenge"></param>
        /// <returns></returns>
        public async Task Authenticate(string address, Func<string, string> signChallenge)
        {
            AuthenticationService auth = new AuthenticationService(Context, address);
            Credentials creds = await auth.Authorize(signChallenge);
            SetCredentials(creds);
        }

        /// <summary>
        /// Authenticates the indicated addres to lens, using an async function for signing the challenge.
        /// </summary>
        /// <param name="address"></param>
        /// <param name="signChallenge"></param>
        /// <returns></returns>
        public async Task Authenticate(string address, Func<string, Task<string>> asyncSignChallenge)
        {
            AuthenticationService auth = new AuthenticationService(Context, address);
            Credentials creds = await auth.Authorize(asyncSignChallenge);
            SetCredentials(creds);
        }

        /// <summary>
        /// Gets wether the client is authenticated.
        /// </summary>
        public async Task<bool> IsAuthenticated(string address)
        {
            if (_credentials == null)
                return false;

            // Is JWT token is set, validate authenticated.
            if (!Context.QueryRunner.IsJWTSet)
                return false;

            AuthenticationService auth = new AuthenticationService(Context, address, _credentials);
            return await auth.Verify();
        }

        public void SetCredentials(Credentials? newCredentials)
        {
            _credentials = newCredentials;
            if (newCredentials == null)
                Context.QueryRunner.ClearJWT();
            else
                Context.QueryRunner.SetJWTAuthToken(newCredentials.AccessToken);
        }

        #endregion AUTH STUFF


    }
}

