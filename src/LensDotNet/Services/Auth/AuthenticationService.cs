using System;
using System.Threading.Tasks;
using GraphQL.Query.Builder;
using LensDotNet.Contexts;
using LensDotNet.Core;
using LensDotNet.Decorators;
using LensDotNet.Core.Extensions;
using LensDotNet.Models;
using Nethereum.Signer;
using LensDotNet.Core.Queries;

namespace LensDotNet.Services.Auth
{
	public class AuthenticationService : BaseService, IAuthenticationService
	{
		string _address;
        

        public AuthenticationService(LensContext context, string address) : base(context)
		{
            _address = address;
		}
        public AuthenticationService(LensContext context, string address, Credentials credentials) : base(context, credentials)
        {
            _address = address;
        }

        /// <summary>
        /// Authenticates an address with a signature of the challenge generated with <see cref="GetChallenge(string)"/>.
        /// </summary>
        /// <param name="signature">The signature of the challenge.</param>
        /// <returns>The credentials generated for the address.</returns>
        public virtual async Task<Credentials> Authenticate(string signature)
        {
            var resp = await _context.Authenticate(new SignedAuthChallenge { Address = _address, Signature = signature })
                    .AddField(a => a.AccessToken)
                    .AddField(a => a.RefreshToken)
                    .Execute(_context.QueryRunner);

            var newCreds = new Credentials(resp.Result.AccessToken, resp.Result.RefreshToken);
            _credentials = newCreds; // Avoids nullable reference errors.
            return newCreds;
        }

        /// <summary>
        /// Gets a challenge string to sign for the current address.
        /// </summary>
        /// <returns>The string message to sign</returns>
        public virtual async Task<string> GetChallenge()
        {
            var result = await _context.Challenge(new ChallengeRequest { Address = _address })
                .AddField(c => c.Text)
                .Execute(_context.QueryRunner);
            return result.Result.Text;
        }

        /// <summary>
        /// Executes the full authorization process signing the challenge trough a user provided function.
        /// </summary>
        /// <param name="signChallenge"></param>
        /// <returns></returns>
        public virtual async Task<Credentials> Authorize(Func<string,string> signChallenge)
		{
			var challenge = await GetChallenge();
			var signature = signChallenge(challenge);
            var resolvedAddress = new EthereumMessageSigner().EncodeUTF8AndEcRecover(challenge, signature);
            if (resolvedAddress != _address) throw new Exception($"Invalid signature for address {_address}.");
            return await Authenticate(signature);
		}

        /// <summary>
        /// Executes the full authorization process signing the challenge trough a user provided async function.
        /// </summary>
        /// <param name="asyncSignChallenge">An asynchronous function tht takes the challenge as imput and returns the signature for it.</param>
        /// <returns></returns>
        public virtual async Task<Credentials> Authorize(Func<string, Task<string>> asyncSignChallenge)
        {
            var text = await GetChallenge();
            var signature = await asyncSignChallenge(text);
            return await Authenticate(signature);
        }

        /// <summary>
        /// Verifies that the current credentials are valid (if set). 
        /// </summary>
        /// <returns>True if current credentials are valid, otherwise false.</returns>
        public async Task<bool> Verify()
        {
            if (_credentials == null) throw new NullReferenceException("Can't verify credentials when Credentials are not set. Use Verify(Credentials) or initialize service with Credentials on the constructor.");
            return await Verify(_credentials);
        }

        /// <summary>
        /// Verifies that the current credentials are valid (if set). 
        /// </summary>
        /// <returns>True if current credentials are valid, otherwise false.</returns>
        public async Task<bool> Verify(Credentials credentials)
        {
            if (credentials == null) throw new ArgumentNullException("credentials");
            if (string.IsNullOrEmpty(credentials.AccessToken)) return false;
            var resp = await _context.Verify(new VerifyRequest { AccessToken = credentials.AccessToken }).Execute();
            return resp.Result;
        }
        
        /// <summary>
        /// Refreshes the credentials, and updates it on this instance.
        /// </summary>
        /// <returns>The new credentials.</returns>
        public async Task<Credentials> Refresh()
        {
            if (_credentials == null) throw new NullReferenceException("Can't refreh credentials when Credentials are not set. Use Verify(Credentials) or initialize service with Credentials on the constructor.");
            return await Refresh(_credentials);
        }

        /// <summary>
        /// Fetches the new credentials for given credentials, and updates it on this instance.
        /// </summary>
        /// <returns></returns>
        public async Task<Credentials> Refresh(Credentials credentials)
        {
            if (credentials == null) throw new ArgumentNullException("credentials");
            var refresh = await _context.Refresh(new RefreshRequest { RefreshToken = credentials.RefreshToken })
                .AddField(r => r.RefreshToken)
                .AddField(r => r.AccessToken)
                .AsExecutable(_context.QueryRunner)
                .Execute();

            return _credentials = new Credentials(refresh.Result.AccessToken, refresh.Result.RefreshToken);
        }
    }
}

