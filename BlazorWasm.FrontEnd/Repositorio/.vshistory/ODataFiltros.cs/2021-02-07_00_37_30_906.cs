using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Repositorio
{
    public static class ODataFiltros
    {
        public const string SelectById = "?$filter=id eq ";
    }
}
