using LensDotNet.Config;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace LensDotNet.Client
{
    public class LensClient : BaseClient
    {
        public LensClient(LensConfig config) : base(config, new AuthenticationClient(config))
        {
        }

        public AuthenticationClient Authentication { get => base._authentication; }

        public ExploreClient _exploreClient;
        public ExploreClient Explore { get => _exploreClient ?? (_exploreClient = new ExploreClient(base._config, base._authentication)); }

        public GaslessClient _gaslessClient;
        public GaslessClient Gasless { get => _gaslessClient ?? (_gaslessClient = new GaslessClient(base._config, base._authentication)); }

        private ProfileClient _profileClient;
        public ProfileClient Profile { get => _profileClient ?? (_profileClient = new ProfileClient(base._config, base._authentication)); }

        private PublicationClient _publicationClient;
        public PublicationClient Publication { get => _publicationClient ?? (_publicationClient = new PublicationClient(base._config, base._authentication)); }

        private TransactionClient _transactionClient;
        public TransactionClient Transaction { get => _transactionClient ?? (_transactionClient = new TransactionClient(base._config, base._authentication)); }

    }
}
