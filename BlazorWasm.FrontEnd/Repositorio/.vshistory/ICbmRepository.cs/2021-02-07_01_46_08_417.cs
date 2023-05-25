using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Repositorio
{
    public interface ICbmRepository
    { 
        Task Add<T>(T item);
        Task Delete<T>(T item, int Id);
        Task<List<T>> Get<T>(string url);
        Task<List<T>> Get<T>(string url, string filter);
        Task Update<T>(T item);
    }
}
