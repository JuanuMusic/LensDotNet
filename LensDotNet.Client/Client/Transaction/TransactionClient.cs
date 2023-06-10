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
    }
}
