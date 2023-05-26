using BlazorWasm.Compartilhado.Entidades;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BlazorWasmServer.Server.Controllers
{
    [ApiController]

    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase 
    {
        private readonly ApplicationDbContext context;
        public CategoriaController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Categoria>>> Get()
        {
            return await context.Categorias.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> Get(int id)
        {
            var resp =await context.Categorias.FirstOrDefaultAsync(x => x.Id == id);
            if (resp == null) { return NotFound(); }
            return resp;
        }


        [HttpPost]
        public async Task<ActionResult<int>> Post(Categoria categoria)
        {
            context.Categorias.Add(categoria);
            await context.SaveChangesAsync();
            return categoria.Id;
        }

        [HttpPut]
        public async Task<ActionResult> Put(Categoria categoria)
        {
            context.Attach(categoria).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var categoria = await context.Categorias.FirstOrDefaultAsync(x => x.Id == id);
            if (categoria == null)
            {
                return NotFound();
            }

            context.Remove(categoria);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }

}
