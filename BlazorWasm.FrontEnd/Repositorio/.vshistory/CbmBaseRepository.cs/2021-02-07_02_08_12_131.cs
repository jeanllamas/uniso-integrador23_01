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
        private string _base_url = "/api/";

        public CbmBaseRepository(IHttpService httpService)
        {
            this._httpService = httpService;
        }

        public async Task Add<T>(T item)
        {
            string url = _base_url + item.GetType().Name.ToString().ToLower();
            var response = await _httpService.Post(url, item);
            if (response.Sucess == false)
            {
                throw new ApplicationException(await response.getBody());
            }
        }

        public async Task<List<T>> Get<T>(string url)
        {
            T item;
            string urxl = _base_url + item.GetType().Name.ToString().ToLower();
            var response = await _httpService.Get<List<T>>(url).ConfigureAwait(false);

            if (!response.Sucess)
                throw new ApplicationException(await response.getBody());

            return response.Response;
        }

        public async Task<List<T>> Get<T>(string url, string filter)
        {
            return await this.Get<T>(url + filter);
        }

        public async Task Update<T>(T item)
        {
            
            string url = _base_url + item.GetType().Name.ToString().ToLower();
            var response = await _httpService.Put(url, item);
            if (!response.Sucess)
            {
                throw new ApplicationException(await response.getBody());
            }
        }

        public async Task Delete<T>(T item ,int Id)
        {
            string url = _base_url + item.GetType().Name.ToString().ToLower();
            var response = await _httpService.Delete($"{url}/{Id}");
            if (!response.Sucess)
            {
                throw new ApplicationException(await response.getBody());
            }
        }
    }
}
