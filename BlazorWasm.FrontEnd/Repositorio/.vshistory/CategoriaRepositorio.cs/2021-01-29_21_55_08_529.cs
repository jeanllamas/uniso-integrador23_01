using BlazorMovies.Base.Entidades;
using BlazorMovies.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Repositorio
{
    public class CategoriaRepositorio: ICategoriaRepositorio
    {
        private readonly IHttpService httpService;
        // private Uri url = new Uri(@"https://localhost:44387/api/categoria");
        private string url = "/api/categoria";

        public CategoriaRepositorio(IHttpService httpService)
        {
            this.httpService = httpService;
        }
        public async Task<List<Categoria>> GetCategorias() {
            var response = await httpService.Get<List<Categoria>>(url);

            if (!response.Sucess)
                throw new ApplicationException(await response.getBody());

            return response.Response;
        }
        public async Task CreateCategoria(Categoria categoria) 
        {
            var response = await httpService.Post(url, categoria);
            if (response.Sucess == false)
            {
                throw new ApplicationException(await response.getBody());
            }
        }
    }
}
