using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BlazorWasm.FrontEnd.Helpers
{
    public class HttpService :IHttpService
    {
        private readonly HttpClient httpClient;
        private static readonly JsonSerializerOptions defaultJsonSerializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    
     
        public HttpService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<HttpResponseWrapper<object>> Post<T>(Uri url, T data) 
        {
            var dataJson = System.Text.Json.JsonSerializer.Serialize(data);
            var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(url, stringContent);
          
            return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);

        }

        public async Task<HttpResponseWrapper<object>> Post<T>(string url, T data)
        {
            var dataJson = System.Text.Json.JsonSerializer.Serialize(data);
            var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(url, stringContent);

            return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">Tipo do objeto enviado</typeparam>
        /// <typeparam name="TResponse">Tipo da resposta Esperada</typeparam>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T data)
        {
            var dataJson = System.Text.Json.JsonSerializer.Serialize(data);
            var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
            var respJson = await httpClient.PostAsync(url, stringContent);

            if (respJson.IsSuccessStatusCode)
            {
                var resposta = await Deserialize<TResponse>(respJson, defaultJsonSerializerOptions);
                return new HttpResponseWrapper<TResponse>(resposta, true, respJson);
            }
            else
            {
                return new HttpResponseWrapper<TResponse>(default, false, respJson);
            }           
        }

        public async Task<HttpResponseWrapper<T>> Get<T>(string url)
        {
            var respostaHttp = await httpClient.GetAsync(url);

            if (respostaHttp.IsSuccessStatusCode)
            {
                var resposta = await Deserialize<T>(respostaHttp,defaultJsonSerializerOptions);
                return new HttpResponseWrapper<T>(resposta, true, respostaHttp);
            }

            return new HttpResponseWrapper<T>(default, false, respostaHttp);
        }
        public async Task<HttpResponseWrapper<T>> Get<T>(Uri url)
        {
            var respostaHttp = await httpClient.GetAsync(url);

            if (respostaHttp.IsSuccessStatusCode)
            {
                var resposta = await Deserialize<T>(respostaHttp, defaultJsonSerializerOptions).ConfigureAwait(false);
                return new HttpResponseWrapper<T>(resposta, true, respostaHttp);
            }

            return new HttpResponseWrapper<T>(default, false, respostaHttp);
        }

        public async Task<HttpResponseWrapper<object>> Put<T>(string url, T data)
        {
            var dataJson = System.Text.Json.JsonSerializer.Serialize(data);
            var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync(url, stringContent);
            return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
        }

   

        public async Task<HttpResponseWrapper<object>> Delete(string url)
        {
            var responseHTTP = await httpClient.DeleteAsync(url);
            return new HttpResponseWrapper<object>(null, responseHTTP.IsSuccessStatusCode, responseHTTP);
        }

        private async Task<T> Deserialize<T>(HttpResponseMessage httpResponse, JsonSerializerOptions options=null)
        {
            var body = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);


            /*
             JObject parsedJson = JObject.Parse(body);
             var token = parsedJson["value"]; 

              
             var ODataJSON = JsonConvert.DeserializeObject<JObject>(body);
             ODataJSON.Property("@odata.context").Remove();
             ODataJSON.Add("Terminal", ODataJSON["value"]); //adding Terminal attribute
             ODataJSON.Property("value").Remove();
             body = ODataJSON.ToString().Trim();
             body = Regex.Replace(body, @"\t|\n|\r", "").Trim();
      */


            return System.Text.Json.JsonSerializer.Deserialize<T>(body, options);
        }
    }
}
