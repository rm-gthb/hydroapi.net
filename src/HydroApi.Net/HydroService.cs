using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HydroApi.Net
{
    public class HydroService : IHydroService
    {
        private const string BaseUrl = "https://api.hydrogenplatform.com/hydro/v1";

        private HttpClient httpClient;

        private Dictionary<string, string> BaseParameters { get; set; }

        public string ApiKey { get; private set; }

        public string ApiUsername { get; private set; }

        public HydroService(string apiKey, string apiUsername)
        {
            if (String.IsNullOrEmpty(apiKey) || String.IsNullOrEmpty(apiUsername))
                throw new FormatException();

            ApiKey = apiKey;

            ApiUsername = apiUsername;

            httpClient = new HttpClient()
            {
                BaseAddress = new Uri(BaseUrl)
            };

            BaseParameters.Add("username", ApiUsername);
            BaseParameters.Add("key", ApiKey);
        }

        public async Task<string> RegisterAddress(string address)
        {
            string path = "/whitelist/{0}" + address;

            StringContent content = new StringContent(BaseParameters.ToString(), Encoding.UTF8);

            HttpResponseMessage response = await httpClient.PostAsync(path, content).ConfigureAwait(false);

            string hydroAddressId = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return hydroAddressId;
        }

        public async Task<RaindropDetails> RequestRaindrop(string hydroAddressId)
        {
            string path = "/challenge?hydroAddressId=" + hydroAddressId;

            StringContent content = new StringContent(BaseParameters.ToString(), Encoding.UTF8);

            HttpResponseMessage response = await httpClient.PostAsync(path, content).ConfigureAwait(false);

            string responseString  = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            RaindropDetails details = JsonConvert.DeserializeObject<RaindropDetails>(responseString);

            return details;
        }

        public async Task<bool> CheckValidRaindrop(string hydroAddressId)
        {
            string path = "/authenticate?hydroAddressId=" + hydroAddressId;

            StringContent content = new StringContent(BaseParameters.ToString(), Encoding.UTF8);

            HttpResponseMessage response = await httpClient.PostAsync(path, content).ConfigureAwait(false);

            string responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return responseString == "true" ?  true : false;
        }

    }
}
