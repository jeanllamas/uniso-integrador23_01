using BlazorMovies.Base.Entidades;
using BlazorMovies.Server.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;

namespace BlazorMovies.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IFileStorageService fileStorageService;
        public PessoaController(ApplicationDbContext context, IFileStorageService fileStorageService)
        {
            this.context = context;
            this.fileStorageService = fileStorageService;
        }

        [HttpGet]
        [EnableQuery()]
        public async Task<ActionResult<List<Pessoa>>> Get()
        {
            return await context.Pessoas.ToListAsync();
        }

        [HttpGet("search/{searchText}")]
        public async Task<ActionResult<List<Pessoa>>> GetFilerByName(string searchText)
        {
            if (string.IsNullOrEmpty(searchText)) { return new List<Pessoa>();  }

            return await context.Pessoas.Where(x => x.Nome.Contains(searchText))
                .Take(5)//Quantidade maxima de retorno
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Pessoa pessoa)
        {
            if (!string.IsNullOrEmpty(pessoa.Picture))
            {
                var img = Convert.FromBase64String(pessoa.Picture);
                pessoa.Picture = await fileStorageService.SaveFile(img, "jpg", "pessoa");
            }
            context.Add(pessoa);
            await context.SaveChangesAsync();
            return pessoa.Id;
        }
    }
}
