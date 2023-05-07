﻿using LensDotNet.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LensDotNet.Tests
{
    internal static class TestConfigs
    {
        public readonly static LensConfig DEV_CONFIG = new LensConfig(LensConfig.DEVELOPMENT_GQL_ENDPOINT);

        public static string EXISTING_PROFILE_ID = "0x0185";
    }
}
