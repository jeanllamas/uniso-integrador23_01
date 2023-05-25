using BlazorWasm.Compartilhado.Entidades;
using BlazorWasm.FrontEnd.Repositorio;
using Bogus;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWasm.FrontEnd.Helpers
{
    public class RepositoryInMemoryCategoria : IRepository<Categoria>
    {
        public List<Categoria> Categorias { get; set; }
        private static int idBase = 0;

        public Task<List<Categoria>> Get()
        {
            return Task.FromResult(Categorias);

        }


        public Task<Categoria> Get(int id)
        {
            return Task.FromResult(Categorias.FirstOrDefault(x => x.Id == id));
        }

        public Task Add(Categoria categoria)
        {
            categoria.Id = idBase++;
            Categorias.Add(categoria);
            return Task.CompletedTask;
        }
        public Task<int> AddAndGetId(Categoria categoria)
        {
            categoria.Id = idBase++;
            Categorias.Add(categoria);

            return Task.FromResult(categoria.Id);
        }

        public Task Delete(Categoria categoria)
        {
            Categorias.Remove(categoria);
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var categoria = Categorias.Find(x => x.Id == id);
            Categorias.Remove(categoria);
            return Task.CompletedTask;
        }

        public Task Update(Categoria categoria)
        {
            int index = Categorias.IndexOf(Categorias.First(o => o.Id == categoria.Id));
            Categorias[index] = categoria;
            return Task.CompletedTask;
        }



        public RepositoryInMemoryCategoria()
        {
            Categorias = new List<Categoria>();

            //Adicionando Dados Aleatorios para Teste
            var dadosFake = GerarDadosParaTeste();
            Categorias.AddRange(dadosFake);
        }


        //Cria Dados Aleatorios para Teste
        private List<Categoria> GerarDadosParaTeste() {
            int categoriaIds = 0;
            var faker = new Faker<Categoria>()
         .RuleFor(c => c.Id, f => categoriaIds++)
         .RuleFor(c => c.Nome, f => f.Commerce.Department());
            return faker.GenerateBetween<Categoria>(10, 15);

        }
    }
}
