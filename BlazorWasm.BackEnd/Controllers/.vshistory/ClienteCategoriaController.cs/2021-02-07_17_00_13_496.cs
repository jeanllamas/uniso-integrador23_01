using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorMovies.Base.Entidades;
using BlazorMovies.Server.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BlazorMovies.Server.Controllers
{
    [ApiController]

    [Route("api/kdapio_cliente/categoria")]
    public class ClienteCategoriaController : CbmBaseController<Categoria>
    {

        public ClienteCategoriaController(DbContextOptions<ApplicationDbContext> options, IConfiguration iconfiguration, ApplicationDbContext context) : base(context)
        {
            this._context = new DomainDbContext(options,iconfiguration, "kdapio_cliente");
            _dbSet = context.Set<Categoria>();
        }
    }
}
