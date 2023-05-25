using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorWasm.FrontEnd.Helpers
{
    public class HttpResponseWrapper<T>
    {
        public HttpResponseWrapper(T response, bool sucess, HttpResponseMessage httpResponseMessage)
        {
            Sucesso = sucess;
            Response = response;
            HttpResponseMessage = httpResponseMessage;
        
        }
        public bool Sucesso { get; set; }
        public T Response { get; set; }
        public HttpResponseMessage  HttpResponseMessage { get; set; }

        public async Task<string> GetBody() {
            return await HttpResponseMessage.Content.ReadAsStringAsync();
        }
    }
}
