using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Model
{
    [Table("Clientes")]
    public class Clientes
    {
        [Key]
        [Column("cpf")]
        public string Cpf { get; set; }

        [Column("buyer-name")]
        public string Nome { get; set; }
        
        [Column("buyer-email")]
        public string Email { get; set; }

        [Column("buyer-phone-number")]
        public string Telefone { get; set; }

        [Column("ship-address-1")]
        public string? Logradouro { get; set; }

        [Column("ship-city")]
        public string? Cidade { get; set; }

        [Column("ship-state")]
        public string? Estado { get; set; }

        [Column("ship-postal-code")]
        public string? Cep { get; set; }

        [Column("ship-country")]
        public string? Pais { get; set; }
    }
}
