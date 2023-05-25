using BlazorMovies.Base.Entidades;
using BlazorMovies.Server.Helpers;
using Microsoft.AspNetCore.Mvc;
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
        private readonly ApplicationDbContext context;
        private readonly IFileStorageService fileStorageService;
        public LivroController(ApplicationDbContext context, IFileStorageService fileStorageService)
        {
            this.context = context;
            this.fileStorageService = fileStorageService;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Livro livro)
        {
            if (!string.IsNullOrEmpty(livro.Picture))
            {
                var img = Convert.FromBase64String(livro.Picture);
                livro.Picture = await fileStorageService.SaveFile(img, "jpg", "pessoa");
            }
            context.Add(livro);
            await context.SaveChangesAsync();
            return livro.Id;
        }
    }
}
