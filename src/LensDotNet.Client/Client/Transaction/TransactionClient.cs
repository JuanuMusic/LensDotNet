using LensDotNet.Client.Fragments.Gasless;
using LensDotNet.Client.Fragments.Publication;
using LensDotNet.Config;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LensDotNet.Client
{
    public class TransactionClient : BaseClient
    {
        public TransactionClient(LensConfig config, AuthenticationClient? authentication = null) : base(config, authentication)
        {
        }

        public async Task<RelayResultFragment> Broadcast(BroadcastRequest request)
        {
            var resp = await _client.Mutation(new { Input = request }, static (i, o) => o.Broadcast(i.Input, output => output.AsFragment()));
            resp.AssertErrors();
            if (resp.Data != null)
            {
                if (resp.Data.Error != null)
                    throw new Exception(resp.Data.Error.Reason.ToString());
            }
                return resp.Data;
        }

        public async Task<TransactionResultFragment> HasTxHashBeenIndexed(TxHash txHash)
        {
            var resp = await _client.Query(new { Input = new HasTxHashBeenIndexedRequest { TxHash = txHash } }, static (i, o) => o.HasTxHashBeenIndexed(i.Input, output => output.AsFragment()));
            resp.AssertErrors();
            return resp.Data;
        }

        public async Task<TransactionResultFragment> HasTxHashBeenIndexed(TxId txId)
        {
            var resp = await _client.Query(new { Input = new HasTxHashBeenIndexedRequest { TxId = txId } }, static (i, o) => o.HasTxHashBeenIndexed(i.Input, output => output.AsFragment()));
            resp.AssertErrors();
            return resp.Data;
        }
    }
}
