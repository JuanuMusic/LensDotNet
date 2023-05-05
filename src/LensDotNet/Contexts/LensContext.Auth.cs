using System;
using LensDotNet.Core.Extensions;
using LensDotNet.Core.Queries;
using LensDotNet.Decorators;
using LensDotNet.Models;

namespace LensDotNet.Contexts
{
	public partial class LensContext
	{
        /// <summary>
        /// Gets an Auth Challenge to sign (SignTypedData) and generate a JWT token.
        /// Once the data is signed, you can get the credentials with <see cref="Authenticate(SignedAuthChallenge)" />.
        /// </summary>
        /// <param name="request">Request with the address to get the challenge for.</param>
        /// <returns></returns>
        public ExecutableQuery<AuthChallengeResult> Challenge(ChallengeRequest request)
        {
            return QueryFactory.BuildQuery<AuthChallengeResult, ChallengeRequest>(request, "challenge")
                .AsExecutable(QueryRunner);
        }

        /// <summary>
        /// Authenticates a signature and returns a JWT token to be ued for requestes where authentication is required.
        /// </summary>
        /// <param name="request">The arguments with the challenge signature.</param>
        /// <returns></returns>
        public ExecutableQuery<AuthenticationResult> Authenticate(SignedAuthChallenge request)
        {
            return QueryFactory.BuildMutationQuery<AuthenticationResult, SignedAuthChallenge>(request, "authenticate")
                .AsExecutable(QueryRunner);
        }

        /// <summary>
        /// Validates that an AccessToken is valis.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ExecutableQuery<bool> Verify(VerifyRequest request)
        {
            return QueryFactory.BuildQuery<bool, VerifyRequest>(request, "verify")
                .AsExecutable(QueryRunner);
        }

        /// <summary>
        /// Refreshes an access token using the <see cref="Credentials."/>
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ExecutableQuery<AuthenticationResult> Refresh(RefreshRequest request)
        {
            return QueryFactory.BuildMutationQuery<AuthenticationResult, RefreshRequest>(request, "refresh")
                .AsExecutable(QueryRunner);
        }
    }
}

