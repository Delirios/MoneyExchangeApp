using MoneyExchangeApp.DTO;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace MoneyExchangeApp.Services
{
    public class MoneyExchangeService : IMoneyExchangeService
    {
        private readonly string url = "https://api.exchangeratesapi.io/latest";
        public async Task<Root> GetRatesFromApi()
        {
            WebRequest webRequest = WebRequest.Create(url);
            WebResponse webResponse = await webRequest.GetResponseAsync();

            using (Stream stream = webResponse.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream);
                string responceFromServer = await reader.ReadToEndAsync();

                Root result = JsonConvert.DeserializeObject<Root>(responceFromServer);
                return result;
            }
        }
    }
}
