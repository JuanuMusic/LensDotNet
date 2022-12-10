using System;
using System.Threading.Tasks;
using LensDotNet.Models;

namespace LensDotNet.Managers.Publications
{
    public class PostManager : BasePublicationManager, IPostManager
    {
        public Task<RelayResult> CreatePost(byte[] profileId, Uri contentURI, CreatePublicPostRequest request)
        {
            throw new NotImplementedException();
        }
    }
}

