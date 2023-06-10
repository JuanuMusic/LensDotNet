using LensDotNet.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LensDotNet.Tests.Client
{
    public class LensClient_Test
    {
        LensClient client;
        [SetUp] public void SetUp() {
            client = new LensClient(TestConfigs.DEV_CONFIG);
        }

        [Test]
        public void Test_AllClients_Are_Accessible()
        {
            Assert.That(client.Authentication, Is.Not.Null);
            Assert.That(client.Explore, Is.Not.Null);
            Assert.That(client.Gasless, Is.Not.Null);
            Assert.That(client.Profile, Is.Not.Null);
            Assert.That(client.Publication, Is.Not.Null);
        }
    }
}
