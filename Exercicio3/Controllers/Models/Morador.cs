using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exercicio3.Models
{
    [Table("Morador")]
    public class Morador
    {

        [Key]
        [Display(Name = "Código")]
        public int Id { set; get; }

        [Display(Name = "Familia")]
        [Required]
        public int Id_Familia { get; set; }
        [ForeignKey("Id_Familia")]

        [Display(Name = "Familia")]
        public Familia familia { get; set; }

        [Display(Name = "Nome Morador")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Nome { set; get; }

        [Display(Name = "Quantidade de bichos de Extimação")]
        [Required]
        public int QuantidadeBichosEstimacao { get; set; }
       
    }
}
