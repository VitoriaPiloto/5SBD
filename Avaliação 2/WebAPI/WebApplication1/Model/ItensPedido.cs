using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Model
{
    [Table("Itens_Pedido")]
    public class ItensPedido
    {
        [Key]
        [Column("order-item-id")]
        public string Id { get; set; }
     
        [Column("order-id")]
        public string IdPedido { get; set; }

        [Column("sku")]
        public string IdProduto { get; set; }

        [Column("quantity")]
        public int Quantidade { get; set; }
    }
}
