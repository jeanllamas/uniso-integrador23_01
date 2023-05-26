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
    public class ClienteController : ControllerBase 
    {
        private readonly ApplicationDbContext context;
        public ClienteController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> Get()
        {
            return await context.Clientes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> Get(int id)
        {
            var resp =await context.Clientes.FirstOrDefaultAsync(x => x.Id == id);
            if (resp == null) { return NotFound(); }
            return resp;
        }


        [HttpPost]
        public async Task<ActionResult<int>> Post(Cliente cliente)
        {
            context.Clientes.Add(cliente);
            await context.SaveChangesAsync();
            return cliente.Id;
        }

        [HttpPut]
        public async Task<ActionResult> Put(Cliente cliente)
        {
            context.Attach(cliente).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var cliente = await context.Clientes.FirstOrDefaultAsync(x => x.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            context.Remove(cliente);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }

}
