
using BlazorWasm.FrontEnd.Helpers;
using BlazorWasm.FrontEnd;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BlazorWasm.FrontEnd.Repositorio;
using BlazorWasm.Compartilhado.Entidades;

namespace BlazorWasm.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            //Configuracao Manual de Servicos
            ConfigureServices(builder.Services);
            await builder.Build().RunAsync();
        }

        //Registro dos Servicos Que serao utilizados via injecao de dependencia nos componentes/paginas RAZOR
        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IHttpService, HttpService>();

            //ATivar Repositorio Verdadeiro (no SGBD)
            services.AddTransient<IRepository<Categoria>, CategoriaRepository>();
            services.AddTransient<IRepository<Produto>, ProdutoRepository>();

            //ATIVAR Repositorio em Memoria (Fake)
            //services.AddSingleton<IRepository<Categoria>, RepositoryInMemoryCategoria>();
            //services.AddSingleton<IRepository<Produto>, RepositoryInMemoryProduto>();

        }
    }
}
