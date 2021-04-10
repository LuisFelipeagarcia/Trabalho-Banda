using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoBanda.Models
{
    public class Banda
    {
        [Key]
        public long? BandaID { get; set; }

        
        [Required]
        public string Nome { get; set; }

        [Display(Name = "Numero de Integrantes")]
        [Required]
        public int numIntegrantes { get; set; }

        [EmailAddress(ErrorMessage = "E-mail inválido")]
        [Display(Name = "E-mail")]
        [Required]
        public string Email { get; set; }

        [Display(Name = "Categoria Musical")]
        [Required]
        public string CatMusical { get; set; }

        [Display(Name = "Numero de Albuns Lançados")]
        [Required]
        public int numAlbuns { get; set; }


    }
}
