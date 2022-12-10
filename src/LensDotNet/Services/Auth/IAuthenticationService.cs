using System;
using System.Threading.Tasks;
using LensDotNet.Services;

namespace LensDotNet.Services.Auth
{
	public interface IAuthenticationService : IService
	{
		public Task<string> GetChallenge();

		public Task<Credentials> Authenticate(string signature);

		public Task<bool> Verify();
	}
}

