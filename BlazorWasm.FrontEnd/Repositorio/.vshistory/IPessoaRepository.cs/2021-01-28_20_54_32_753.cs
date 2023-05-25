using BlazorMovies.Base.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Repositorio
{
    public interface IPessoaRepository
    {
       
        Task CreatePessoa(Pessoa p);
    }
}
