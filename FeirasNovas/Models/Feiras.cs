using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FeirasNovas.Data;
using Microsoft.AspNetCore.Identity;

namespace FeirasNovas.Models
{
    public class Feiras
    {

        [Key]
        public int idFeira { get; set; }
        [Required]
        public string Categoria { get; set; }
        [Required]
        public string VenderUsername { get; set; }

        public virtual ICollection<ApplicationUser> Vendedores { get; set; }
      
    }

}

