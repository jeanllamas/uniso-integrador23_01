using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Repositorio
{
    public static class ODataFiltros
    {
        public static string SelectById(string Id) { return "?$filter=id eq " + Id; }

        public static string Contains(string table, string filtro) { return $"?$filter=substringof({table}, '{filtro}')"; }


    }
}
