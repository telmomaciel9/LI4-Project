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
        public List<string> UserNames { get; set; }

<<<<<<< HEAD
        //Relationship
        //public List<Product> Products{ get; set; }
        public List<Feira_Product> Feira_Products { get; set; }
=======
>>>>>>> b3f80d55761f5e7dac1a2a5d267adb0f19c70dc4
    }

}

