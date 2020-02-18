using FOA.GraphQL.Repositories.Repositories;
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
    public class AllocationsRepositoryUrl
    {
        private readonly string baseUrl = "http://localhost:5000/api/Entity/";

        public AllocationsRepositoryUrl()
        {
        }

        public IEnumerable<Allocations> GetAll()
        {
            throw new NotImplementedException();
        }

        public int GetAllocationsCount()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Allocations>> GetForOrder(int OrderId, string SecurityId)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetCountForOrder(int OrderId)
        {
            throw new NotImplementedException();
        }

        //public async Task<ILookup<int, Allocations>> GetForOrders(IEnumerable<int> OrderIds)
        //{
        //    // http://localhost:49677/api/Entity/allocations?OrderIds=549&OrderIds=548&OrderIds=547

        //    var sb = new StringBuilder(baseUrl + "allocations?");

        //    OrderIds.ToList().ForEach(orderId => { sb.Append($"OrderIds={orderId}&"); });

        //    var re = await this.Get(sb.ToString());

        //    var allocations = JsonConvert.DeserializeObject<List<Allocations>>(re);            

        //    return allocations.ToLookup(r => r.OrderId);
        //}

        public async Task<ILookup<int, Allocations>> GetForOrders(IEnumerable<int> OrderIds)
        {
            var sb = new StringBuilder(baseUrl + "allocations");

            var re = await this.Post(sb.ToString(), OrderIds);

            var allocations = JsonConvert.DeserializeObject<List<Allocations>>(re);

            return allocations.ToLookup(r => r.OrderId);
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
