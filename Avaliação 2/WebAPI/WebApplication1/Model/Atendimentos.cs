using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Model
{
    [Table("Atendimentos")]
    public class Atendimentos
    {
        [Key]
        [Column("Order-id")]
        public string AtendimentosId { get; set; }

        [Column("Total-price")]
        public double PrecoTotal { get; set; }

        [Column("possuiTodosItens")]
        public int possuiTodosOsItens { get; set; }

    }
}
