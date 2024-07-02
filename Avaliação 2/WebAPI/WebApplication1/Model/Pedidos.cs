using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Model
{
    [Table("Pedidos")]
    public class Pedidos
    {
        [Key]
        [Column("order-id")]
        public string Id { get; set; }

        [Column("purchase-date")]
        public string DataCompra { get; set; }

        [Column("payments-date")]
        public string DataPagamento { get; set; }

        [Column("cpf")]
        public string Cpf { get; set; }
    }
}
