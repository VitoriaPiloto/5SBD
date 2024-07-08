using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Model
{
    [Table("Produtos")]
    public class Produtos
    {
        [Key]
        [Column("sku")]
        public string Sku { get; set; }

        [Column("product-name")]
        public string NomeProduto { get; set; }

        [Column("currency")]
        public string Moeda { get; set; }

        [Column("item-price")]
        public double Preco { get; set; }
    }
}
