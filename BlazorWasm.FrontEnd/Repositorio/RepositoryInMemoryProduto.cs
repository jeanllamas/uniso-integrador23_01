using BlazorWasm.Compartilhado.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWasm.FrontEnd.Repositorio
{
    public class RepositoryInMemoryProduto : IRepository<Produto>
    {
        public List<Produto> ListaProdutos { get; set; } = new List<Produto>();
        private static int idBase = 0;

        public Task Add(Produto item)
        {
            item.Id = idBase++;
            ListaProdutos.Add(item);
            return Task.CompletedTask;
        }

        public Task<int> AddAndGetId(Produto item)
        {
            item.Id = idBase++;
            ListaProdutos.Add(item);
            return Task.FromResult(item.Id);
        }

        public Task Delete(int Id)
        {
            var itemToRemove = ListaProdutos.Find(x => x.Id == Id);
            ListaProdutos.Remove(itemToRemove);
            return Task.CompletedTask;
        }

        public Task<List<Produto>> Get()
        {
            return Task.FromResult(ListaProdutos);
        }

        public Task<Produto> Get(int id)
        {
            var item = ListaProdutos.Find(x => x.Id == id);       
            return Task.FromResult(item);
        }

        public Task Update(Produto item)
        {
            int index = ListaProdutos.IndexOf
                (ListaProdutos.First(o => o.Id == item.Id));
            ListaProdutos[index] = item;
            return Task.CompletedTask;
        }
    }
}
