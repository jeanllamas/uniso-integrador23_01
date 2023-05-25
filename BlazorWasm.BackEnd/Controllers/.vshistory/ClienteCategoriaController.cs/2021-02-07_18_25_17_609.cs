using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorMovies.Base.Entidades;
using BlazorMovies.Server.Helpers;
using Microsoft.AspNet.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BlazorMovies.Server.Controllers
{
    
    [ApiController]

    [Route("api/kdapio_cliente/categoria")]
    public class ClienteCategoriaController
        : CbmBaseController<Categoria>
    {
        private DomainDbContext _novoContext;
        public ClienteCategoriaController(DbContextOptions<ApplicationDbContext> options, IConfiguration iconfiguration, ApplicationDbContext context)
            : base(context)
        {
            _novoContext = new DomainDbContext(iconfiguration, "kdapio_cliente");
            _dbSet = _novoContext.Set<Categoria>();
        }
/*
        [HttpGet]
        [EnableQuery()]
        public async Task<ActionResult<List<Categoria>>> Get()
        {
           
            return await _novoContext.Categorias.ToListAsync();
        }
*/
    }

}
