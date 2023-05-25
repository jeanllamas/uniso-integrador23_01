using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorMovies.Helpers
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
            var dataJson = JsonSerializer.Serialize(data);
            var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(url, stringContent);
          
            return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);

        }

        public async Task<HttpResponseWrapper<object>> Post<T>(string url, T data)
        {
            var dataJson = JsonSerializer.Serialize(data);
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
            var dataJson = JsonSerializer.Serialize(data);
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

        private async Task<T> Deserialize<T>(HttpResponseMessage httpResponse, JsonSerializerOptions options=null)
        {
            var responseString = await httpResponse.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(responseString,options)
        }
    }
}
