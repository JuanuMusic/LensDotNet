using LensDotNet.IPFS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LensDotNet.Tests.IPFS
{
    public class IPFS_Test
    {
        IPFSClient client;

        [SetUp]
        public void Setup()
        {
            var httpClient = new HttpClient();
            client = new IPFSClient(httpClient, new Uri("http://192.168.88.221:5001"));
        }

        [Test]
        public async Task Test_Add_Should_Correctly_Return_AddResponse()
        {
            string content = "This is a test for adding data to IPDFS";
            var data = Encoding.UTF8.GetBytes(content);
            var resp = await client.Add(data, "test.txt");
            Assert.That(resp, Is.Not.Null);
            Assert.That(resp.Hash, Is.Not.Null);
            Assert.That(resp.Name, Is.Not.Null);
            Assert.That(resp.Size, Is.Not.Null);
        }
    }
}
