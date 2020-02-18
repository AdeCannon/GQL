using FOA.GraphQL.Repositories.Repositories;
using FOA.Thinkfolio.ControlReports.Domain.Record;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FOA.GraphQL.Repositories
{
    public class OrdersRepositoryUrl
    {
        private readonly string baseUrl = "http://localhost:5000/api/Entity/";

        public OrdersRepositoryUrl()
        {
        }

        public IEnumerable<Orders> GetAll()
        {
            var url = baseUrl + "orders";

            var re = this.Get(url).Result;

            var ret = JsonConvert.DeserializeObject<IEnumerable<Orders>>(re);

            return ret;
        }

        
        public IEnumerable<Orders> GetByOrderArgs(int? orderId, string omsOrderId, string omsOrderVersionId, DateTime createdFrom, DateTime createdTo, string securityId)
        {
            var url = new StringBuilder(baseUrl)
                .Append("orders");

            if(orderId != null & orderId != 0)
            {
                url.Append($"?orderId={orderId}");
            }

            if (!string.IsNullOrEmpty(omsOrderId))
            {
                url.Append($"?omsOrderId={omsOrderId}");
            }

            if (!string.IsNullOrEmpty(omsOrderVersionId))
            {
                url.Append($"?omsOrderVersionId={omsOrderVersionId}");
            }

            if (createdFrom != default)
            {
                url.Append($"?createdFrom={createdFrom.ToUniversalTime()}");
            }

            if (createdTo != default)
            {
                url.Append($"?createdTo={createdTo.ToUniversalTime()}");
            }

            var re = this.Get(url.ToString()).Result;

            var ret = JsonConvert.DeserializeObject<IEnumerable<Orders>>(re);

            return ret;
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
    }
}
