using BlazorWasm.Compartilhado.Entidades;
using BlazorWasm.FrontEnd.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorWasm.FrontEnd.Repositorio
{
    public class ClienteRepository : IRepository<Cliente>
    {
        private readonly IHttpService httpService;
        private string url = "api/cliente";

        public ClienteRepository(IHttpService httpService)
        {
            this.httpService = httpService;
        }

        public async Task<List<Cliente>> Get()
        {
            var response = await httpService.Get<List<Cliente>>(url);

            if (!response.Sucesso)
            {
                throw new ApplicationException(await response.GetBody());
            }
            return response.Response;
        }
        public async Task<Cliente> Get(int Id)
        {
            var response = await httpService.Get<Cliente>($"{url}/{Id}");
            if (!response.Sucesso)
            {
                throw new ApplicationException(await response.GetBody());
            }
            return response.Response;
        }


        public async Task Add(Cliente item)
        {

            var response = await httpService.Post(url, item);
            if (response.Sucesso == false)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }
        public async Task<int> AddAndGetId(Cliente item)
        {
            var response = await httpService.Post<Cliente, int>(url, item);
            if (response.Sucesso == false)
            {
                throw new ApplicationException(await response.GetBody());
            }
            return response.Response;
        }


        public async Task Update(Cliente item)
        {
            var response = await httpService.Put(url, item);
            if (!response.Sucesso)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task Delete(int Id)
        {
            var response = await httpService.Delete($"{url}/{Id}");
            if (!response.Sucesso)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }


    }
}
