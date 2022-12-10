using System;
using System.Threading.Tasks;

namespace LensDotNet
{
	public interface ILensClient
	{
        /// <summary>
        /// Authenticates the indicated addres to lens, using a function for signing the challenge.
        /// </summary>
        /// <param name="address"></param>
        /// <param name="signChallenge"></param>
        /// <returns></returns>
        public Task Authenticate(string address, Func<string, string> signChallenge);

        /// <summary>
        /// Authenticates the indicated addres to lens, using an async function for signing the challenge.
        /// </summary>
        /// <param name="address"></param>
        /// <param name="signChallenge"></param>
        /// <returns></returns>
        public Task Authenticate(string address, Func<string, Task<string>> asyncSignChallenge);
    }
}

