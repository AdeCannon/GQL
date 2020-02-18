using FOA.Thinkfolio.ControlReports.Domain.Record;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FOA.GraphQL.Repositories
{
    public class ControlRepportRepository
    {
        private readonly string baseUrl = "http://foa-thinkfolio-rpt-test/api/ControlReports/";

        public ControlRepportRepository()
        {
        }

        public IEnumerable<BackFromTransferredRecord> GetBackFromTransferred(DateTime dateFron, DateTime dateTo)
        {
            var url = new StringBuilder(baseUrl).Append($"BackFromTransferred/{dateFron.ToString("yyyy-MM-dd")}/{dateTo.ToString("yyyy-MM-dd")}").ToString();
            var re = this.GetAuth(url).Result;

            var ret = JsonConvert.DeserializeObject<IEnumerable<BackFromTransferredRecord>>(re);

            return ret;
        }

        public IEnumerable<InputAuthSameUserRecord> GetInputAuthSameUser(DateTime dateFron, DateTime dateTo)
        {
            var url = new StringBuilder(baseUrl).Append($"InputAuthSameUser/{dateFron.ToString("yyyy-MM-dd")}/{dateTo.ToString("yyyy-MM-dd")}").ToString();
            var re = this.GetAuth(url).Result;

            var ret = JsonConvert.DeserializeObject<IEnumerable<InputAuthSameUserRecord>>(re);

            return ret;
        }

        public IEnumerable<SameUserTradingRecord> GetSameUserTrading(DateTime dateFron, DateTime dateTo)
        {
            var url = new StringBuilder(baseUrl).Append($"SameUserTrading/{dateFron.ToString("yyyy-MM-dd")}/{dateTo.ToString("yyyy-MM-dd")}").ToString();
            var re = this.GetAuth(url).Result;

            var ret = JsonConvert.DeserializeObject<IEnumerable<SameUserTradingRecord>>(re);

            return ret;
        }

        public IEnumerable<UnsolicitedTradingRecord> GetUnsolicitedTrading(DateTime dateFron, DateTime dateTo)
        {
            var url = new StringBuilder(baseUrl).Append($"UnsolicitedTrading/{dateFron.ToString("yyyy-MM-dd")}/{dateTo.ToString("yyyy-MM-dd")}").ToString();
            var re = this.GetAuth(url).Result;

            var ret = JsonConvert.DeserializeObject<IEnumerable<UnsolicitedTradingRecord>>(re);

            return ret;
        }

        private async Task<string> GetAuth(string url)
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler()
            {
                UseProxy = false,
                PreAuthenticate = true,
                UseDefaultCredentials = true,
            };

            using (var client = new HttpClient(httpClientHandler))
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
