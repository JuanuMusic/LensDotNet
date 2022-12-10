using System;
using LensDotNet.Services.Auth;

namespace LensDotNet.Contexts
{
	public interface IAuthCredentials
	{
        /// <summary>
        /// The credentials used on this context.
        /// </summary>
        public Credentials? Credentials { get; }

        /// <summary>
        /// Sets the credentials updating the HttpClient headers
        /// Setting to null makes the requests as anonymous viewers.
        /// </summary>
        /// <param name="newCredentials"></param>
        public void SetCredentials(Credentials? newCredentials);
        
    }
}

