using System;
using System.Threading.Tasks;
using GraphQL.Query.Builder;
using LensDotNet.Models;

namespace LensDotNet.Managers.Publications
{
	public interface IPostManager : IPublicationManager
	{
		/// <summary>
		/// Create a Post under a profile.
		/// </summary>
		/// <param name="profileId">Id of the profile on which to create the post..</param>
		/// <param name="contentURI">Request data to create the post</param>
		/// <param name="query">A function to manipulate the query</param>
		/// <param name=""></param>
		/// <returns></returns>
		public Task<RelayResult> CreatePost(byte[] profileId, Uri contentURI, CreatePublicPostRequest request);


	}
}

