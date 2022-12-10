using System;
using System.Threading.Tasks;
using LensDotNet.Models;

namespace LensDotNet.Managers.Publications
{
	public class BasePublicationManager : IPublicationManager
	{
        public Task<PublicationValidateMetadataResult> ValidatePublicationMetadata(PublicationMetadataV1Input input)
        {
            throw new NotImplementedException();
        }

        public Task<PublicationValidateMetadataResult> ValidatePublicationMetadata(PublicationMetadataV2Input input)
        {
            throw new NotImplementedException();
        }
    }
}

