﻿using LensDotNet.Client.Authentication;
using LensDotNet.Client.Fragments.Gasless;
using LensDotNet.Client.Fragments.Publication;
using LensDotNet.Config;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LensDotNet.Client
{
    public class GaslessClient : BaseClient
    {
        public GaslessClient(LensConfig config, AuthenticationClient authentication = null) : base(config, authentication)
        {
        }
        public async Task<CreateSetDispatcherBroadcastItemResultFragment> CreateSetDispatcherTypedData(SetDispatcherRequest setDispatcherRequest)
        {

            var req = new
            {
                Input = setDispatcherRequest
            };

            if (_authentication == null || !await _authentication.IsAuthenticated())
                throw new Exception("Client not authenticated.");

            var resp = await _client.Mutation(req, static (i, o) => o.CreateSetDispatcherTypedData(null, i.Input, output => output.AsFragment()));
            if (resp.Errors != null && resp.Errors.Length > 0)
                throw resp.Errors.ToException("An unhandled exception occurred while creating post via dispatcher");

            return resp.Data;
        }
    }
}
