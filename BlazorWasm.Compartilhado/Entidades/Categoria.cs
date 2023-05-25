using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWasm.Compartilhado.Entidades
{
    public class Categoria :IEntity
    {
        public int Id { get; set; }
       
        //Parametro para mensagem de Erro
        [Required(ErrorMessage = "Campo Nome é requirido.")]
        public string Nome { get; set; }




        [System.ComponentModel.DataAnnotations.Editable(false)]
        public virtual ICollection<Produto> Produto { get; set; }


    }
}
