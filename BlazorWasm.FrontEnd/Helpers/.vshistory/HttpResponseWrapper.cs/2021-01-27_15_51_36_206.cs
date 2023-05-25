using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorMovies.Helpers
{
    public class HttpResponseWrapper<T>
    {
        public HttpResponseWrapper(T response, bool sucess, HttpResponseMessage httpResponseMessage)
        {
            Sucess = sucess;
            Response = Response;
            HttpResponseMessage = httpResponseMessage;
        
        }
        public bool Sucess { get; set; }
        public T Response { get; set; }
        public HttpResponseMessage  HttpResponseMessage { get; set; }

        public async Task<string> getBody() {
            return await HttpResponseMessage.Content.ReadAsStringAsync();
        }
    }
}
