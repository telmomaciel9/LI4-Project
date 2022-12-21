using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FeirasNovas.Models
{
	public class Feiras
	{
        [Key]
        public int idFeira { get; set; }
        [Required]
        public string Categoria { get; set; }
        [Required]
        public string VenderUsername{ get; set; }

    }
}

