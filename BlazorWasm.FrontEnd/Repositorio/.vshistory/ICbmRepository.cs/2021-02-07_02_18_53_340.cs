using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Repositorio
{
    public interface ICbmRepository
    { 
        Task Add<T>(T item);

        Task Delete<T>(int Id);
        Task<List<T>> Get<T>(string filtro);
        Task<List<T>> Get<T>();
        Task Update<T>(T item);
    }
}
