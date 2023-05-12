using LensDotNet.Client.Fragments.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LensDotNet.Client.Fragments.Common
{
    public record WalletFragment
    {
        public EthereumAddress Address { get; set; }
        public ProfileFragment DefaultProfile { get; set; }
    }
}
