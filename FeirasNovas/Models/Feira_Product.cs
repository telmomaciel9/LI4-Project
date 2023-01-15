using System;

namespace FeirasNovas.Models
{
	public class Feira_Product
	{
		public int idProduto { get; set; }
		public Product Product { get; set; }

        public int idFeira { get; set; }
		public Feiras Feiras { get; set; }
    }
}

