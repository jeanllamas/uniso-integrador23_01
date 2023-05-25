using BlazorMovies.Base.Entidades;
using BlazorMovies.Server.Helpers;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BlazorMovies.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivroController
    {
        private readonly ApplicationDbContext _context;
        private readonly IFileStorageService _fileStorageService;
        public LivroController(ApplicationDbContext context, IFileStorageService fileStorageService)
        {
            this._context = context;
            this._fileStorageService = fileStorageService;
        }

        [HttpGet]
        [EnableQuery()]
        public async Task<ActionResult<List<Livro>>> Get()
        {    
            return  await _context.Livros.ToListAsync();
        }


        [HttpPost]
        public async Task<ActionResult<int>> Post(Livro livro)
        {
            if (!string.IsNullOrEmpty(livro.Poster))
            {
                var img = Convert.FromBase64String(livro.Poster);
                livro.Poster = await _fileStorageService.SaveFile(img, "jpg", "livros");
            }

            if (livro.LivroPessoa != null)
            {
                for (int i = 0; i < livro.LivroPessoa.Count; i++)
                    livro.LivroPessoa[i].Order = i + 1;
            }

            _context.Add(livro);
            await _context.SaveChangesAsync();
            return livro.Id;
        }
    }
}
