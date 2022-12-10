using System;
namespace LensDotNet.Tests
{
	public abstract class BaseLensClientTests : BaseTest
	{
		private LensClient _client;
		public LensClient Client { get => _client; }

		[SetUp]
		public override void SetUp()
		{
			base.SetUp();
			_client = new LensClient(Network.MumbaiTestNet);
		}
	}
}

