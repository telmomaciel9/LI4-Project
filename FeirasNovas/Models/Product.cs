﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FeirasNovas.Models
{
	public class Product
	{
        [Key]
        public int idProduto { get; set; }
        [Required]
        public string Name { get; set;}
        [Required]
        public int  Preco { get; set; }
        public string Imagem { get; set; }
        [Required]
        public int Stock { get; set; }
        [DisplayName("Descrição")]
        public string Descricao { get; set; }
    }
}
