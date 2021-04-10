using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoBanda.Models
{
    public class Musico
    { 
        [Key]
        public long? MusicoID { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public int Idade { get; set; }
        [Required]
        public string Instrumento { get; set; }
        [Required]
        public string Telefone { get; set; }
        [Required]
        public string Sexo { get; set; }


    }
}
