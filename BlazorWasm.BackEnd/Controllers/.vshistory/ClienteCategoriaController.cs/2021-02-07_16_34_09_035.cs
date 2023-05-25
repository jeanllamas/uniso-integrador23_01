using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorMovies.Base.Entidades;
using BlazorMovies.Server.Helpers;
using Microsoft.Extensions.Configuration;

namespace BlazorMovies.Server.Controllers
{
    [ApiController]

    [Route("api/kdapio_cliente/categoria")]
    public class ClienteCategoriaController : CbmBaseController<Categoria>
    {

        public ClienteCategoriaController(DomainDbContext context, IConfiguration iconfiguration) : base(context)
        {
            //this._context = new DomainDbContext("kdapio_cliente", iconfiguration);
        }
    }
}
