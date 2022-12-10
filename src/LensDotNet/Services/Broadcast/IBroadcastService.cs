using System;
using LensDotNet.Models;
using System.Threading.Tasks;

namespace LensDotNet.Services.Broadcast
{
	public interface IBroadcastService : IService
	{
        /// <summary>
        /// Broascast a Typed Data by its Id and the signature.
        /// </summary>
        /// <param name="typedDataId">ID of the typed data</param>
        /// <param name="signature">The signature</param>
        /// <returns></returns>
        public Task<RelayResult> Broadcast(string typedDataId, string signature);
    }
}

