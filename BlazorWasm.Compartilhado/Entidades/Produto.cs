using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazorWasm.Compartilhado.Entidades
{
    public class Produto :IEntity
    {
        public int Id { get; set; } 
        public string Descricao { get; set; }
        public string Nome { get; set; }
        public Double Preco { get; set; }

        public int CategoriaId  { get; set; }

        //Categoria não está na tabela produto diretamento no banco 
        //o parametro virtual indica lazzyLoading do EF
        public virtual Categoria Categoria { get; set; }
    }
}
