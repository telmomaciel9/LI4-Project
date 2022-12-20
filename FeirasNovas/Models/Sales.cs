using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FeirasNovas.Models
{
    public class Sales
    {
        [Key]
        public int idVenda { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public string Fatura { get; set; }

        public Product Product { get; set; }
    }
}

