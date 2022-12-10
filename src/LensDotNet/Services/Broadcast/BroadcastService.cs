using System;
using System.Threading.Tasks;
using LensDotNet.Contexts;
using LensDotNet.Core.Extensions;
using LensDotNet.Models;
using LensDotNet.Services;

namespace LensDotNet.Services.Broadcast
{
	public class BroadcastService : BaseService, IBroadcastService
	{
		public BroadcastService(LensContext context) : base(context)
		{
		}

        /// <summary>
        /// Broascast a Typed Data by its Id and the signature.
        /// </summary>
        /// <param name="typedDataId">ID of the typed data</param>
        /// <param name="signature">The signature</param>
        /// <returns></returns>
        public async Task<RelayResult> Broadcast(string typedDataId, string signature)
        {
            var resp = await _context.Broadcast(new BroadcastRequest { Id = typedDataId, Signature = signature })
                .AddPossibleType<RelayerResult>(relayerQuery => relayerQuery
                        .AddField(r => r.TxHash)
                        .AddField(r => r.TxId))
                    .AddPossibleType<RelayError>(relayerError => relayerError
                        .AddField(e => e.Reason))
                    .AsExecutable(_context.QueryRunner)
                    .Execute();
                    

            return resp.Result;
        }
    }
}

