using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Model
{
    [Table("Estoque")]
    public class Estoque
    {
        [Key]
        [Column("id")]
        public string Id { get; set; }

        [Column("Quantity")]
        public int Quantidade { get; set; }

        [Column("sku")]
        public string CodigoProduto { get; set; }
    }
}
