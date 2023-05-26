using System.Linq;
using System.Threading.Tasks;
using BlazorWasm.Compartilhado.Entidades;

namespace BlazorWasm.FrontEnd.Repositorio
{
    public static class IRepositoryExtensions
    {
        public static async Task<Cliente> GetByEmail(this IRepository<Cliente> repository, string email)
        {
            var clientes = await repository.Get();
            return clientes.FirstOrDefault(c => c.Email == email);
        }
    }
}
