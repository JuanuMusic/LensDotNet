
using LensDotNet.Contexts;
using LensDotNet.Core;

namespace LensDotNet.Tests
{
	public class BaseContextTest : BaseTest
	{
        public LensContext Context;

        [SetUp]
        public override void SetUp() {
            base.SetUp();
            Context = new LensContext(Network.MumbaiTestNet);
        }
	}
}

