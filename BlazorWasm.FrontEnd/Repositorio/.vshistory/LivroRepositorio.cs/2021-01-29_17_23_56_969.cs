using BlazorMovies.Base.Entidades;
using BlazorMovies.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Repositorio
{
    public class LivroRepositorio : ILivroRepositorio
    {
        private readonly IHttpService httpService;
        private string url = "/api/livro";

        public LivroRepositorio(IHttpService httpService)
        {
            this.httpService = httpService;
        }
        public async Task<int> CreatePessoa(Livro livro )
        {
            var response = await httpService.Post<Livro,int>(url, livro);
            if (response.Sucess == false)
            {
                throw new ApplicationException(await response.getBody());
            }

            return response.Response;
        }
    }
}
