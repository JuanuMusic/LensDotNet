﻿using LensDotNet.Authentication;
using LensDotNet.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LensDotNet.Client
{
    public abstract class BaseClient
    {
        internal readonly AuthenticationClient? _authentication;
        internal readonly LensGQLClient _client;

        public BaseClient(LensConfig config, AuthenticationClient? authentication = null)
        {
            _authentication = authentication;
            var httpClient = new HttpClient();
            httpClient.BaseAddress = config.GqlEndpoint;
            _client = new LensGQLClient(httpClient);
        }
    }
}
