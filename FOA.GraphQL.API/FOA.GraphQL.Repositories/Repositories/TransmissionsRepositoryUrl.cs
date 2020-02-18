
using FOA.Entity.Domain;
using GraphQL;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FOA.GraphQL.Repositories
{
    public class TransmissionsRepositoryUrl
    {
        private readonly string baseUrl = "http://localhost:5000/api/Entity/";

        public TransmissionsRepositoryUrl()
        {
        }

        public IEnumerable<Transmission> GetAll()
        {
            throw new NotImplementedException();
        }

        public int GetTransmissionCount()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Transmission>> GetForAllocation(int OrderId, string SecurityId)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetCountForAllocation(int OrderId)
        {
            throw new NotImplementedException();
        }

        public async Task<ILookup<int, Transmission>> GetForAllocationIds(IEnumerable<int> allocationIds)
        {
            //http://localhost:49677/api/Entity/transmissions?allocationIds=6170&allocationIds=6171

            var sb = new StringBuilder(baseUrl + "transmissions?");

            var re = await this.Post(sb.ToString(), allocationIds);

            var transmissions = JsonConvert.DeserializeObject<List<Transmission>>(re);            

            return transmissions.ToLookup(r => r.AllocationId);
        }

        private async Task<string> Get(string url)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);

                var rep = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    return rep;
                }
                else
                {
                    var message = $"Api call error: {rep}" + Environment.NewLine + $"url: {url}";
                    throw new ApplicationException(message);
                }
            }
        }

        private async Task<string> Post(string url, IEnumerable<int> payload)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            var httpContent = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");

            HttpClientHandler httpClientHandler = new HttpClientHandler()
            {
                UseProxy = false,
                PreAuthenticate = true,
                UseDefaultCredentials = true,
            };

            using (var client = new HttpClient(httpClientHandler))
            {
                client.Timeout = new TimeSpan(0, 1, 0);
                var response = client.PostAsync(url, httpContent).Result;

                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    var message = $"Api call error: {response}" + Environment.NewLine + $"url: {url}";
                    throw new ApplicationException(message);
                }
            }
        }
    }
}
