using BlazorMovies.Base.Entidades;
using BlazorMovies.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Repositorio
{
    public class PessoaRepository : IPessoaRepository
    {

        private readonly IHttpService httpService;
        private Uri url = new Uri(@"https://localhost:44387/api/pessoa");

        public PessoaRepository(IHttpService httpService)
        {
            this.httpService = httpService;
        }
        public async Task CreateCategoria(Pessoa p)
        {
            var response = await httpService.Post(url, p);
            if (response.Sucess == false)
            {
                throw new ApplicationException(await response.getBody());
            }
        }
    }
}
