using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using translater_2.Models;

namespace translater_2.Services
{
    public class DataService
    {
        private static readonly DataService _instance = new DataService();
        private HttpClient _client = new HttpClient();

        private readonly string _baseUrl = "https://dictionary.yandex.net/api/v1/dicservice.json/lookup";
        private readonly string _apiKey = "dict.1.1.20170615T154653Z.db293a58d2fe99b9.da699ed9aba6ff3f25c7ef8b82c2eaaf471128b5";

        public static DataService GetInstance()
        {
            return _instance;
        }

        public async Task<ResponseModel> TranslateAsync(string lang, string text)
        {
            try
            {
                var response = await _client.PostAsync($"{_baseUrl}?key={_apiKey}&lang={lang}&text={text}", new StringContent("", Encoding.UTF8, "application/json"));
                var responseBody = await response.Content.ReadAsStringAsync();
                var responseJson = JsonConvert.DeserializeObject<ResponseModel>(responseBody);
                return responseJson;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return new ResponseModel {};
            }
        }
    }
}
