using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exercicio3.Models
{
    [Table("Familia")]
    public class Familia
    {
        [Key]
        [Display(Name = "Código")]
        public int Id { set; get; }

        [Display(Name = "Nome Familia")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Nome { set; get; }

        [Required]
        public int Id_Condominio { get; set; }
        [ForeignKey("Id_Condominio")]
        public Condominio condominio { get; set; }

        [Required]
        public int Apto { set; get; }
    } 
}
 