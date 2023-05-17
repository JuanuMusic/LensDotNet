using LensDotNet.Authentication;
using LensDotNet.Client.Profile;
using LensDotNet.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LensDotNet
{
    public class LensClient
    {
        private readonly AuthenticationClient _authentication;
        private readonly LensConfig _config;

        public LensClient(LensConfig config)
        {
            _authentication = new AuthenticationClient(config);
            _config = config;
        }

        public ProfileClient _profileClient;
        public ProfileClient Profile { get => _profileClient ?? (_profileClient = new ProfileClient(_config, _authentication)); }
    }
}
