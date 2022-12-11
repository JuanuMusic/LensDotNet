using System;
using System.Threading.Tasks;
using LensDotNet.Models;

namespace LensDotNet.Managers.Publications
{
	public interface IPublicationManager
	{
		/// <summary>
		/// Validate a publication metadata V1
		/// </summary>
		/// <param name="input">The V1 metadata to validate</param>
		/// <returns></returns>
		public Task<PublicationValidateMetadataResult> ValidatePublicationMetadata(PublicationMetadataV1Input input);

        /// <summary>
        /// Validate a publication metadata V2
        /// </summary>
        /// <param name="input">The V2 metadata to validate</param>
        /// <returns></returns>
        public Task<PublicationValidateMetadataResult> ValidatePublicationMetadata(PublicationMetadataV2Input input);
    }
}

