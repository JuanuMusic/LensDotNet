using LensDotNet.IPFS.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace LensDotNet.IPFS
{
    public class IPFSClient
    {
        HttpClient _client;
        public IPFSClient(HttpClient client, Uri baseUri = null)
        {
            _client = client;
            if (baseUri != null)
                _client.BaseAddress = baseUri;
        }

        public async Task<AddResponse> Add(byte[] file, string filename)
        {
            var content = new MultipartFormDataContent
            {
                {new StreamContent(new MemoryStream(file)), "file", filename}
            };
            var resp = await _client.PostAsync("/api/v0/add", content);
            //var retVal =  await resp.Content.ReadAsJson();
            //return retVal;
            return await resp.Content.ReadFromJsonAsync<AddResponse>();
        }

    }
}
