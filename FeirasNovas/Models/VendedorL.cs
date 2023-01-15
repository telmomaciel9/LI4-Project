using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FeirasNovas.Models
{
	public class VendedorL
	{
		[Key]
		public int VendedorIdL { get; set; }
		public string VendedorNameL { get; set; }

		[ForeignKey("VendedorIdL")]
		public Feiras Feiras { get; set; }


	}
}

