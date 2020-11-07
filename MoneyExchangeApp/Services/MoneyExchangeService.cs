using Microsoft.Extensions.Caching.Memory;
using MoneyExchangeApp.DTO;
using MoneyExchangeApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MoneyExchangeApp.Services
{
    public class MoneyExchangeService : IMoneyExchangeService
    {
        private readonly string url = "https://api.exchangeratesapi.io/latest";
        public MoneyExchangeService()
        {
        }

        public  double CalculateTheRate(ExchangeHistory exchangeHistory)
        {
            try
            {
                if(exchangeHistory.FromAmount == 0)
                {
                    return exchangeHistory.ToAmount / Convert.ToDouble(exchangeHistory.ToCurrency) * Convert.ToDouble(exchangeHistory.FromCurrency);
                }
                else
                {
                    return exchangeHistory.FromAmount / Convert.ToDouble(exchangeHistory.FromCurrency) * Convert.ToDouble(exchangeHistory.ToCurrency);
                }
            }

            catch(Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public double CalculatTheRatio(ExchangeHistory exchangeHistory)
        {
            try
            {
                if (exchangeHistory.FromAmount == 0)
                {
                    return exchangeHistory.ToAmount / Convert.ToDouble(exchangeHistory.ToCurrency) * Convert.ToDouble(exchangeHistory.FromCurrency) / exchangeHistory.ToAmount;
                }
                else
                {
                    return exchangeHistory.FromAmount / Convert.ToDouble(exchangeHistory.FromCurrency) * Convert.ToDouble(exchangeHistory.ToCurrency) / exchangeHistory.FromAmount;
                }
            }

            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public Dictionary<double, string> CreateRatesDictionary(Rates rates)
        {
            var values = rates.GetType().GetProperties().Select(x => x.Name).ToList();
            var keys = rates.GetType().GetProperties().Select(x => Convert.ToDouble(x.GetValue(rates))).ToList();

            var ratesDictionary = keys.Zip(values, (k, v) => new { Key = k, Value = v })
                     .ToDictionary(x => x.Key, x => x.Value);

            return ratesDictionary;

        }

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
