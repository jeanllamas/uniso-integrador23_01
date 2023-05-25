using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorMovies.Base.Entidades
{
    public class Categoria
    {
        public int Id { get; set; }
       
        [Required(ErrorMessage = "Campo Nome é requirido.")]
        public string Nome { get; set; }
        public List<LivroCategoria> LivroCategorias { get; set; } = new List<LivroCategoria>();


    }
}
