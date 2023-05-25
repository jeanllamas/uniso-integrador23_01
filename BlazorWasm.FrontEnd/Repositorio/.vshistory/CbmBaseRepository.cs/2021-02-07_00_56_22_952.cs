using BlazorMovies.Base.Entidades;
using BlazorMovies.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Repositorio
{
    public class CbmBaseRepository :ICbmRepository
    {

        private readonly IHttpService _httpService;
        //private string url = "/api/pessoa";

        public CbmBaseRepository(IHttpService httpService)
        {
            this._httpService = httpService;
        }

        public async Task Add<T>(T p)
        {
            string url = "/api/" + p.GetType().Name.ToString().ToLower();
            var response = await _httpService.Post(url, p);
            if (response.Sucess == false)
            {
                throw new ApplicationException(await response.getBody());
            }
        }

        public async Task<List<T>> Get<T>(string url)
        {
            var response = await _httpService.Get<List<T>>(url).ConfigureAwait(false);

            if (!response.Sucess)
                throw new ApplicationException(await response.getBody());

            return response.Response;
        }

        public async Task<List<T>> Get<T>(string url, string filter)
        {
            var response = await _httpService.Get<List<T>>(url+filter).ConfigureAwait(false);

            if (!response.Sucess)
                throw new ApplicationException(await response.getBody());

            return response.Response;
        }
    }
}
