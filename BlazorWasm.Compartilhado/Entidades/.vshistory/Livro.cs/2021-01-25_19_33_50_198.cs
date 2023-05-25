using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorMovies.Base.Entidades
{
    public class Livro
    {
        public int Id { get; set; } 
        [Required]
        public string Titulo { get; set; }
        public string Resumo { get; set; }
        [Required]
        public DateTime? Data { get; set; }
        public string Poster { get; set; }
        public string ReviewUrl { get; set; }
        public bool Lancamento { get; set; }
        public List<LivroCategoria> LivroCategorias { get; set; }  = new List<LivroCategoria>();
        public string TituloCurto { 
            get 
            {
                if (string.IsNullOrEmpty(Titulo))
                    return null;

                if (Titulo.Length > 25)
                    return Titulo.Substring(0, 25) + " ...";
                else
                    return Titulo;
            }
        }
    }
}
