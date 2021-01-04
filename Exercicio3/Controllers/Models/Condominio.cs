using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exercicio3.Models
{

    [Table("Condominio")]
    public class Condominio
    {
        [Key]
        [Display(Name ="Código")]
        public int Id { set; get; }

        [Display(Name = "Nome Condominio")]
        [Required(ErrorMessage ="Campo Obrigatório")]
        [StringLength(20,MinimumLength =6,ErrorMessage ="Minimo 6 e Maximo de 10 Letras")]
        public string  Nome { set; get; }

        [Required]
        public string Bairro { set; get; }

        [Required]
        public string Cidade { set; get; }
        
    }
}
